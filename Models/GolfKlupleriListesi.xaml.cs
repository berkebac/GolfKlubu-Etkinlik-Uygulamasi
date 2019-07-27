using System;
using System.Collections.Generic;
using System.Data;
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

namespace _56.Models
{
    /// <summary>
    /// Interaction logic for GolfKlupleriListesi.xaml
    /// </summary>
    public partial class GolfKlupleriListesi : Page
    {
        public GolfKlupleriListesi()
        {
            InitializeComponent();
            dgGolfKlupleriListele.ItemsSource = Veri.TabloGetir("SELECT * FROM [GolfKlupleri]");
        }

        private void mig_click(object sender, RoutedEventArgs e)
        {
            if (dgGolfKlupleriListele.SelectedItem == null) return;
            DataRowView seçili = dgGolfKlupleriListele.SelectedItem as DataRowView;
            NavigationService.Navigate(new GolfKKayıt(seçili));
        }
    }
}
