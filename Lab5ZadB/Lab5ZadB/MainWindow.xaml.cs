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

namespace Lab5ZadB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Towar> towary;
        public MainWindow()
        {
            InitializeComponent();
            towary = new List<Towar>
            {
            new Towar { Nazwa = "Wioskowy wieprzek", Cena = 3500, Ilosc = 10, Kategoria = KategoriaTowaru.Elektronika },
            new Towar { Nazwa = "Mysz", Cena = 80, Ilosc = 25, Kategoria = KategoriaTowaru.Elektronika },
            new Towar { Nazwa = "Klawiatura", Cena = 150, Ilosc = 15, Kategoria = KategoriaTowaru.Elektronika },
            new Towar { Nazwa = "Chleb", Cena = 4, Ilosc = 30, Kategoria = KategoriaTowaru.Spożywcze },
            new Towar { Nazwa = "Mleko", Cena = 35, Ilosc = 20, Kategoria = KategoriaTowaru.Spożywcze },
            new Towar { Nazwa = "Masło", Cena = 7, Ilosc = 12, Kategoria = KategoriaTowaru.Spożywcze },
            new Towar { Nazwa = "Proszek", Cena = 25, Ilosc = 4, Kategoria = KategoriaTowaru.Chemia },
            new Towar { Nazwa = "Szampon", Cena = 18, Ilosc = 5, Kategoria = KategoriaTowaru.Chemia },
            new Towar { Nazwa = "Tablet", Cena = 1200, Ilosc = 6, Kategoria = KategoriaTowaru.Elektronika },
            new Towar { Nazwa = "Ser", Cena = 12, Ilosc = 8, Kategoria = KategoriaTowaru.Spożywcze }
            };
        }

        private void bntPrzycisk1_Click(object sender, RoutedEventArgs e)
        {
            var wynik = towary.Where(t => t.Ilosc > 5).OrderByDescending(t => t.Ilosc);
            listWynik.ItemsSource = wynik.Select(t => t.ToString());
        }

        private void bntPrzycisk2_Click(object sender, RoutedEventArgs e)
        {
            var liczba = towary.Count(t => t.Kategoria == KategoriaTowaru.Spożywcze);
            listWynik.ItemsSource = new[] { $"Liczba towarow spożywczych:{liczba}" };
        }

        private void bntPrzycisk3_Click(object sender, RoutedEventArgs e)
        {
            var srednia = towary.Average(t => t.Cena);
            var wyniki = towary.Where(t => t.Cena > srednia).Select(t => $"{t.Nazwa} - {t.Cena:f2}");

            listWynik.ItemsSource = wyniki;
        }

        private void bntPrzycisk4_Click(object sender, RoutedEventArgs e)
        {
            var wynik = towary.GroupBy(t => t.Kategoria).Select(g => $"{g.Key}: Ilość = {g.Sum(t => t.Ilosc)}," +
            $"średnia cena = {g.Average(t => t.Cena):f2}");
            listWynik.ItemsSource = wynik;
        }

        private void bntPrzycisk5_Click(object sender, RoutedEventArgs e)
        {
            var najdrozszy = towary.OrderByDescending(t => t.Cena).First();
            listWynik.ItemsSource = new[] { $"Najdroższy: {najdrozszy.Nazwa} - {najdrozszy.Cena:f2}" };
        }

        private void btnMinMax_Click(object sender, RoutedEventArgs e)
        {
            var (min, max) = towary.MinMax(t => t.Ilosc);
            listWynik.ItemsSource = new[] { $"Min ilość: {min}, Max ilość: {max}" };
        }

        private void bntZakresCen_Click(object sender, RoutedEventArgs e)
        {
            Towar[] tabTowarow = towary.ToArray();
            var (min, max) = tabTowarow.MinMax(t => t.Cena);
            listWynik.ItemsSource = new[] {$"Min cena: {min:f2}, Max cena: {max:f2}"};
        }

        private void btnString_Click(object sender, RoutedEventArgs e)
        {
            string[] napisy = { "Ananas", "Zebra", "Kot", "Dom", "Chmura" };
            var (min, max) = napisy.MinMax(s => s);
            listWynik.ItemsSource = new[] {$"Min: {min}, Max: {max}"};
        }
    }
}