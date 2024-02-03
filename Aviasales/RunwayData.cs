namespace Aviasales
{
   public class RunwayData // Класс хранения информации о состоянии взлётно-посадочной полосы
    {
        public int Id { get; set; } // Идентификатор взлётно-посадочной полосы
        public string Status { get; set; } // Статус полосы
        public string Route { get; set; } // Маршрут
        public string TakeOffPercentage { get; set; } // Процент запросов на взлёт относительно общего числа запросов на взлёт и посадку
        public string LandPercentage { get; set; } // Процента запросов на посадку относительно общего числа запросов на взлёт и посадку
    }
}