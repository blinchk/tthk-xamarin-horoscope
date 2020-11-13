using System;
using Xamarin.Forms;

namespace tthk_xamarin_horoscope.Models
{
    public class ZodiacSign 
    {
        string title;
        string description;
        DateTime startDate;
        DateTime endDate;
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

        public DateTime StartDate
        {
            get => startDate;
            set => startDate = value;
        }

        public DateTime EndDate
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
