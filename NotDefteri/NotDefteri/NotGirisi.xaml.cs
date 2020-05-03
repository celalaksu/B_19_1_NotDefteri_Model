using NotDefteri.Modeller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotDefteri
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotGirisi : ContentPage
    {
        public NotGirisi()
        {
            InitializeComponent();
        }

        async void NotKaydet(object sender, EventArgs e)
        {
            var notlar = (Notlar)BindingContext;

            if (string.IsNullOrWhiteSpace(notlar.DosyaAdi))
            {
                // Kaydet
                var dosyaAdi = Path.Combine(App.DosyaYolu, $"{Path.GetRandomFileName()}.notes.txt");
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