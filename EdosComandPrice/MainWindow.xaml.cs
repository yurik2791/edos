using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace EdosComandPrice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool FirstOpen;
        public MainWindow()
        {
            InitializeComponent();
            textBoxPrice.Focus();
            FirstOpen = true;
            TextBoxDiscount.Text = "39";
        }

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            const int curs = 28;
            string stringPrice = textBoxPrice.Text;
            stringPrice = stringPrice.Replace(',', '.');
            float floatPrice = float.Parse(stringPrice, CultureInfo.InvariantCulture.NumberFormat);
            float discount = (floatPrice * float.Parse(TextBoxDiscount.Text)) / 100;
            float result = (floatPrice - discount) * curs * (float)1.8;
            labelSummary.Content = result.ToString("F");
            if (FirstOpen)
            {
                richTextBox.AppendText($"Цена запчасти: {stringPrice} || Цена доставки: {result:F}");
                FirstOpen = false;
            }
            else
            {
                richTextBox.AppendText(Environment.NewLine +
                                       $"Цена запчасти: {stringPrice} || Цена доставки: {result:F}");
            }
        }

        private void buttonCalculate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonCalculate_Click(null, null);
                textBoxPrice.Text = "";
            }
        }
    }
}
