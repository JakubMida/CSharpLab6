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

namespace KolosGrupaA
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

        private void btnKula_Click(object sender, RoutedEventArgs e)
        {
            listKula.Items.Clear();
            Kula kula1 = new Kula { Promien = 5.5, Material = "stal" };
            Kula kula2 = new Kula { Promien = 7.0, Material = "drewno" };
            kula1.ZmienPromien(p => p + 2);
            kula2.ZmienPromien(p => p + 1.5);

            listKula.Items.Add($"Masa pierwszej kuli: {kula1.Masa():f2}");
            listKula.Items.Add($"Masa drugiej kuli: {kula2.Masa():f2}");
        }
    }
}