using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Aviasales
{
    public class RequestsFlowManager // Класс генерации запросов на основе предоставленных маршрутов авиарейсов
    {
        private NormalDistributionGenerator derivationGenerator; // Экземпляр генератора случайных чисел с нормальным распределением
        private Airport localAirport; // Локальный аэропорт (место симуляции)
        private int derivation; // Переменная для хранения значения отклонения

        // Устанавливает значение отклонения, создает экземпляр генератора случайных чисел с нормальным распределением, устанавливает локальный аэропорт
        public RequestsFlowManager(SimulationConfig config, Airport local) 
        {
            derivation = config.Derivation;
            derivationGenerator = new NormalDistributionGenerator();
            localAirport = local;
        }

        // Генерирует запросы на основе переданных маршрутов и количества запросов на взлёт/посадку, учитывая отклонения времени отправления и прибытия
        public IEnumerable<AirportRequest> GenerateRequests(List<AirRoute> routes)
        {
            List<AirportRequest> requests =  new List<AirportRequest>(); // Список запросов на взлёт/посадку

            for (int i = 0; i < routes.Count; i++)
            {
                AirRoute route = routes[i];
                AirRoute derivatedRoute = route;
                AirportRequestType requestType; 
                requestType = (route.ArrivePoint.Name == localAirport.Name)? AirportRequestType.Land : AirportRequestType.Takeoff;

                // Генерация отклонения прибытия
                DateTime arriveDeviation = route.ArriveTime.AddMinutes(derivationGenerator.GenerateNumberInRange(-derivation / 2, derivation / 2));

                // Генерация отклонения отправления
                DateTime departureDeviation = route.DepartureTime.AddMinutes(derivationGenerator.GenerateNumberInRange(-derivation/2, derivation/ 2));

                derivatedRoute.DepartureTime  = departureDeviation;
                derivatedRoute.ArriveTime = arriveDeviation;
                Console.WriteLine(derivatedRoute.ToString());
                requests.Add(AirportRequestFactory.Create(requestType, derivatedRoute));
            }

            return requests.OrderBy(r => r is TakeoffRequest ? r.GetAirRoute().DepartureTime : r.GetAirRoute().ArriveTime).ToList();
        }
    }
}