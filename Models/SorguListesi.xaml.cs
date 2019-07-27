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
    /// Interaction logic for SorguListesi.xaml
    /// </summary>
    public partial class SorguListesi : Page
    {
        public SorguListesi()
        {
            InitializeComponent();
            
        }

        private void cmbsorgu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbsorgu.SelectedIndex==0)
            {
                dgList.ItemsSource = Veri.TabloGetir("SELECT * FROM [GolfKlupleri] WHERE KulupAdı LIKE 'K%' ");
            }

            if (cmbsorgu.SelectedIndex == 1)
            {
                dgList.ItemsSource = Veri.TabloGetir("SELECT KulupAdı,Kapasite,CONCAT(Ad,' ',Soyad) AS [Adı Soyadı],DoğumTarihi FROM [GolfKlupleri] gk INNER JOIN Çalışanlar c ON gk.Id=c.KlupID WHERE gk.Kapasite>=400 ");
            }

            if (cmbsorgu.SelectedIndex == 2)
            {
                dgList.ItemsSource = Veri.TabloGetir("SELECT KulupAdı,Fax,CONCAT(Ad,' ',Soyad) AS [Adı Soyadı],KayıtTarihi FROM [GolfKlupleri] gk INNER JOIN Üyeler u ON gk.Id=u.KlupID WHERE gk.Fax!='NULL' ");
            }

            if (cmbsorgu.SelectedIndex == 3)
            {
                dgList.ItemsSource = Veri.TabloGetir("SELECT BölümAdı,EtkinlikTarihi,a.YaşSınırı FROM [Aktiviteler] a INNER JOIN [KlupBölümleri] kb ON kb.Id=a.AktiviteBölümID WHERE a.YaşSınırı=18 ");
            }
        }
    }
}
