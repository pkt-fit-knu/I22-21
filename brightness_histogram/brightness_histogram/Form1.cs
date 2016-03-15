using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace brightness_histogram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int[] bright_r = new int[256];
            int[] bright_g = new int[256];
            int[] bright_b = new int[256];
            Bitmap my_img = (Bitmap)Bitmap.FromFile(@"image.png");
            pictureBox1.Image = my_img;
            int x = 0;
            int y = 0;
            for (x = 0; x < my_img.Width; x++)
            {
                for (y = 0; y < my_img.Height; y++)
                {
                    bright_r[my_img.GetPixel(x, y).R]++;
                    bright_g[my_img.GetPixel(x, y).G]++;
                    bright_b[my_img.GetPixel(x, y).B]++;
                }
            }
            Chart chart;

            // Создаём новый элемент управления Chart
            chart = new Chart();
            // Помещаем его на форму
            chart.Parent = this;

            // Задаём размеры элемента
            chart.SetBounds(0, 0, 500, 250);

            // Создаём новую область для построения графика
            ChartArea area = new ChartArea();
            // Даём ей имя (чтобы потом добавлять графики)
            area.Name = "myGraph";

            // Задаём левую и правую границы оси X
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = 255;

            // Определяем шаг сетки
            area.AxisX.MajorGrid.Interval = 1;

            // Добавляем область в диаграмму
            chart.ChartAreas.Add(area);
            // Создаём объект для первого графика
            Series series1 = new Series();
            series1.Color = Color.Blue;

            // Ссылаемся на область для построения графика
            series1.ChartArea = "myGraph";
            // Задаём тип графика - сплайны
            series1.ChartType = SeriesChartType.Bar;
            // Указываем ширину линии графика
            series1.BorderWidth = 3;
            // Название графика для отображения в легенде
            // Добавляем в список графиков диаграммы
            chart.Series.Add(series1);
            // Аналогичные действия для второго графика
            Series series2 = new Series();
            // Ссылаемся на область для построения графика
            series2.ChartArea = "myGraph";
            // Задаём тип графика - сплайны
            series2.ChartType = SeriesChartType.Bar;
            // Указываем ширину линии графика
            series2.BorderWidth = 3;
            series2.Color = Color.Red;
            // Название графика для отображения в легенде
            // Добавляем в список графиков диаграммы
            chart.Series.Add(series2);
            //
            Series series3 = new Series();
            // Ссылаемся на область для построения графика
            series3.ChartArea = "myGraph";
            // Задаём тип графика - сплайны
            series3.ChartType = SeriesChartType.Bar;
            // Указываем ширину линии графика
            series3.BorderWidth = 3;
            // Название графика для отображения в легенде
            // Добавляем в список графиков диаграммы
            series3.Color = Color.Green;

            chart.Series.Add(series3);
            // Аналогичные действия для второго графика

            int[] h = new int[256];
            for (int i = 0; i < 256; i++)
            {
                h[i] = i;
            }
            chart.Series[0].Points.DataBindXY(h, bright_b);
            chart.Series[1].Points.DataBindXY(h, bright_r);
            chart.Series[2].Points.DataBindXY(h, bright_g);

        }
    }
}
