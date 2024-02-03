using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aviasales
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // Включает использование визуальных стилей
            Application.SetCompatibleTextRenderingDefault(false); // Устанавливает значение по умолчанию для совместимого отображения текста
            Application.Run(new ConfigForm()); // Запускает приложение с указанием ConfigForm в качестве главной формы
        }
    }
}