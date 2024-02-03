using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aviasales
{
    public partial class ChooseLocalAirportForm : Form
    {
        public string choosenAirportName = ""; // Хранение выбранного названия аэропорта
        public ChooseLocalAirportForm(IEnumerable<Airport> airports) // Конструктор формы, принимающий список аэропортов для отображения в выпадающем списке
        {
            InitializeComponent();
            foreach(var a in airports)
            {
                comboBox1.Items.Add(a.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Обработчик события для кнопки на форме
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Пустые поля в вводе недопустимы!", "Неверный ввод", MessageBoxButtons.OK);
                return;
            }

            choosenAirportName = comboBox1.Text; // Запись выбранного имени аэропорта в публичное поле
            Close(); // Закрытие формы
        }

        private void ChooseLocalAirportForm_Load(object sender, EventArgs e) // Обработчик события загрузки формы
        {

        }

        private void label1_Click(object sender, EventArgs e) // Обработчик события клика по метке (label) на форме
        {

        }
    }
}