using System;

namespace Aviasales
{
    public class TakeoffRequest : AirportRequest // Класс запроса на взлёт в системе аэропорта
    {
        private AirRoute route; // Маршрут
        public int DefersCount { get; set; } // Отложенные запросы
        private bool Status { get; set; } // Текущий статус запроса

        public TakeoffRequest(AirRoute route) // Конструктор
        {
            this.route = route;
            DefersCount = 0;
        }

        public AirportRequest Defer() // Счётчик отложенных запросов на взлёт
        {
            DefersCount++;
            return this;
        }

        public bool GetStatus() // Возвращает текущий статус запроса
        {
            return Status;
        }

        public AirportRequest Process() // Обрабатывает запрос на взлёт
        {
            Status = true;
            return this;
        }

        public AirRoute GetAirRoute() // Возвращает маршрут запроса на взлёт
        {
            return route;
        }

        public int GetDefersCount() // Возвращает количество отложенных запросов на взлёт
        {
            return DefersCount;
        }

        public DateTime GetCriticalDateTime() // Возвращает критическое время отправления
        {
            return route.DepartureTime;
        }

        public double GetWorkTimeInMinutes() // Возвращает расход времени на взлёт
        {
            return 10;
        }
    }
}