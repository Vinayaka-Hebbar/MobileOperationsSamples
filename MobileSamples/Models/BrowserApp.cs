﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MobileSamples.Models
{
    public sealed class BrowserApp : MobileApp
    {
        public override string Name => "Browser";

        public override string IconPath => "M 45,40.6429C 47.9587,40.6429 50.3571,43.0413 50.3571,46C 50.3571,48.9587 47.9587,51.3571 45,51.3571C 42.0413,51.3571 39.6429,48.9587 39.6429,46C 39.6429,43.0413 42.0413,40.6429 45,40.6429 Z M 45,31C 50.5521,31 55.3997,34.2665 57.9933,38.75L 45.2156,39.039L 45,39.0357C 42.1237,39.0357 39.6547,40.7794 38.5923,43.2673L 32.8856,37.1529C 35.6143,33.4227 40.0242,31 45,31 Z M 60,46C 60,54.2843 53.2843,61 45,61L 43.3967,60.9153L 47.2863,52.5803C 50.0095,51.6342 51.9643,49.0454 51.9643,46C 51.9643,43.7935 50.9381,41.8266 49.3369,40.5506L 58.1886,39.3484C 59.3438,41.4742 60,43.4105 60,46 Z M 30,46C 30,42.7685 31.0218,39.7757 32.7601,37.3271L 38.0452,45.6323L 38.0357,46C 38.0357,49.8277 41.1236,52.9341 44.9442,52.9641L 43.1291,60.8845C 35.7278,59.9636 30,53.6507 30,46 Z M 18,21L 58,21L 58,36.6705C 57.1478,35.4852 56.1375,34.4211 55,33.5092L 55,26L 21,26L 21,46L 29,46C 29,47.0254 29.0965,48.0283 29.2808,49L 18,49L 18,21 Z";

        public override SolidColorBrush Color => Brushes.LightYellow;

        public override UIElement Run()
        {
            return new WebBrowser
            {
                Source = new Uri("http://www.google.com")
            };
        }
    }
}