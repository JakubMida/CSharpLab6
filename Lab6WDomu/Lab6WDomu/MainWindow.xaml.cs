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
using Klasy;

namespace Lab6WDomu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Towar> ListaTowarow;
        public MainWindow()
        {
            InitializeComponent();
            ListaTowarow = new List<Towar>
            {
                new Towar { Nazwa = "Laptop", Cena = 4500, Ilość = 10, Kategoria = KategoriaTowaru.Elektronika },
                new Towar { Nazwa = "Smartfon", Cena = 3500.99M, Ilość = 7, Kategoria = KategoriaTowaru.Elektronika },
                new Towar { Nazwa = "Słuchawki", Cena = 300.50M, Ilość = 15, Kategoria = KategoriaTowaru.Elektronika },
                new Towar { Nazwa = "Chleb", Cena = 5, Ilość = 50, Kategoria = KategoriaTowaru.Spożywcze },
                new Towar { Nazwa = "Mleko", Cena = 3, Ilość = 30, Kategoria = KategoriaTowaru.Spożywcze },
                new Towar { Nazwa = "Czekolada", Cena = 8, Ilość = 20, Kategoria = KategoriaTowaru.Spożywcze },
                new Towar { Nazwa = "Koszula", Cena = 120, Ilość = 12, Kategoria = KategoriaTowaru.Odzież },
                new Towar { Nazwa = "Spodnie", Cena = 200, Ilość = 8, Kategoria = KategoriaTowaru.Odzież },
                new Towar { Nazwa = "Kurtka", Cena = 400, Ilość = 5, Kategoria = KategoriaTowaru.Odzież },
                new Towar { Nazwa = "Buty", Cena = 350, Ilość = 6, Kategoria = KategoriaTowaru.Odzież }
            };
        }

        private void btnZad1_Click(object sender, RoutedEventArgs e)
        {
            var wynik = ListaTowarow.Where(t => t.Ilość > 5).OrderByDescending(t => t.Ilość);
            listaWynikow.ItemsSource = wynik;
        }

        private void btnZad2_Click(object sender, RoutedEventArgs e)
        {
            KategoriaTowaru? kategoria = null;
            switch (cbxKategoria.SelectedIndex)
            {
                case 0: kategoria = KategoriaTowaru.Elektronika; break;
                case 1: kategoria = KategoriaTowaru.Spożywcze; break;
                case 2: kategoria = KategoriaTowaru.Odzież; break;
            }

            var wynik = ListaTowarow.Count(t => t.Kategoria == kategoria);
            listaWynikow.ItemsSource = new List<string> { $"Liczba towarów {kategoria} = {wynik}" };
        }

        private void btnZad3_Click(object sender, RoutedEventArgs e)
        {
            decimal srednia = ListaTowarow.Average(t => t.Cena);
            var wynik = ListaTowarow.Where(t => t.Cena > srednia).Select(t => $"{t.Nazwa}, Cena: {t.Cena:f2}");
            listaWynikow.ItemsSource = wynik;
        }

        private void btnZad4_Click(object sender, RoutedEventArgs e)
        {
            var wynik = ListaTowarow.GroupBy(t => t.Kategoria).Select(g => $"{g.Key}: Ilość: {g.Sum(t => t.Ilość)}," +
            $" średnia cena: {g.Average(t => t.Cena):f2}");
            listaWynikow.ItemsSource = wynik;
        }

        private void btnZad5_Click(object sender, RoutedEventArgs e)
        {
            var wynik = ListaTowarow.OrderByDescending(t => t.Cena).FirstOrDefault();
            listaWynikow.ItemsSource = new[] { $"{wynik.Nazwa}, cena: {wynik.Cena:f2}" };
        }

        private void btnIlosc_Click(object sender, RoutedEventArgs e)
        {
            var (min, max) = ListaTowarow.MinMax(t => t.Ilość);
            listaWynikow.ItemsSource = new[] { $"Minimalna ilość: {min}, maksymalna ilość {max}" };
        }

        private void btnZakresCen_Click(object sender, RoutedEventArgs e)
        {
            var (min, max) = ListaTowarow.MinMax(t => t.Cena);
            listaWynikow.ItemsSource = new[] { $"Minimalna cena: {min}, maksymalna cena: {max}" };
        }

        private void btnZakresStringow_Click(object sender, RoutedEventArgs e)
        {
            string[] tab =
            {
                "Zebra", "Maluch", "Ananas", "ŻonKILL"
            };

            var (min, max) = tab.MinMax(t => t);
            listaWynikow.ItemsSource = new[] { $"Minimalny string: {min}\n" +
                $" maksymalny string: {max}" };
        }

        private void btnDomowe1_Click(object sender, RoutedEventArgs e)
        {
            Towar towar = new Towar
            {
                Nazwa = "Laptok",
                Cena = 5699.59M,
                Ilość = 1,
                Kategoria = KategoriaTowaru.Elektronika
            };

            towar.Wyswietl(dane =>
            {
                MessageBox.Show(dane);
                lblDomowe.Content = dane;
            });

        }

        private void btnDomowe2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double promien = Convert.ToDouble(txtPromień.Text);
                var (Pole, Obwod) = Kolo.ObliczKolo(promien);

                MessageBox.Show($"Dla promienia r = {promien:f2}, pole = {Pole:f2}, obwód = {Obwod:f2}");
            }catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }catch
            {
                MessageBox.Show("Niepoprawny format danych!");
            }
        }
    }
}