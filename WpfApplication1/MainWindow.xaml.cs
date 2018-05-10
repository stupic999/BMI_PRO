using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HeightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double HeightValue = Math.Round(HeightSlider.Value, 1);
            HeightNumber.Text = HeightValue.ToString();

            // Move TextBlock position
            double moveHeight =(HeightValue/200)*255;
            Canvas.SetLeft(Height, moveHeight);
            ResultShow();
        }

        private void WeightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double WeightValue = Math.Round(WeightSlider.Value, 1);
            WeightNumber.Text = WeightValue.ToString();

            // Move TextBlock
            double moveWeight =(WeightValue/200)*255;
            Canvas.SetLeft(Weight, moveWeight);
            ResultShow();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Sexual.Text = "先生,你的";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Sexual.Text = "女士,你的";
        }

        void ResultShow()
        {
            double h = double.Parse(HeightNumber.Text);
            double w = double.Parse(WeightNumber.Text);
            double BMI = w / Math.Pow((h / 100), 2);
            if (BMI < 18.5)
            {
                {
                    result.Text = "體重過輕,你的BMI數值是";
                }
            }
            else if (BMI >= 18.5 && BMI < 24)
            {
                result.Text = "恭喜你,非常正常^^,你的BMI數值是";
            }
            else if (BMI >= 24 && BMI < 27)
            {
                result.Text = "你有點過重哦,你的BMI數值是";
            }
            else if (BMI >= 27 && BMI < 30)
            {
                result.Text = "輕度肥胖,你的BMI數值是";
            }
            else if (BMI >= 30 && BMI < 35)
            {
                result.Text = "中度肥胖,你的BMI數值是";
            }
            else
            {
                result.Text = "重度肥胖,你的BMI數值是";
            }

            //  Split
            string[] parts = Math.Round(BMI, 1).ToString().Split('.');
            BmiNumber1.Text = parts[0].ToString();
            if (parts.Length == 2)
            {
                BmiNumber2.Text = "." + parts[1].ToString();
            }
            else
            {
                BmiNumber2.Text = ".0";
            }
        }
    }
}
