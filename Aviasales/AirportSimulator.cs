using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Aviasales
{
    public class AirportSimulator // Класс моделирования работы аэропорта
    {
        public List<RunwayData> runwaysData = new List<RunwayData>(); // Список данных о полосах взлёта и посадки
        public List<AirRoute> routes = new List<AirRoute>(); // Список маршрутов авиарейсов
        public List<AirRequestData> requestsData = new List<AirRequestData> { }; // Список данных о запросах

        private DateTime currentSimulationTime; // Текущее время симуляции

        private RequestsFlowManager requestsFlowManager; // Управление потоком запросов
        private Dispatcher dispatcher; // Диспетчер
        private RoutesSchedule routesSchedule; // Расписание маршрутов авиарейсов
        private List<AirportRequest> requests = new List<AirportRequest>(); // Список запросов
        public DateTime CurrentSimulationTime { get => currentSimulationTime; set => currentSimulationTime = value; } // Свойство текущего времени симуляции

        public AirportSimulator(SimulationConfig config) // Конструктор
        {
            // Инициализирует компоненты симуляции
            CurrentSimulationTime = config.StartDateTime;
            Console.WriteLine("Текущее время моделирования = " + CurrentSimulationTime.ToString());

            dispatcher = new Dispatcher(config.StartDateTime, config.RunwaysCount);
            routesSchedule = new RoutesSchedule();
            routes = new List<AirRoute>();

            foreach (var r in routesSchedule.GetRoutes())
            {
                routes.Add(r);
            }

            List<Airport> airports = extractAiroirtsFromAirRoutes(routes);
            ChooseLocalAirportForm chooseLocalAirportForm = new ChooseLocalAirportForm(airports);
            chooseLocalAirportForm.ShowDialog();
            string localAirportName = chooseLocalAirportForm.choosenAirportName;

            routes.RemoveAll(r => !(r.ArrivePoint.Name.Equals(localAirportName) ^ r.DeparturePoint.Name.Equals(localAirportName)));

            requestsFlowManager = new RequestsFlowManager(config, new Airport(localAirportName));

            // Генерирует новые запросы и добавляет их к текущим
            requests.AddRange(requestsFlowManager.GenerateRequests(routes));

            int overdatedRoutes = requests.Count(r => (r.GetCriticalDateTime() < CurrentSimulationTime));
            if (overdatedRoutes > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Время начала симуляции позднее некоторых рейсов. Это приведёт к тому, что данные рейсы могут обрабатываться некорректно. Уверены, что хотите продолжить?", "Заведомо просроченные рейсы", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
        }

        private List<Airport> extractAiroirtsFromAirRoutes(List<AirRoute> routes) // Извлекает уникальные аэропорты из списка маршрутов
        {
            Dictionary<string, Airport> airportsDict = new Dictionary<string, Airport>(); // Создание словаря для хранения уникальных аэропортов по их именам

            foreach (var r in routes)
            {
                if (!airportsDict.ContainsKey(r.ArrivePoint.Name))
                {
                    airportsDict.Add(r.ArrivePoint.Name, r.ArrivePoint);
                }
                if (!airportsDict.ContainsKey(r.DeparturePoint.Name))
                {
                    airportsDict.Add(r.DeparturePoint.Name, r.DeparturePoint);

                }
            }

            return airportsDict.Values.ToList();
        }

        public void SimulateStep(TimeSpan delta) // Моделирует шаг симуляции
        {
            // Переводим запросы в объекты представления данных
            requestsData = requests.Select(requests => new AirRequestData(requests)).ToList();
            requestsData = requestsData.OrderByDescending(r => r.Status).ToList();

            runwaysData = runwayToData(dispatcher.runways);
            
            CurrentSimulationTime += delta;
            dispatcher.UpdateTime(delta);

            // Обрабатывает запросы и обновляет их
            dispatcher.Dispatch(requests);
        }

        private List<RunwayData> runwayToData(List<Runway> runways) // Список данных для отображения/анализа состояния полос взлёта и посадки в системе симуляции аэропорта
        {
            List<RunwayData> runwaysData = new List<RunwayData>();

            foreach (Runway runway in runways)
            {
                RunwayData data = new RunwayData();
                data.Id = runway.Id;
                data.Route =  (runway.Route != null) ? runway.Route.ToString() : "";
                data.Status = runway.IsRunwayAvailable() ? "Доступна" : "Занята";
                
                double takeoffsAndLandsCount = (runway.GetTakeoffRequestsCount() + runway.GetLandRequestsCount());
                
                double landPercentageDouble = (takeoffsAndLandsCount == 0) ? 0 : (double)runway.GetLandRequestsCount() / takeoffsAndLandsCount;
                data.LandPercentage = landPercentageDouble.ToString();
                double TakeOffPercentageDouble = (takeoffsAndLandsCount == 0) ? 0 : (double)runway.GetTakeoffRequestsCount() / takeoffsAndLandsCount;
                data.TakeOffPercentage = TakeOffPercentageDouble.ToString();

                runwaysData.Add(data);
            }

            return runwaysData;
        }

        public AirStat GetStats() // Возвращает статистику о состоянии полос и запросов
        {
            return new AirStat(dispatcher.runways, requests);
        }
    }
}