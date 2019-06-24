using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HoopRun
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            hoopRunWebView.Source = "http://hooprunapp.com/";

            /* Normally you want to subscribe in OnAppearing and unsubscribe in OnDisappearing but since another page would call this, we need to stay subscribed */
            MessagingCenter.Unsubscribe<string>(this, "ChangeWebViewKey");
            MessagingCenter.Subscribe<string>(this, "ChangeWebViewKey", newWebViewUrl => Device.BeginInvokeOnMainThread(async () => {
                hoopRunWebView.Source = newWebViewUrl;
            }));
        }
    }
}