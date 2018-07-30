using MobileSamples.Models;
using System.Windows;

namespace MobileSamples.Common
{
    public interface IMobileUI
    {
        Mobile Mobile { get; }
        IAppUI RunningApp { get; set; }

        void GoHome();

        void GoBack();

        void SetContent(UIElement element);

        void OnShutdown();
        void OnPowerOn();

        T GetApp<T>(string appName) where T : MobileApp;
    }
}
