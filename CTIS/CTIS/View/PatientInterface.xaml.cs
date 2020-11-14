using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CTIS.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatientInterface : ContentPage
    {
        public PatientInterface()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewTestingHistory());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        public class MyData
        {
            public string Data { get; set; }
        }

    }
}