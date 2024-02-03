using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Aviasales
{
    internal class RoutesAndAirportsGenerator // Класс загрузки списка аэропортов и расписания авиарейсов
    {
        static List<Airport> GenerateAirportsFromJson(string jsonFilePath) // Загружает список аэропортов из файла JSON
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                List<Airport> airports = JsonConvert.DeserializeObject<List<Airport>>(json);
                return airports;
            }
            catch
            {
                string msg = "Невозможно открыть файл с настройками аэропортов " + jsonFilePath + ". Файл не существует или имеет некорректный формат.";
                MessageBox.Show(msg, "Ошибка загрузки файла с настройками аэропортов.", MessageBoxButtons.OK);
                Application.Exit();
            }

            return null;
        }

        public static List<AirRoute> LoadFlightsFromJson(string jsonFilePath) // Загружает расписание авиарейсов из файла JSON
        {
            List<AirRoute> flights = new List<AirRoute>();
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                flights = JsonConvert.DeserializeObject<List<AirRoute>>(json);
            }
            catch
            {
                string msg = "Невозможно открыть файл с расписанием авиарейсов " + jsonFilePath + ". Файл не существует или имеет некорректный формат.";
                MessageBox.Show(msg, "Ошибка загрузки файла с расписанием авиарейсов.", MessageBoxButtons.OK);
                Application.Exit();
            }

            return flights.OrderBy(f => f.DepartureTime).ToList();
        }
    }

    public class RoutesSchedule // Класс расписания авиарейсов
    {
        List<AirRoute> routes; // Список маршрутов авиарейсов
        private string flightsJsonPath = "Flight schedule.json"; // Название и расширение файла с расписанием авиарейсов

        public RoutesSchedule() // Конструктор загрузки расписания авиарейсов
        {
            routes = new List<AirRoute>();

            // Загрузим расписание из JSON файла
            foreach (var route in RoutesAndAirportsGenerator.LoadFlightsFromJson(flightsJsonPath))
            {
                routes.Add(route);
            }
        }

        public List<AirRoute> GetRoutes() // Возвращает список маршрутов авиарейсов
        {
            return routes;
        }
    }
}