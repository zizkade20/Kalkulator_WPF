using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp2
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            vysledekLabel.Content = 0;

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;

            string buttonText = button.Content.ToString();

            if (buttonText == "C")
            {
                vysledekLabel.Content = 0;
            }
            else if (buttonText == ".")
            {
                if (vysledekLabel.Content.ToString().Contains("."))
                {

                } else
                {
                    vysledekLabel.Content += buttonText;
                }
            }
            else if (buttonText == "CE")
            {
                if (vysledekLabel.Content.ToString() == "")
                {
                    vysledekLabel.Content = 0;
                } else
                {
                    vysledekLabel.Content = vysledekLabel.Content.ToString().Remove(vysledekLabel.Content.ToString().Length - 1);
                    if (vysledekLabel.Content.ToString() == "")
                    {
                        vysledekLabel.Content = 0;
                    }

                }

            }
            
            else if (buttonText == "=")
            {
                DataTable dt = new DataTable();
                var v = dt.Compute(vysledekLabel.Content.ToString(), "");

                vysledekLabel.Content = v.ToString();
            }
            else
            {
                if (vysledekLabel.Content.ToString() == "0" && buttonText != "+" && buttonText != "-" && buttonText != "*" && buttonText != "/")
                {
                    vysledekLabel.Content = buttonText;

                } else
                {
                    if (buttonText == "+" || buttonText == "-" || buttonText == "*" || buttonText == "/")
                    {
                        if (vysledekLabel.Content.ToString().Contains("+-*/")){
                        
                        } else
                        {
                            vysledekLabel.Content += buttonText;

                        }
                    } else
                    {
                        vysledekLabel.Content += buttonText;

                    }
                    

                }

                
            }
        }

       
    }
}
