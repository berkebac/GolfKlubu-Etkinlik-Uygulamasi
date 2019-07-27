using System;
using System.Collections.Generic;
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
    /// Interaction logic for KlupBölümleriListesi.xaml
    /// </summary>
    public partial class KlupBölümleriListesi : Page
    {
        public KlupBölümleriListesi()
        {
            InitializeComponent();
            dgListele.ItemsSource=Veri.TabloGetir("SELECT * FROM [KlupBölümleri] kb INNER JOIN GolfKlupleri gk ON kb.KlupID=gk.Id");
        }
    }
}
