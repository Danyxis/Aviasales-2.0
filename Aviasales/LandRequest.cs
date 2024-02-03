using System;

namespace Aviasales
{
    internal class LandRequest : AirportRequest // Класс запроса на посадку в системе аэропорта
    {
        private AirRoute route; // Маршрут
        public int DefersCount { get; set; } // Отложенные запросы
        private bool Status { get; set; } // Текущий статус запроса

        public LandRequest(AirRoute route) // Конструктор
        {
            this.route = route;
            Status = false;
            DefersCount = 0;
        }

        public AirportRequest Defer() // Счётчик отложенных запросов на посадку
        {
            DefersCount++;
            return this;
        }

        public bool GetStatus() // Возвращает текущий статус запроса
        {
            return Status;
        }

        public AirportRequest Process() // Обрабатывает запрос на посадку
        {
            Status = true;
            return this;
        }

        public AirRoute GetAirRoute() // Возвращает маршрут запроса на посадку
        {
            return route;
        }

        public int GetDefersCount() // Возвращает количество отложенных запросов на посадку 
        {
            return DefersCount;
        }

        public DateTime GetCriticalDateTime() // Возвращает критическое время прибытия
        {
            return route.ArriveTime;
        }

        public double GetWorkTimeInMinutes() // Возвращает расход времени на посадку
        {
            return 15;
        }
    }
}