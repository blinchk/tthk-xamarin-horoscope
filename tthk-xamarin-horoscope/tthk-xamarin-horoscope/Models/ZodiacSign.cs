using System;
using Xamarin.Forms;

namespace tthk_xamarin_horoscope.Models
{
    class ZodiacSign
    {
        string title;
        string description;
        TimeSpan startDate;
        TimeSpan endDate;
        ImageSource picture;

        public string Title
        {
            get => title;
            set => title = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public TimeSpan StartDate
        {
            get => startDate;
            set => startDate = value;
        }

        public TimeSpan EndDate
        {
            get => endDate;
            set => endDate = value;
        }

        public ImageSource Picture
        {
            get => picture;
            set => picture = value;
        }
    }
}
