using MobileSamples.Models;
using System.Windows.Controls;
using System.Windows.Media;

namespace MobileSamples.Controls
{
    /// <summary>
    /// Interaction logic for ShutdownUI.xaml
    /// </summary>
    public partial class ShutdownUI : UserControl
    {
        public ShutdownUI()
        {
            InitializeComponent();
        }

        public ShutdownUI(Mobile mobile)
        {
            InitializeComponent();
            Background = mobile.BackgroundColor;
            ShutdownField.Foreground = mobile.TextColor;
        }
    }
}
