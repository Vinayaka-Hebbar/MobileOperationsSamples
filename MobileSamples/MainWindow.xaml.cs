using System;
using System.Windows;
using MobileSamples.Controls;
using MobileSamples.Models;

namespace MobileSamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadConfiguration();
            platform.Render += RenderMobile;
        }

        private void RenderMobile(Mobile mobile)
        {
            MobileUI ui = new MobileUI(mobile)
            {
                Background = mobile.BackgroundColor
            };
            ui.Shutdown += OnShutDown;
            ui.PowerOn += OnPoweOn;
            platform.MobileUI = ui;
            if (mobile.State == MobileState.Off)
            {
                MobileUIPresenter.Content = new ShutdownUI(mobile);
            }
            else
            {
                OnPoweOn();
            }
        }

        private void OnPoweOn()
        {
            MobileUIPresenter.Content = platform.MobileUI;
        }

        private void OnShutDown()
        {
            MobileUIPresenter.Content = new ShutdownUI(platform.MobileUI.Mobile);
        }

        private void OnMobileSelected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (MobileList.SelectedIndex == -1) return;
            Mobile selectedMobile = MobileList.SelectedItem as Mobile;
            if (selectedMobile != null)
            {
                platform.Run(selectedMobile);
            }
            Root.Background = selectedMobile.BackgroundColor;
        }


        private void OnGoHome(object sender, RoutedEventArgs e)
        {
            if (platform.MobileUI != null)
                platform.MobileUI.GoHome();
        }

        private void OnPowerOff(object sender, RoutedEventArgs e)
        {
            if (platform.MobileUI == null)
                return;
            switch (platform.MobileUI.Mobile.State)
            {
                case MobileState.On:
                    platform.MobileUI.Mobile.State = MobileState.Off;
                    platform.MobileUI.OnShutdown();
                    break;
                case MobileState.Off:
                    platform.MobileUI.Mobile.State = MobileState.On;
                    platform.MobileUI.OnPowerOn();
                    break;
            }
        }
    }
}
