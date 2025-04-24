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

namespace Lab6ZadA
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

        public static (double x, double y, double w) ZnajdzMinimumFunkcji2D(double minX, double maxX,
                                                                            double minY, double maxY,
                                                                            long liczbaIteracji,
                                                                            Func<double, double, double> funkcja)
        {
            Random rnd = new Random();
            double? najlepszyX = null;
            double? najlepszyY = null;
            double? najlepszaWartosc = double.MaxValue;

            if (liczbaIteracji <= 0)
            {
                throw new ArgumentException("Liczba iteracji musi być dodatnia!");
            }

            for (long i = 0; i < liczbaIteracji; i++)
            {
                double x = minX + rnd.NextDouble() * (maxX - minX);
                double y = minY + rnd.NextDouble() * (maxY - minY);
                double wartosc = funkcja(x, y);

                if(wartosc < najlepszaWartosc)
                {
                    najlepszaWartosc = wartosc;
                    najlepszyX = x;
                    najlepszyY = y;
                }
            }
            return ((double)najlepszyX, (double)najlepszyY, (double)najlepszaWartosc);
        }

        private void btnFunkcja1_Click(object sender, RoutedEventArgs e)
        {
            double Rosenbrock(double x, double y)
            {
                return Math.Pow(1 - x, 2) + 100 * Math.Pow(y - x * x, 2);
            };

            var wynik = ZnajdzMinimumFunkcji2D(-2, 2, -1, 3, 1000000, Rosenbrock);
            lblX.Content = $"X = {wynik.x:f4}";
            lblY.Content = $"Y = {wynik.y:f4}";
            lblW.Content = $"f(x,y) = {wynik.w:f4}";

        }

        private void btnFunckja2_Click(object sender, RoutedEventArgs e)
        {
            var wynik = ZnajdzMinimumFunkcji2D(-10, 10, -10, 10, 10000,
                (x, y) => Math.Pow((x - 4), 2) + Math.Pow((y + 2), 2) * (y + 2));

            lblX.Content = $"X = {wynik.x:f4}";
            lblY.Content = $"Y = {wynik.y:f4}";
            lblW.Content = $"f(x,y) = {wynik.w:f4}";
        }

        private void btnFunckaja3_Click(object sender, RoutedEventArgs e)
        {
            Func<double, double, double> warunkowa = (x, y) =>
            {
                if (x > -1 && x < 1 && y > -2 && y < 2)
                {
                    return 2 + y * y;
                }
                else
                {
                    return 30;
                }
            };

            var wynik = ZnajdzMinimumFunkcji2D(-5, 5, -5, 5, 1000000, warunkowa);
            lblX.Content = $"X = {wynik.x:f4}";
            lblY.Content = $"Y = {wynik.y:f4}";
            lblW.Content = $"f(x,y) = {wynik.w:f4}";
        }
    }
}