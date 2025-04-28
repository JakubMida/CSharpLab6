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

namespace KolosGrupaC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Produkt[] tab;
        public MainWindow()
        {
            InitializeComponent();
            tab = new Produkt[]
            {
                new Produkt { Nazwa = "Piwo", Cena = 5.99M, Kategoria = "Napoj" },
                new Produkt { Nazwa = "Cola", Cena = 7.50M, Kategoria = "Napoj" },
                new Produkt { Nazwa = "Bluza", Cena = 150.0M, Kategoria = "Odzież" },
                new Produkt { Nazwa = "Spodnie", Cena = 199.99M, Kategoria = "Odzież" },
                new Produkt { Nazwa = "Frytki", Cena = 9.99M, Kategoria = "Jedzenie" },
                new Produkt { Nazwa = "Zupa", Cena = 14.50M, Kategoria = "Jedzenie" }
            };
        }

        private void btnProdukt_Click(object sender, RoutedEventArgs e)
        {
            listProdukt.Items.Clear();
            var wynik = tab.GroupBy(p => p.Kategoria).Select(g => new
            {
                Kategoria = g.Key,
                SredniaCena = g.Average(p => p.Cena),
                IloscItemow = g.Count()
            });

            foreach ( var w in wynik )
            {
                listProdukt.Items.Add($"{w.Kategoria} - średnia cena = {w.SredniaCena:f2}," +
                    $" ilość: {w.IloscItemow}");
            }
        }
    }
}