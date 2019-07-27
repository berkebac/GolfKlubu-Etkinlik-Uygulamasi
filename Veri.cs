using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace _56
{
    public static class Veri
    {
        public static SqlConnection sqlCon;

        static Veri()
        {
            sqlCon = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=|DataDirectory|Database1.mdf;");

        }

        public static void BaglantıyıAç()
        {
            sqlCon.Open();
        }
        public static void BaglantıyıKapat()
        {
            sqlCon.Close();
        }


        public static byte[] BitmapSourcetoByteArray(BitmapSource ResimKaynak)
        {
            #region BitmapSource'u byte[]'a Çevir (Veritabanına yazarken)

            byte[] byteDizisi;
            if (ResimKaynak == null)
            {
                byteDizisi = new byte[0];
            }
            else
            {
                using (var stream = new MemoryStream())
                {
                    var kodlayıcı = new PngBitmapEncoder();
                    kodlayıcı.Frames.Add(BitmapFrame.Create(ResimKaynak));
                    kodlayıcı.Save(stream);
                    byteDizisi = stream.ToArray();
                }
            }
            return byteDizisi;
            #endregion
        }

        public static BitmapSource ByteArraytoBitmapSource(byte[] byteDizisi)
        {
            #region byte[]'ı BitmapSource'a Çevir (Veritabanından okurken)

            if (byteDizisi != null && byteDizisi.Length > 0)
            {
                using (var stream = new MemoryStream(byteDizisi))
                {
                    var kodÇözücü = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    return kodÇözücü.Frames[0];
                }
            }
            else
            {
                return null;
            }

            #endregion
        }



        public static DataView TabloGetir(string sorgu)
        {
            BaglantıyıAç();
            SqlCommand sqlcmd = new SqlCommand(sorgu, sqlCon);
            SqlDataReader sqlDr = sqlcmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sqlDr);
            BaglantıyıKapat();
            return dt.DefaultView;
        }
    }
}
