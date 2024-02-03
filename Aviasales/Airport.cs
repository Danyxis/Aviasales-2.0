using System;

namespace Aviasales
{
    public class Airport : IComparable<Airport>, IEquatable<Airport> // Класс Аэропорт, интерфейсы
    {
        private string name; // Название аэропорта

        public Airport(string name) // Конструктор класса
        {
            this.Name = name;
        }

        public string Name { get => name; set => name = value; } // Свойство

        public int CompareTo(Airport other) // Сравнение по названию (IComparable<Airport>)
        {
            return Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj) // Является ли переданный объект типа Airport
        {
            return Equals(obj as Airport);
        }

        public bool Equals(Airport other) // Равенство 2-х аэропортов по их названию (IEquatable<Airport>)
        {
            return other != null && this.Name.Equals(other.Name);
        }

        public override int GetHashCode() // Переопределения методов
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}