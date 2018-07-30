using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MobileSamples.Controls
{
    public sealed class RoundButton : Button
    {
        static RoundButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RoundButton), new FrameworkPropertyMetadata(typeof(RoundButton)));
        }

        public static readonly DependencyProperty IconPathProperty = DependencyProperty.RegisterAttached("IconPath", typeof(string), typeof(RoundButton),new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty FillBrushProperty = DependencyProperty.RegisterAttached("FillBrush", typeof(SolidColorBrush), typeof(RoundButton), new PropertyMetadata(Brushes.White));

        public string IconPath
        {
            get => (string)GetValue(IconPathProperty);
            set => SetValue(IconPathProperty, value);
        }

        public SolidColorBrush FillBrush
        {
            get => (SolidColorBrush)GetValue(FillBrushProperty);
            set => SetValue(FillBrushProperty, value);
        }


    }
}
