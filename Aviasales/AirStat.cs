using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviasales
{
    public class RunwayStat // Класс статистики о работе полос взлёта и посадки
    {
        public int Id { get; set; } // Идентификатор полосы
        public int TakeoffCount { get; set; } // Количество запросов на взлёт
        public int LandCount { get; set; } // Количество запросов на посадку
        public double TakeoffPercentage { get; set; } // Процентное соотношение запросов на взлёт относительно общего числа запросов на данной полосе
        public double LandPercentage { get; set; } // Процентное соотношение запросов на посадку относительно общего числа запросов на данной полосе

        public RunwayStat(Runway runway) // Конструктор
        { 
            Id = runway.Id;
            TakeoffCount = runway.GetTakeoffRequestsCount();
            LandCount = runway.GetLandRequestsCount();
            int sum = TakeoffCount + LandCount;
            if (sum != 0)
            {
                TakeoffPercentage = (double)TakeoffCount / sum;
                LandPercentage = (double)LandCount / sum;
            }
        }
    }
    public class AirStat // Класс общей статистики по обработке запросов в аэропорте
    {
        public int HandledRequests { get; set; } // Количество обработанных запросов, у которых статус равен true
        public int MaxDefer { get; set; } // Максимальное количество отложенных запросов среди всех запросов
        public double AvgDefer { get; set; } // Среднее количество отложенных запросов по всем запросам

        public List<RunwayStat> RunwayStats; // Список статистики по каждой полосе взлёта/посадки
        public AirStat(List<Runway> runways, List<AirportRequest> requests) // Конструктор принимает списки объектов Runway(полосы) и AirportRequest(запросы) и собирает статистику
        {
            RunwayStats = runways.Select(r => new RunwayStat(r)).ToList();
            HandledRequests = requests.Count(r => r.GetStatus());
            MaxDefer = requests.OrderByDescending(r => r.GetDefersCount()).First().GetDefersCount();
            int max = 0;
            foreach (var r in requests)
            { 
                max = Math.Max(max, r.GetDefersCount());
            }
            Console.WriteLine("Максимальное количество отложенных запросов " + max);
            AvgDefer = requests.Average(r => r.GetDefersCount());
        }
    }
}