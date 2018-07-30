﻿using MobileSamples.Common;
using MobileSamples.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;

namespace MobileSamples.Models
{
    public sealed class ContactApp : MobileApp
    {
        public ContactApp()
        {
            Contacts = new ItemsSerializable<Contact>();
        }

        private StackPanel root;

        private ObservableCollection<Contact> Contacts { get; set; }

        public override string Name => "Contacts";

        public override string IconPath => "M 38,26.9167C 42.618,26.9167 44.5972,29.5555 43.9312,35.0945C 44.5262,35.4358 44.9271,36.0773 44.9271,36.8125C 44.9271,37.7121 44.3269,38.4715 43.5051,38.7122C 43.1618,39.9358 42.6286,41.0191 41.9583,41.8856L 41.9583,46.0486C 44.1574,46.4884 45.9167,46.7083 48.5555,48.0278C 51.1944,49.3472 52.0741,50.5567 53.8333,52.316L 53.8333,58.5833L 22.1667,58.5833L 22.1666,52.316C 23.9259,50.5567 24.8055,49.3472 27.4444,48.0278C 30.0833,46.7083 31.8426,46.4884 34.0417,46.0486L 34.0417,41.8856C 33.3714,41.0191 32.8382,39.9358 32.4949,38.7121C 31.6731,38.4715 31.0729,37.7121 31.0729,36.8125C 31.0729,36.0773 31.4737,35.4358 32.0688,35.0945C 31.4028,29.5555 33.3819,26.9167 38,26.9167 Z M 25.8611,46.8403C 23.6735,47.9341 23.8824,47.7648 22.6094,49.0834L 12.6667,49.0833L 12.6667,42.816C 14.4259,41.0567 15.3056,39.8472 17.9444,38.5278C 20.5833,37.2083 22.3426,36.9884 24.5417,36.5486L 24.5417,32.3856C 23.8714,31.5191 23.3382,30.4359 22.9949,29.2122C 22.1731,28.9715 21.5729,28.2121 21.5729,27.3125C 21.5729,26.5773 21.9738,25.9358 22.5688,25.5945C 21.9028,20.0556 23.8819,17.4167 28.5,17.4167C 32.8315,17.4167 34.8414,20.9258 34.5246,25.7844C 31.6667,26.9167 30.0833,28.5 30.0896,33.1153C 29.4946,33.4566 29.0938,34.0982 29.0938,34.8333C 29.0938,35.7329 29.2981,36.8882 30.1199,37.1288C 30.4632,38.3525 30.9964,39.4358 31.6667,40.3023L 31.6667,44.8611C 29.4676,45.3009 28.5,45.5208 25.8611,46.8403 Z M 50.1389,46.8403C 47.5,45.5208 46.5324,45.3009 44.3333,44.8611L 44.3333,40.3023C 45.0036,39.4358 45.5368,38.3525 45.8801,37.1288C 46.7019,36.8882 46.9062,35.7329 46.9062,34.8333C 46.9062,34.0982 46.5054,33.4566 45.9104,33.1153C 45.9167,28.5 44.3333,26.9167 41.4754,25.7844C 41.1585,20.9257 43.1685,17.4167 47.5,17.4167C 52.118,17.4167 54.0972,20.0555 53.4312,25.5945C 54.0262,25.9358 54.4271,26.5773 54.4271,27.3125C 54.4271,28.2121 53.8269,28.9715 53.0051,29.2121C 52.6618,30.4358 52.1286,31.5191 51.4583,32.3856L 51.4583,36.5486C 53.6574,36.9884 55.4166,37.2083 58.0555,38.5278C 60.6944,39.8472 61.5741,41.0567 63.3333,42.816L 63.3333,49.0833L 53.3906,49.0833C 52.1176,47.7648 52.3265,47.9341 50.1389,46.8403 Z";

        public override SolidColorBrush Color => Brushes.BlueViolet;

        public override SolidColorBrush TextColor => Brushes.White;

        public override UIElement Run()
        {
            root = new StackPanel();
            return root;
        }

        public override void Initialize()
        {
            Stream stream = null;
            using (stream = File.Open("contacts.xml", FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
                if (serializer.Deserialize(stream) is ObservableCollection<Contact> contacts)
                {
                    foreach (var contact in contacts)
                        Add(contact);
                }
            }
            OnInitialize();
        }

        

        public void Add(Contact contact)
        {
            Contacts.Add(contact);
            StackPanel panel = new StackPanel();
            panel.Children.Add(new TextBlock()
            {
                Text = contact.Name,
                FontSize = 16,
                Foreground = TextColor
            });
            panel.Children.Add(new TextBlock
            {
                Text = contact.PhoneNo,
                Foreground = TextColor
            });
            root.Children.Add(panel);
        }

        public override IList<AppMenu> GetMenus()
        {
            List<AppMenu> menus = new List<AppMenu>();
            var addMenu = new AddMenu();
            addMenu.Click += OnAdd;
            menus.Add(addMenu);
            var saveMenu = new SaveMenu();
            saveMenu.Click += SaveContacts;
            menus.Add(saveMenu);
            return menus;
        }

        private void SaveContacts()
        {
            Stream stream = null;
            using (stream = File.Open("contacts.xml", FileMode.Create))
            {
                TextWriter writter = new StreamWriter(stream);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
                serializer.Serialize(writter, Contacts);
            }
        }

        private void OnAdd()
        {
            Modal modal = new Modal(AppUI, "Contact Name", typeof(TextBox), "Phone Number", typeof(TextBox));
            modal.Submit += OnSubmit;
            AppUI.OnModal(modal);
        }

        private void OnSubmit(object[] values)
        {
            Contact contact = new Contact();
            contact.Name = values[1].ToString();
            contact.PhoneNo = values[3].ToString();
            Add(contact);

            AppUI.OnResume();
        }

        public override UIElement ReRun(params object[] args)
        {
            return root;
        }
    }
}
