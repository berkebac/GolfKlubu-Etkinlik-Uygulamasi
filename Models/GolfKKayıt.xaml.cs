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
    /// Interaction logic for GolfKKayıt.xaml
    /// </summary>
    public partial class GolfKKayıt : Page
    {
        #region Değişkenler
        string sorgu;
        SqlCommand sqlCmd;
        DataRowView seçiligk;
        #endregion

        public GolfKKayıt()
        {
            InitializeComponent();
        }

        public GolfKKayıt(DataRowView drv)
        {
            InitializeComponent();
            seçiligk = drv;
            tbadres.Text = seçiligk["Adres"].ToString();
            tbfax.Text = seçiligk["Fax"].ToString();
            tbkapasite.Text = seçiligk["Kapasite"].ToString();
            tbklupadı.Text = seçiligk["KulupAdı"].ToString();
            tbtelefon.Text = seçiligk["Telefon"].ToString();
            tbşehir.Text = seçiligk["Şehir"].ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (seçiligk==null)
            {
                sorgu = "INSERT INTO [GolfKlupleri] VALUES (@KulupAdı, @Adres, @Kapasite, @Şehir, @Telefon, @Fax)";
                sqlCmd = new SqlCommand(sorgu, Veri.sqlCon);
                sqlCmd.Parameters.AddWithValue("@KulupAdı", tbklupadı.Text);
                sqlCmd.Parameters.AddWithValue("@Adres", tbadres.Text);
                sqlCmd.Parameters.AddWithValue("@Kapasite", tbkapasite.Text);
                sqlCmd.Parameters.AddWithValue("@Şehir", tbşehir.Text);
                sqlCmd.Parameters.AddWithValue("@Telefon", tbtelefon.Text);
                sqlCmd.Parameters.AddWithValue("@Fax", tbfax.Text);
            }
            else
            {
                sorgu = "UPDATE [GolfKlupleri] SET KulupAdı=@KulupAdı, Adres=@Adres, Kapasite=@Kapasite, Şehir=@Şehir, Telefon=@Telefon, Fax=@Fax WHERE Id=@Id";
                sqlCmd = new SqlCommand(sorgu, Veri.sqlCon);
                sqlCmd.Parameters.AddWithValue("@KulupAdı", tbklupadı.Text);
                sqlCmd.Parameters.AddWithValue("@Adres", tbadres.Text);
                sqlCmd.Parameters.AddWithValue("@Kapasite", tbkapasite.Text);
                sqlCmd.Parameters.AddWithValue("@Şehir", tbşehir.Text);
                sqlCmd.Parameters.AddWithValue("@Telefon", tbtelefon.Text);
                sqlCmd.Parameters.AddWithValue("@Fax", tbfax.Text);
                sqlCmd.Parameters.AddWithValue("@Id", seçiligk["Id"]);
            }

            try
            {
                Veri.BaglantıyıAç();
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("KayıtBaşarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Veri.BaglantıyıKapat();
            }

            NavigationService.Navigate(new Uri("Models/GolfKlupleriListesi.xaml", UriKind.Relative));

        }
    }
}
