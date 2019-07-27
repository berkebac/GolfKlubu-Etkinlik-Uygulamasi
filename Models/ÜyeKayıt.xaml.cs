using System;
using System.Collections.Generic;
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
    /// Interaction logic for ÜyeKayıt.xaml
    /// </summary>
    public partial class ÜyeKayıt : Page
    {
        #region Değişkenler
        string sorgu;
        SqlCommand sqlCmd;
        #endregion

        public ÜyeKayıt()
        {
            InitializeComponent();
            cmbklupler.ItemsSource = Veri.TabloGetir("SELECT * FROM [GolfKlupleri]");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sorgu = "INSERT INTO [Üyeler] VALUES (@KlupID, @Ad, @Soyad, @KayıtTarihi, @Şehir, @Adres, @Telefon, @MailAdresi, @Cinsiyet)";
            sqlCmd = new SqlCommand(sorgu, Veri.sqlCon);
            sqlCmd.Parameters.AddWithValue("@KlupID", cmbklupler.SelectedValue);
            sqlCmd.Parameters.AddWithValue("@Ad", tbad.Text);
            sqlCmd.Parameters.AddWithValue("@Soyad", tbsoyad.Text);
            sqlCmd.Parameters.AddWithValue("@KayıtTarihi", dpktarihi.SelectedDate);
            sqlCmd.Parameters.AddWithValue("@Şehir", tbşehir.Text);
            sqlCmd.Parameters.AddWithValue("@Adres", tbadres.Text);
            sqlCmd.Parameters.AddWithValue("@Telefon", tbtel.Text);
            sqlCmd.Parameters.AddWithValue("@MailAdresi", tbmail.Text);
            if(rberkek.IsChecked==true)
                sqlCmd.Parameters.AddWithValue("@Cinsiyet", rberkek.Content);
            else
                sqlCmd.Parameters.AddWithValue("@Cinsiyet", rbkadın.Content);


            try
            {
                Veri.BaglantıyıAç();
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata");
            }
            finally
            {
                Veri.BaglantıyıKapat();

            }
            NavigationService.Navigate(new Uri("Models/ÜyeListesi.xaml", UriKind.Relative));
        }
    }
}
