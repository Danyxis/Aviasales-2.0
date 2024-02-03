using System;
using System.Diagnostics;

namespace Aviasales
{
    public interface AirportRequest // Интерфейс запросов взлёта/посадок
    {
        AirportRequest Process(); // Обработка запросов

        bool GetStatus(); // Возвращение состояния запроса

        AirportRequest Defer(); // Отложенный запрос 

        AirRoute GetAirRoute(); // Возвращение маршрута

        int GetDefersCount(); // Кол-во отложенных запросов

        DateTime GetCriticalDateTime(); // Возвращение критического времени прибытия/отправления

        double GetWorkTimeInMinutes(); // Расход времени на непосредственно посадку/взлёт
    }
}