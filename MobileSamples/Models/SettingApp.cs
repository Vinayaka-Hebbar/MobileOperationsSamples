﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MobileSamples.Models
{
    public class SettingApp : MobileApp
    {
        public override string Name => "Settings";

        public override string IconPath => "M 27.5314,21.8628L 33.0126,19.4224L 34.7616,23.3507C 36.6693,22.9269 38.6044,22.8903 40.4668,23.2026L 42.0083,19.1868L 47.6098,21.337L 46.0683,25.3528C 47.6612,26.3669 49.0747,27.6889 50.2088,29.2803L 54.1371,27.5313L 56.5776,33.0126L 52.6493,34.7616C 53.0731,36.6693 53.1097,38.6043 52.7974,40.4668L 56.8131,42.0083L 54.6629,47.6097L 50.6472,46.0683C 49.6331,47.6613 48.3111,49.0748 46.7197,50.2089L 48.4686,54.1372L 42.9874,56.5776L 41.2384,52.6493C 39.3307,53.0731 37.3957,53.1097 35.5333,52.7974L 33.9918,56.8131L 28.3903,54.6629L 29.9318,50.6472C 28.3388,49.6331 26.9252,48.3111 25.7911,46.7196L 21.8628,48.4686L 19.4224,42.9873L 23.3507,41.2383C 22.9269,39.3307 22.8903,37.3957 23.2026,35.5332L 19.1869,33.9918L 21.3371,28.3903L 25.3528,29.9318C 26.3669,28.3388 27.6889,26.9252 29.2804,25.7911L 27.5314,21.8628 Z M 34.3394,29.7781C 29.7985,31.7998 27.7564,37.1198 29.7781,41.6606C 31.7998,46.2015 37.1198,48.2436 41.6606,46.2219C 46.2015,44.2002 48.2436,38.8802 46.2219,34.3394C 44.2002,29.7985 38.8802,27.7564 34.3394,29.7781 Z";

        public override SolidColorBrush Color => Brushes.Azure;


        public override UIElement Run()
        {
            return new TextBlock()
            {
                Text = "Settings",
                Foreground = TextColor
            };
        }
    }
}
