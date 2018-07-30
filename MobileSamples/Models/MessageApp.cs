﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MobileSamples.Models
{
    public sealed class MessageApp : MobileApp
    {
        public override string Name => "Message";

        public override string IconPath => "M 21.5,23L 54.5,23C 56.2489,23 58,24.7511 58,26.5L 58,49.5C 58,51.2489 56.2489,53 54.5,53L 21.5,53C 19.7511,53 18,51.2489 18,49.5L 18,26.5C 18,24.7511 19.7511,23 21.5,23 Z M 22,47C 22,48.3117 22.6883,49 24,49L 52,49C 53.3117,49 54,48.3117 54,47L 54,29L 40.6563,42.6567C 39.4197,43.8933 37.4146,43.8933 36.178,42.6567L 22,29L 22,47 Z M 25,27L 36.7378,38.7381C 37.6653,39.6656 39.169,39.6656 40.0965,38.7381L 52,27L 25,27 Z";

        public override SolidColorBrush Color => Brushes.Yellow;

        public override UIElement Run()
        {
            return new TextBlock() { Text = "Welcome to Messages" , Foreground = TextColor};
        }
    }
}
