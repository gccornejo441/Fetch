﻿using Fetch.Shared;

namespace Fetch
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.DisplayAlert("Unable to dial", "Phone dialing not supported.", "OK");
        }

    }
}
