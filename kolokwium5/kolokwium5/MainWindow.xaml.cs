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

namespace kolokwium5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MojStos<string> stos = new MojStos<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            stos.DodajNaGore("Jeden");
            stos.DodajNaGore("Dwa");
            stos.DodajNaGore("Trzy");
            stos.DodajNaGore("Cztery");
            stos.DodajNaGore("Pięć");
        }

        private void btnZdejmij_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string element = stos.ZdejmijZGory();
                lista.Items.Add(element);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}