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


namespace Lab6zadAWDomu
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

        private void btnFunkcja1_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                double FunkcjaRosenbrocka(double x, double y)
                {
                    return Math.Pow((1 - x), 2) + 100 * Math.Pow((y - Math.Pow(x, 2)), 2);
                }

                var wynikFunkcji = Funkcja.ZnajdzMinimumFunkcji2D(-2, 2, -1, 3, 10000000, FunkcjaRosenbrocka);
                lblX.Content = $"x = {wynikFunkcji.x:f4}";
                lblY.Content = $"y = {wynikFunkcji.y:f4}";
                lblWartosc.Content = $"f(x,y) = {wynikFunkcji.wartosc:f10}";

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCzysc_Click(object sender, RoutedEventArgs e)
        {
            lblX.Content = "";
            lblY.Content = "";
            lblWartosc.Content = "";
        }

        private void btnFunkcja2_Click(object sender, RoutedEventArgs e)
        {
            var wynik = Funkcja.ZnajdzMinimumFunkcji2D(-10, 10, -10, 10, 10000000,
                (x, y) => Math.Pow((x - 4), 2) + Math.Pow((y + 2), 2));
            lblX.Content = $"x = {wynik.x:f4}";
            lblY.Content = $"y = {wynik.y:f4}";
            lblWartosc.Content = $"f(x,y) = {wynik.wartosc:f10}";
        }
    }
}