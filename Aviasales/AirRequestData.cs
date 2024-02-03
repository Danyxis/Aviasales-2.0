namespace Aviasales
{
    public class AirRequestData // Класс представления данных о запросе в контексте аэропорта
    {
        public AirRequestData(AirportRequest request) // Преобразование объекта запроса в объект данных
        {
            Route = request.GetAirRoute(); // Маршрут запроса
            if (request is TakeoffRequest)
            {
                Type = AirportRequestType.Takeoff; // Взлёт
            }
            else if (request is LandRequest)
            {
                Type = AirportRequestType.Land; // Посадка
            }

            Defers = request.GetDefersCount(); // Отложенные запросы
            Status = request.GetStatus(); // Статус запроса
        }
        public AirRoute Route { get; set; } // Маршрут авиарейса
        public int Defers { get; set; } // Отложенный запрос на взлёт/посадку самолёта
        public AirportRequestType Type { get; set; } // Тип запроса
        public bool Status { get; set; } // Текущий статус запроса
    }
}