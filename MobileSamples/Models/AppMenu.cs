using System.Windows;
using System.Windows.Media;

namespace MobileSamples.Models
{
    public abstract class AppMenu
    {
        public delegate void ClickCommand();
        public event ClickCommand Click;
        public abstract string IconPath { get; }
        public abstract string ToolTip { get; }
        public abstract SolidColorBrush FillColor { get; }

        public void OnClick()
        {
            Click?.Invoke();
        }
    }
}
