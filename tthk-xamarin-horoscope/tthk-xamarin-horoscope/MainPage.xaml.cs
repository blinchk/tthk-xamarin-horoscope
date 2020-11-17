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
            int todayZodiacSignIndex = GetZodiacSignIndexByDate(new DateTime(2003, 9, 3));
            DisplayZodiacSignInfo(todayZodiacSignIndex);
            zodiacSignPicker.SelectedIndex = todayZodiacSignIndex;
            zodiacSignDatePicker.Date = new DateTime(2003, 9, 3);
            SwipeGestureRecognizer swipeLeft = new SwipeGestureRecognizer() { Direction = SwipeDirection.Left, Threshold = 15 };
            SwipeGestureRecognizer swipeRight = new SwipeGestureRecognizer() { Direction = SwipeDirection.Right, Threshold = 15 };
            swipeLeft.Swiped += SwipeLeft_Swiped;
            swipeRight.Swiped += SwipeRight_Swiped;
            mainLayout.GestureRecognizers.Add(swipeLeft);
            mainLayout.GestureRecognizers.Add(swipeRight);
        }

        private async void LaunchLayoutAnimation()
        {
            await zodiacSignImage.FadeTo(0, 1);
            await animationLayout.TranslateTo(0, 0, 500, Easing.SinInOut);
            await zodiacSignImage.FadeTo(100, 250);
            await zodiacSignImage.TranslateTo(0, 0, 500, Easing.CubicInOut);
        }

        private void SwipeRight_Swiped(object sender, SwipedEventArgs e)
        {
            if (zodiacSignPicker.SelectedIndex > 0)
            {
                animationLayout.TranslationX = -300;
                zodiacSignImage.TranslationX = 300;
                LaunchLayoutAnimation();
                zodiacSignPicker.SelectedIndex--;
            }
        }

        private void SwipeLeft_Swiped(object sender, SwipedEventArgs e)
        {
            if (zodiacSignPicker.SelectedIndex < 11)
            {
                animationLayout.TranslationX = 300;
                zodiacSignImage.TranslationX = -300;
                LaunchLayoutAnimation();
                zodiacSignPicker.SelectedIndex++;
            }
        }

        private void ZodiacSignDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            int index = GetZodiacSignIndexByDate(e.NewDate);
            zodiacSignPicker.SelectedIndex = index;
            DisplayZodiacSignInfo(index);
        }

        private void ZodiacSignPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            zodiacSignDatePicker.Date = zodiacSigns[picker.SelectedIndex].StartDate + TimeSpan.FromDays(15);
            DisplayZodiacSignInfo(picker.SelectedIndex);
        }

        private int GetZodiacSignIndexByDate(DateTime date)
        {
            if (date.Month == 1 && date.Day < 21 || date.Month == 12 && date.Day > 21)
            {
                return 0;
                
            }
            else
            {
                var selectedZodiacSign = zodiacSigns.First(zs => date.DayOfYear <= zs.EndDate.DayOfYear && date.DayOfYear >= zs.StartDate.DayOfYear);
                return zodiacSigns.IndexOf(selectedZodiacSign);
            }
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
