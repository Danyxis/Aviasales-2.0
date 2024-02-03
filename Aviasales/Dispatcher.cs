using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviasales
{
    public class Dispatcher
    {
        private DateTime currentTime; // Текущее время

        public List<Runway> runways = new List<Runway>(); // Список информации о полосах взлёта и посадки
        public Dispatcher(DateTime startTime, int runwaysAmount) // Конструктор
        {
            currentTime = startTime;

            for (int i = 0; i < runwaysAmount; i++)
            {
                runways.Add(new Runway(startTime));
            }
        }

        public void UpdateTime(TimeSpan delta) // Обновляет время для каждой полосы
        {
            currentTime += delta;
            foreach (var runway in runways) 
            {
                runway.UpdateTime(delta);
            }
        }

        public List<AirportRequest> Dispatch(List<AirportRequest> requests) // Обрабатывает переданный список запросов и возвращает его обратно после обработки
        {
            for (int i = 0; i < requests.Count(); i++) 
            {
                if (!requests[i].GetStatus())
                {
                    Runway runway = FindRunway(requests[i]);

                    if (runway != null && runway.IsRunwayAvailable())
                    {
                        runway.Occupy(requests[i]);
                        requests[i].Process();
                    }
                    else
                    {
                        if (requests[i] is TakeoffRequest && requests[i].GetAirRoute().DepartureTime < currentTime)
                        {
                            requests[i].Defer();
                        }
                        if (requests[i] is LandRequest && requests[i].GetAirRoute().ArriveTime < currentTime)
                        {
                            requests[i].Defer();
                        }
                    }
                }
            }

            return requests;
        }

        private Runway FindRunway(AirportRequest req) // Метод поиска полосы для взлёта или посадки
        {
            if (req is TakeoffRequest)
            {
                return FindRunwayForTakeoff();
            }
            else if (req is LandRequest)
            {
                return FindRunwayForLand();
            }
            else {
                return null;
            }
        }

        private Runway FindRunwayForTakeoff() // Метод поиска полосы для взлёта
        {
            // Фильтруем доступные полосы
            var availableRunways = runways.Where(r => r.IsRunwayAvailable()).ToList();

            if (availableRunways.Count == 0)
            {
                    return null;
            }

            // Находим полосу с наибольшим соотношением взлётов к сумме посадок и взлётов
            var bestRunway = availableRunways.OrderByDescending(r => (double)r.GetTakeoffRequestsCount() / (r.GetLandRequestsCount() + r.GetTakeoffRequestsCount())).First();

            return bestRunway;
        }

        private Runway FindRunwayForLand() // Метод поиска полосы для посадки
        {
            // Фильтруем доступные полосы
            var availableRunways = runways.Where(r => r.IsRunwayAvailable()).ToList();

            if (availableRunways.Count == 0)
            {
                return null;
            }

            // Находим полосу с наибольшим соотношением посадок к сумме посадок и взлётов
            var bestRunway = availableRunways.OrderByDescending(r => (double)r.GetLandRequestsCount() / (r.GetLandRequestsCount() + r.GetTakeoffRequestsCount())).First();

            return bestRunway;
        }
    }
}