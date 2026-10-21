using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Integral.Classes;

namespace WPF_Integral
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

        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            DoCalculate();
        }
        private void DoCalculate()
        {
            if (!double.TryParse(tbLower.Text, System.Globalization.CultureInfo.InvariantCulture, out double a) ||
        !double.TryParse(tbUpper.Text, System.Globalization.CultureInfo.InvariantCulture, out double b) ||
        !int.TryParse(tbCount.Text, out int n) || n <= 0 || a <= 0)
            {
                MessageBox.Show("Проверьте ввод: пределы — числа > 0, разбиения — целое > 0.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ICalculator calc = GetCalculator();
            Func<double, double> F = x => 12 * x - Math.Log(11 * x) - 11;
            double result = calc.Intagrate(a, b, n, F);
            tbResult.Text = result.ToString();
        }

        private ICalculator GetCalculator()
        {
            ICalculator calculator = null;
            if (cbMethod.SelectedIndex == 0)
            {
                calculator= new RectangleCalculator();
            }
            else if (cbMethod.SelectedIndex == 1)
            {
                calculator = new TrapezoidCalculator();
            }
            return calculator;
        }
    }
}
