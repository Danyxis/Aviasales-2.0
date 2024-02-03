using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Aviasales
{
    public partial class ConfigForm : Form // Форма пользовательского интерфейса, позволяющая пользователю задавать параметры конфигурации для моделирования работы аэропорта
    {
        public ConfigForm() // Инициализирует компоненты формы, устанавливает правила валидации, пытается загрузить конфигурацию из файла при создании экземпляра этой формы
        {
            InitializeComponent();
            SetValidation();
            TryLoadConfing();
        }

        private void SetValidation() // Устанавливает валидации для определённых MaskedTextBox элементов формы
        {
            DerivationToMaskedTextBox.Validating += ValidatePositiveInteger;
            RunwaysCountMaskedTextBox.Validating += ValidatePositiveInteger;
            SimulationCoefficientMaskedTextBox.Validating += ValidatePositiveInteger;
        }

        private void ValidatePositiveInteger(object sender, CancelEventArgs e) // Валидация положительных целых чисел
        {
            var maskedTextBox = (MaskedTextBox)sender;
            int x;
            if (int.TryParse(maskedTextBox.Text, out x) && x > 0)
            {
                return;
            }

            e.Cancel = true;
            MessageBox.Show("Пареметры симуляции должны быть представлены положительными целыми числами!", "Некорректный ввод", MessageBoxButtons.OK);
        }

        // Обработчики событий Validating для RunwaysCountMaskedTextBox и DerivationToMaskedTextBox
        // (Реализация этих методов не предоставлена, поэтому они просто выбрасывают исключение NotImplemented)
        private void RunwaysCountMaskedTextBox_Validating(object sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DerivationToMaskedTextBox_Validating(object sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        // Пустые обработчики событий клика по меткам на форме
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RunSimulationButton_Click(object sender, EventArgs e) // Запуск моделирования работы аэропорта
        {
            SimulationConfig config = new SimulationConfig();
            try
            {
                config.SimulationCoefficient = Int32.Parse(this.SimulationCoefficientMaskedTextBox.Text);
                config.Derivation = Int32.Parse(this.DerivationToMaskedTextBox.Text);
                config.RunwaysCount = Int32.Parse(this.RunwaysCountMaskedTextBox.Text);
                config.StartDateTime = this.startTimePicker.Value;
                // Сериализация объекта в JSON строку
                string json = JsonConvert.SerializeObject(config, Formatting.Indented);

                // Сохранение JSON строки в файл
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Сохранение настроек симуляции в файл";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, json);
                    MessageBox.Show("Конфигурация сохранена в файл!");
                }
            }
            catch
            {
                // Задаём значения по умолчанию
                this.RunwaysCountMaskedTextBox.Text = config.RunwaysCount.ToString();
                this.SimulationCoefficientMaskedTextBox.Text = config.SimulationCoefficient.ToString();
                this.startTimePicker.Value = config.StartDateTime;
            }

            Console.WriteLine("Время начала конфигурации: " + config.StartDateTime.ToString());
            SimulationMainForm form = new SimulationMainForm(config);
            form.ShowDialog();
            // Close();
        }

        private SimulationConfig DeserializeConfigFromFile(string filePath) // Считывание содержимого JSON файла, его десериализация
        {
            try
            {
                // Чтение JSON из файла
                string json = File.ReadAllText(filePath);

                // Десериализация JSON в объект
                SimulationConfig deserializedConfig = JsonConvert.DeserializeObject<SimulationConfig>(json);

                return deserializedConfig;
            }
            catch
            {
                MessageBox.Show($"Ошибка при десериализации файла конфигурации!");
                return null;
            }
        }

        private void TryLoadConfing() // Метод попытки загрузки конфигурации моделирования (симуляции) работы аэропорта из выбранного файла
        {
            // Загрузка конфигурации через OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.Title = "Установка файла конфигурации симуляции";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SimulationConfig loadedConfig = DeserializeConfigFromFile(openFileDialog.FileName);

                if (loadedConfig != null)
                {
                    this.DerivationToMaskedTextBox.Text = loadedConfig.Derivation.ToString();
                    this.RunwaysCountMaskedTextBox.Text = loadedConfig.RunwaysCount.ToString();
                    this.SimulationCoefficientMaskedTextBox.Text = loadedConfig.SimulationCoefficient.ToString();
                    this.startTimePicker.Value = loadedConfig.StartDateTime;
                }
                else
                {
                    var res = MessageBox.Show("При загрузке файла конфигурации произошла ошибка. Перейти к ручной настройке симуляции?", "Ошибка загрузки файла конфигруации", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.Cancel)
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        // Пустые обработчики событий
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void SimulationCoefficientMaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void startTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }

    public class SimulationConfig // Класс хранения конфигурационных данных для симуляции
    {
        public SimulationConfig() 
        {
            RequestsCount = 100; // Количество запросов
            SimulationCoefficient = 300; // Коэффициент симуляции
            StartDateTime = DateTime.Now; // Начальная и конечная даты симуляции
            FinishDateTime = DateTime.Now.AddDays(5);
            Derivation = 30; // Временное отклонение
            RunwaysCount = 10; // Количество полос
        }
        public int RequestsCount { get; set; } // Свойства полей
        public int SimulationCoefficient { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public int Derivation { get; set; }
        public int RunwaysCount { get; set; }
    }
}