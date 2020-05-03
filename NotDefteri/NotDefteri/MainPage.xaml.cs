using NotDefteri.Modeller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotDefteri
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();              
            
        }

         async void NotKaydet(object sender, EventArgs e)
        {
            var notlar = (Notlar)BindingContext;

            if (string.IsNullOrWhiteSpace(notlar.DosyaAdi))
            {
                // Kaydet
                var dosyaAdi = Path.Combine(App.DosyaYolu, $"{Path.GetRandomFileName()}.notlar.txt");
                File.WriteAllText(dosyaAdi, notGirisi.Text);
            }
            else
            {
                // Güncelle
                File.WriteAllText(notlar.DosyaAdi, notGirisi.Text);
            }

            await Navigation.PopAsync();
        }

        

        async void NotSil(object sender, EventArgs e)
        {
            var notlar = (Notlar)BindingContext;
            if (File.Exists(notlar.DosyaAdi))
            {
                File.Delete(notlar.DosyaAdi);
            }
            await Navigation.PopAsync();
        }

        
    }
}
