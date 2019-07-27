using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for AktiviteKayıt.xaml
    /// </summary>
    public partial class AktiviteKayıt : Page
    {
        #region Değişkenler
        string sorgu;
        SqlCommand sqlCmd;
        #endregion

        public AktiviteKayıt()
        {
            InitializeComponent();
            cmbklupler.ItemsSource = Veri.TabloGetir("SELECT * FROM [GolfKlupleri]");
            cmbBölümler.ItemsSource = Veri.TabloGetir("SELECT * FROM [KlupBölümleri]");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            sorgu = "INSERT INTO [Aktiviteler] VALUES (@KlupID, @AktiviteBölümID, @EtkinlikTarihi, @Kapasite, @YaşSınırı)";
            sqlCmd = new SqlCommand(sorgu, Veri.sqlCon);
            sqlCmd.Parameters.AddWithValue("@KlupID", cmbklupler.SelectedValue);
            sqlCmd.Parameters.AddWithValue("@AktiviteBölümID", cmbklupler.SelectedValue);
            sqlCmd.Parameters.AddWithValue("@EtkinlikTarihi", dpetarihi.SelectedDate);
            sqlCmd.Parameters.AddWithValue("@Kapasite", tbkapasite.Text);
            sqlCmd.Parameters.AddWithValue("@YaşSınırı", tbyaş.Text);
            try
            {
                Veri.BaglantıyıAç();
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata");
                throw;
            }
            finally
            {
                Veri.BaglantıyıKapat();

            }
            NavigationService.Navigate(new Uri("Models/AktiviteListesi.xaml", UriKind.Relative));
        }
    }
}
