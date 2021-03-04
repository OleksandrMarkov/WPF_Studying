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

using System.Data; // for calculations

namespace Wpf1_calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            //handlers adding
            foreach (UIElement element in Main_grid.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += button_click;
                }
            }
        }

        private void button_click(object sender, RoutedEventArgs e)
        {
            //getting a buttons' labels
            string str = (string)((Button)e.OriginalSource).Content;

            if (str == "Clear")
            {
                text_label.Text = "";
            }
            else if (str == "=")
            {
                // calculations
                try
                {
                    string value = new DataTable().Compute(text_label.Text, null).ToString();
                    text_label.Text = value;
                }
                catch
                {
                    text_label.Text = "There is a mistake in your expression! Clear and retry!";
                }
            }
            else
            {
                text_label.Text += str;
            }
            


        }
    }
}
