using System.Dynamic;

namespace Aviasales
{
    public class AirportRequestFactory // Класс генерирования запросов
    {
        public static AirportRequest Create(AirportRequestType type, AirRoute route) // Метод создания объектов запросов (взлёта или посадки)
        { 
            switch (type) 
            {
                case AirportRequestType.Takeoff: return new TakeoffRequest(route); // Запрос на взлёт
                case AirportRequestType.Land: return new LandRequest(route); // Запрос на посадку
                default: return null;
            }
        }
    }

    public enum AirportRequestType 
    {
        Takeoff = 1, // Взлёт
        Land = 2 // Посадка
    }
}