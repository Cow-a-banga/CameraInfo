using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CameraInfo
{
    public partial class MainPage : ContentPage
    {
        private CameraModelProvider _cameraModelProvider;
        
        public MainPage()
        {
            InitializeComponent();
            _cameraModelProvider = new CameraModelProvider();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var cameraModels = await _cameraModelProvider.GetEnumerableAsync();
            if (cameraModels != null)
            {
                view.ItemsSource = cameraModels;
                view.HasUnevenRows = true;
            }
            else
            {
                DisplayAlert("Ошибка","Проблемы с доступом к серверу, попробуйте позже","Ок");
            }
        }
    }
}