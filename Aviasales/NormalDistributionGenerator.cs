using System;

namespace Aviasales
{
    public class NormalDistributionGenerator // Класс генерации случайных чисел с нормальным распределением
    {
        private static readonly Random random = new Random(); // Объект для генерации случайных чисел

        public double GenerateNumberInRange(double minValue, double maxValue)
        {
            double mean = minValue + (maxValue - minValue) / 2.0;
            double stdDev = (maxValue - minValue) / 6.0; // Пример: стандартное отклонение = (max - min) / 6

            // Используем библиотеку MathNet.Numerics для генерации чисел с нормальным распределением
            var normalDistribution = new MathNet.Numerics.Distributions.Normal(mean, stdDev);

            double randomNumber;

            // Генерируем число до тех пор, пока оно не попадет в заданный интервал
            do
            {
                randomNumber = normalDistribution.Sample();
            } while (randomNumber < minValue || randomNumber > maxValue);

            Console.WriteLine($"Генерировать случайное нормально-распределённое число в [{minValue}, {maxValue}] -> {randomNumber}");
            return randomNumber;
        }
    }
}