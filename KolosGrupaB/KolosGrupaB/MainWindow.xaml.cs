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

namespace KolosGrupaB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pies> psy;
        public MainWindow()
        {
           
            InitializeComponent();
            psy = new List<Pies>
            {
                new Pies{Imie = "Grzegorz", Wiek = 21, Rasa = "Policjant"},
                new Pies{Imie = "Reksio", Wiek = 7, Rasa = "Owczarek Niemiecki"},
                new Pies{Imie = "Burek", Wiek = 10, Rasa = "Nowy jork"},
                new Pies{Imie = "Michał", Wiek = 12, Rasa = "Policjant"},
                new Pies{Imie = "Stasiu", Wiek = 2, Rasa = "Owczarek Niemiecki"},
                new Pies{Imie = "Turek", Wiek = 5, Rasa = "Nowy jork"},
                new Pies{Imie = "Miki", Wiek = 6, Rasa = "Nowy jork"},
            };
        }

        private void btnPies_Click(object sender, RoutedEventArgs e)
        {
            listPies.Items.Clear();
            var wynik = from p in psy
                        group p by p.Rasa into rasaGroup
                        select new
                        {
                            Rasa = rasaGroup.Key,
                            sredniWiek = rasaGroup.Average(s => s.Wiek),
                            maksWiek = rasaGroup.Max(s => s.Wiek),
                        };
            foreach( var w in wynik)
            {
                listPies.Items.Add($"Rasa: {w.Rasa}, średni wiek: {w.sredniWiek}, max wiek: {w.maksWiek}");
            }
        }
    }
}