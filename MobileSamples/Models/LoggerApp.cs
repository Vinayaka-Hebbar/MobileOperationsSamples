using MobileSamples.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace MobileSamples.Models
{
    public sealed class LoggerApp : MobileApp
    {
        private StringBuilder stringBuilder;

        public LoggerApp()
        {
            stringBuilder = new StringBuilder();
        }

        public override AppType AppType => AppType.Background;

        public override string Name => "Logs";

        public override string IconPath => "M 37.9167,15.8333C 40.1028,15.8333 42.25,17.8139 42.25,20L 42,21L 54,21L 54,57L 22,57L 22,21L 34,21L 33.75,20C 33.75,17.8139 35.7305,15.8333 37.9167,15.8333 Z M 51,24L 45.5,24L 47.5,28L 28.5,28L 30.5,24L 25,24L 25,54L 51,54L 51,24 Z M 37.9166,18.2084C 37.0422,18.2084 36,18.8756 36,19.75C 36,20.0384 36.3653,20.7671 36.5,21L 39.5,21C 39.6347,20.7671 40,20.0384 40,19.75C 40,18.8756 38.7911,18.2084 37.9166,18.2084 Z";

        public override SolidColorBrush Color => Brushes.Gainsboro;

        public override UIElement Run()
        {
            return new TextBlock
            {
                Text = stringBuilder.ToString(),
                Foreground = TextColor
            };
        }

        public override void OnUpdate(object value)
        {
            stringBuilder.AppendLine(value.ToString());
        }

        public override IList<AppMenu> GetMenus()
        {
            List<AppMenu> menus = new List<AppMenu>();
            var clearMenu = new DeleteMenu();
            clearMenu.Click += OnClear;
            menus.Add(clearMenu);
            return menus;
        }

        private void OnClear()
        {
            stringBuilder.Clear();
            AppUI.OnRestart();
        }
    }
}
