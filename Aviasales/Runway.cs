using System;

namespace Aviasales
{
    public class Runway // Класс взлётно-посадочной полосы
    {
        public static void ReleaseIds() // Идентификатор взлётно-посадочной полосы, с которого начинается отсчёт
        {
            idStatic = 1;
        }

        private DateTime currentTime; // Текущее время
        private DateTime releaseDateTime; // Время, в течение которого полоса остается занятой (в случае, если она занята)
        private AirRoute route; // Маршрут, который использует полосу в данный момент времени
        public void UpdateTime(TimeSpan delta) // Обновляет состояние времени для взлетно-посадочной полосы
        { 
            currentTime += delta;
            Console.WriteLine(currentTime.ToString());
            if (!IsAvailable) // Проверяет, занята ли взлётно-посадочная полоса
            {
                // Обновляем состояние полосы и снимаем блокировку с неё, если время ожидания вышло
                // TODO: добавить время на сами взлёт и посадку
                Console.WriteLine("Взлётно-посадочная полоса " + Id + " занята на " + releaseDateTime);
                if (releaseDateTime < currentTime) // Проверяет, истекло ли время занятости полосы
                {
                    Console.WriteLine("Взлётно-посадочная полоса " + Id + " обрабатывает маршрут и доступна уже сейчас");
                    // Полоса с идентификатором Id освободилась, теперь доступна для использования
                    route = null;
                    IsAvailable = true;
                }
            }
        }
        public int Id { get; set; } // Свойство идентификатора взлётно-посадочной полосы
        private bool IsAvailable { get; set; } // Свойство для обозначения доступности взлётно-посадочной полосы
        private int LandRequestCount { get; set; } // Свойство для подсчёта количества запросов на посадку на данной полосе
        private int TakeoffRequestCount { get; set; } // Свойство для подсчёта количества запросов на взлёт с данной полосы
        public AirRoute Route { get => route; set => route = value; } // Свойство, содержащее маршрут, связанный с данной взлётно-посадочной полосой

        private static int idStatic = 1; // Статическая переменная для генерации уникального идентификатора полосы
        public Runway(DateTime start) // Конструктор
        {
            currentTime = start;
            Id = idStatic++;
            IsAvailable = true;
            LandRequestCount = 0;
            TakeoffRequestCount = 0;
        }
        public bool IsRunwayAvailable() // Возвращает текущее состояние доступности полосы
        {
            return IsAvailable;
        }

        public int GetLandRequestsCount() // Возвращает количество запросов на посадку, которые были обработаны или запланированы для данной полосы
        { 
            return LandRequestCount;
        }

        public int GetTakeoffRequestsCount() // Возвращает количество запросов на взлет, которые были обработаны или запланированы для данной полосы
        {
            return TakeoffRequestCount;
        }

        public void Occupy(AirportRequest req) // Занимает взлётно-посадочную полосу определённым запросом
        { 
            if (!IsAvailable) // Проверяет, доступна ли взлетно-посадочная полоса
            {
                return;
            }

            Route = req.GetAirRoute(); // Устанавливает маршрут (Route) в соответствии с маршрутом запроса
            IsAvailable = false; // Помечает полосу как занятую
            if (req is TakeoffRequest) 
            {
                // Вычисляет время блокировки для запроса на взлёт
                releaseDateTime = req.GetAirRoute().DepartureTime.AddMinutes(req.GetWorkTimeInMinutes());
                TakeoffRequestCount++; // Увеличивает счётчик запросов на взлёт
            } else if (req is LandRequest) 
            {
                // Вычисляеn время блокировки для запроса на посадку
                releaseDateTime = req.GetAirRoute().ArriveTime.AddMinutes(req.GetWorkTimeInMinutes());
                LandRequestCount++; // Увеличивает счётчик запросов на посадку
            }
        }        
    }
}