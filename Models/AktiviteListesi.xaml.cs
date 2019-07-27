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
    /// Interaction logic for AktiviteListesi.xaml
    /// </summary>
    public partial class AktiviteListesi : Page
    {
        public AktiviteListesi()
        {
            InitializeComponent();
            dgListele.ItemsSource = Veri.TabloGetir("SELECT * FROM [Aktiviteler] a INNER JOIN GolfKlupleri gk ON a.KlupID=gk.Id INNER JOIN KlupBölümleri kb ON a.AktiviteBölümID=kb.Id");

        }
    }
}
