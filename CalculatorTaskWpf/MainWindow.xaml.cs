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

namespace CalculatorTaskWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Double value = 0.0;
        string text = "";
        bool operatorpress = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void NumbersClick(object sender, EventArgs e)
        {
            if ((ResultTxtBox.Text == "0") || (operatorpress))
            {
                ResultTxtBox.Clear();
            }
            operatorpress = false;
            Button button = (Button)sender;
            if (button.Content == ",")
            {
                if (!ResultTxtBox.Text.Contains(","))
                {
                    ResultTxtBox.Text = ResultTxtBox.Text + button.Content;
                }
            }
            else
            {
                ResultTxtBox.Text = ResultTxtBox.Text + button.Content;
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {

            if (ResultTxtBox.Text.Length > 0)
            {
                ResultTxtBox.Text = ResultTxtBox.Text.Remove(ResultTxtBox.Text.Length - 1, 1);
            }
        }

        private void CEBtn_Click(object sender, RoutedEventArgs e)
        {
            ResultTxtBox.Text = "0";

        }

        private void CBtn_Click(object sender, RoutedEventArgs e)
        {
            ResultTxtBox.Text = "0";
            value = 0;
        }
        private void oppress(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (ResultTxtBox.Text.EndsWith("*") || ResultTxtBox.Text.EndsWith("-") || ResultTxtBox.Text.EndsWith("/") || ResultTxtBox.Text.EndsWith("+"))
            {
                return;
            }
            if (value != 0)
            {
                value = double.Parse(ResultTxtBox.Text);

                text = button.Content.ToString();
                ResultTxtBox.Text += text;
                label1.Content = value + " " + text;
                operatorpress = true;
            }
            else
            {
                text = button.Content.ToString();
                value = double.Parse(ResultTxtBox.Text);
                ResultTxtBox.Text += text;
                label1.Content = value + " " + text;
                operatorpress = true;
            }
        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ResultTxtBox.Text.Length <= 7)
                {
                    switch (text)
                    {
                        case "+":
                            {
                                ResultTxtBox.Text = (value + Double.Parse(ResultTxtBox.Text)).ToString();
                                value = 0;

                                break;
                            }
                        case "-":
                            {
                                ResultTxtBox.Text = (value - Double.Parse(ResultTxtBox.Text)).ToString();
                                value = 0;

                                break;
                            }
                        case "/":
                            {
                                if (ResultTxtBox.Text != "0")
                                {
                                    ResultTxtBox.Text = (value / Double.Parse(ResultTxtBox.Text)).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Can not  divide by zero");
                                }
                                value = 0;
                                break;
                            }
                        case "*":
                            {
                                ResultTxtBox.Text = (value * Double.Parse(ResultTxtBox.Text)).ToString();
                                value = 0;

                                break;
                            }
                        default:
                            {


                                break;
                            }
                    }
                    value = double.Parse(ResultTxtBox.Text);
                    label1.Content = "";
                    operatorpress = false;
                }
                else
                {
                    MessageBox.Show("Number is very High");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void MinusPlusBtn_Click(object sender, RoutedEventArgs e)
        {

            if ((double.Parse(ResultTxtBox.Text)) >= 0)
            {
                ResultTxtBox.Text = (System.Math.Abs(double.Parse(ResultTxtBox.Text)) * (-1)).ToString();
            }
            else
            {
                ResultTxtBox.Text = (System.Math.Abs(double.Parse(ResultTxtBox.Text)) * (1)).ToString();

            }
        }
    }
}
