using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tthk_xamarin_horoscope.Models;
using Xamarin.Forms;

namespace tthk_xamarin_horoscope
{
    public partial class MainPage : ContentPage
    {
        List<ZodiacSign> zodiacSigns;
        string[] zodiacSignsTitles;
        public MainPage()
        {
            zodiacSigns = ZodiacSignGenerator.GetZodiacSigns();
            Title = "Знаки Зодиака";
            InitializeComponent();
            zodiacSignPicker.ItemsSource = zodiacSigns.Select(zs => zs.Title).ToArray(); // Get zodiac signs' names using Linq
            zodiacSignPicker.SelectedIndexChanged += ZodiacSignPicker_SelectedIndexChanged;
            zodiacSignDatePicker.DateSelected += ZodiacSignDatePicker_DateSelected;
        }

        private void ZodiacSignDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            int selectedZodiacSignIndex;
            if (e.NewDate.Month == 1 && e.NewDate.Day < 21 || e.NewDate.Month == 12 && e.NewDate.Day > 21)
            {
                selectedZodiacSignIndex = 0;
                
            }
            else
            {
                var selectedZodiacSign = zodiacSigns.First(zs => e.NewDate.DayOfYear <= zs.EndDate.DayOfYear && e.NewDate.DayOfYear >= zs.StartDate.DayOfYear);
                selectedZodiacSignIndex = zodiacSigns.IndexOf(selectedZodiacSign);
            }
            zodiacSignPicker.SelectedIndex = selectedZodiacSignIndex;
            DisplayZodiacSignInfo(selectedZodiacSignIndex);
        }

        private void ZodiacSignPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            zodiacSignDatePicker.Date = zodiacSigns[picker.SelectedIndex].StartDate + TimeSpan.FromDays(15);
            DisplayZodiacSignInfo(picker.SelectedIndex);
        }

        private void DisplayZodiacSignInfo(int index)
        {
            CultureInfo ci = new CultureInfo("RU-ru");
            // I decided to use shorter and simply variables' names for ZodiacSign object properties
            string title = zodiacSigns[index].Title;
            string description = zodiacSigns[index].Description;
            DateTime startDate = zodiacSigns[index].StartDate;
            DateTime endDate = zodiacSigns[index].EndDate;
            ImageSource picture = zodiacSigns[index].Picture;
            zodiacSignImage.Source = picture;
            zodiacSignTitleLabel.Text = title;
            zodiacSignDescriptionLabel.Text = description;
            zodiacSignDateLabel.Text = $"С {startDate.ToString("dd MMM", ci)} до {endDate.ToString("dd MMM", ci)} {DateTime.Now.Year.ToString()} года";
        }
    }
}
