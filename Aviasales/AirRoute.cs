using System;
using System.Threading;

namespace Aviasales
{
    public class AirRoute // Класс маршрута авиарейса между аэропортами
    {
        DateTime departureTime; // Время отправления
        DateTime arriveTime; // Время прибытия
        Airport departurePoint; // Аэропорт отправления
        Airport arrivePoint; // Аэропорт прибытия

        public DateTime DepartureTime { get => departureTime; set => departureTime = value; } // Свойства
        public DateTime ArriveTime { get => arriveTime; set => arriveTime = value; }
        public Airport DeparturePoint { get => departurePoint; set => departurePoint = value; }
        public Airport ArrivePoint { get => arrivePoint; set => arrivePoint = value; }

        public AirRoute(Airport from, Airport to, DateTime depTime, DateTime arriveTime) // Конструктор
        {
            this.ArriveTime = arriveTime; // Время прибытия и отправления, Аэропорты прибытия и отправления (to, from)
            this.DepartureTime = depTime;
            this.ArrivePoint = to;
            this.DeparturePoint = from;
        }
        public override string ToString() // Переопределённый метод
        {
            return 
                DeparturePoint.Name + " - "  +   ArrivePoint.Name + " " +
                DepartureTime       + " - "  +   ArriveTime; // Строка названия аэропортов отправления и прибытия, а также время отправления и прибытия
        }
    }
}