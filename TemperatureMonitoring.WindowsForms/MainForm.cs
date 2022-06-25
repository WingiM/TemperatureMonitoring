using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemperatureMonitoring.Core;

namespace TemperatureMonitoring.WindowsForms
{
    public partial class MainForm : Form
    {
        private readonly ITemperatureAnalyzer _analyzer;
        private Product _currentProduct;
        private AnalyzeResult _result;

        public MainForm()
        {
            _analyzer = new TemperatureSensorAnalyzer();
            InitializeComponent();
            lw_Content.Items.Add($"Дата\t\tФакт\tНорма\tРасхождение");
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                FormProduct();
                if (loadFile.ShowDialog() == DialogResult.OK)
                {
                    var res = _analyzer.AnalyzeFromFile(_currentProduct, loadFile.FileName);
                    ShowResult(res);
                }
            }
            catch (FileReadException)
            {
                MessageBox.Show("Cannot load file");
            }
            catch (ValidationException)
            {
                MessageBox.Show("Wrong product data");
            }
        }

        private void FormProduct()
        {
            _currentProduct = new Product
            {
                Name = tb_FishType.Text,
                MaxTemperature = tb_MaxTemp.Text.Length != 0 ? int.Parse(tb_MaxTemp.Text) : Int32.MaxValue,
                MinTemperature = tb_MinTemp.Text.Length != 0 ? int.Parse(tb_MinTemp.Text) : int.MinValue,
                MaxTemperatureTimeToStore =
                    TimeSpan.FromMinutes(int.Parse(tb_MaxTempDuration.Text.Length != 0
                        ? tb_MaxTempDuration.Text
                        : "0")),
                MinTemperatureTimeToStore =
                    TimeSpan.FromMinutes(int.Parse(tb_MinTempDuration.Text.Length != 0 ? tb_MinTempDuration.Text : "0"))
            };
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                FormProduct();
                int[] temps = tb_Temperature.Text.Split().Select(int.Parse).ToArray();
                DateTime date = DateTime.Parse(dateTimePicker.Text);
                var res = _analyzer.AnalyzeFromInput(_currentProduct, date, temps);
                ShowResult(res);
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void ShowResult(AnalyzeResult result)
        {
            _result = result;
            lw_Content.Items.Clear();
            lw_Content.Items.Add($"Дата\t\tФакт\tНорма\tРасхождение");
            foreach (var line in result.Results)
            {
                lw_Content.Items.Add(string.Join('\t', line.Split(';')));
            }

            if (result.MaximumTemperatureStoringTime > result.Product.MaxTemperatureTimeToStore)
                VerdictText.Text =
                    $"Порог максимально допустимой температуры превышен на {result.MaximumTemperatureStoringTime.TotalMinutes} минут";
            if (result.MinimumTemperatureStoringTime > result.Product.MinTemperatureTimeToStore)
                VerdictText.Text =
                    $"Порог минимально допустимой температуры превышен на {(result.MinimumTemperatureStoringTime).TotalMinutes} минут";
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                saveFile.FileName = "report.txt";
                saveFile.Filter = "Text files (*.txt)|*.txt";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    _analyzer.SaveToFile(_result, VerdictText.Text, saveFile.FileName);
                }
            }
            catch (FileReadException)
            {
                MessageBox.Show("Cannot save file");
            }
        }
    }
}