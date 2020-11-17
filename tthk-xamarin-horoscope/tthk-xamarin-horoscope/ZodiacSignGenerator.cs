using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using tthk_xamarin_horoscope.Models;
using Xamarin.Forms;

namespace tthk_xamarin_horoscope
{
    public class ZodiacSignGenerator
    {
        public static List<ZodiacSign> zodiacSigns;
        static string[] zodiacSignsTitles = new string[] { "Козерог", "Водолей", "Рыбы", "Овен", "Телец", "Близнецы", "Рак", "Лев", "Дева", "Весы", "Скорпион", "Стрелец" };
        static string[] zodiacSignsStartDateStrings = new string[] { "22.12", "21.01", "19.02", "21.03", "20.04", "21.05", "22.06", "23.07", "23.08", "23.09", "24.10", "23.11" };
        static string[] zodiacSignsPaths = new string[] { 
            "capricorn", "aquarius", "pisces", 
            "aries", "taurus", "gemini", 
            "cancer", "leo", "virgo",
            "libra", "scorpio", "sagittarius"
        };

        public static List<ZodiacSign> GetZodiacSigns()
        {
            zodiacSigns = new List<ZodiacSign>();
            
            var ci = new CultureInfo("et-EE");
            for (int i = 0; i < 12; i++)
            {
                DateTime endDate;
                DateTime startDate = DateTime.ParseExact(zodiacSignsStartDateStrings[i], @"dd.MM", ci);
                if (i == 11)
                    endDate = DateTime.ParseExact(zodiacSignsStartDateStrings[0], @"dd.MM", ci) - TimeSpan.FromDays(1);
                else
                    endDate = DateTime.ParseExact(zodiacSignsStartDateStrings[i + 1], @"dd.MM", ci) - TimeSpan.FromDays(1);
                ZodiacSign zodiacSign = new ZodiacSign()
                {
                    Title = zodiacSignsTitles[i],
                    Description = LoadText(i),
                    StartDate = startDate,
                    EndDate = endDate, // TODO: Fill DateTimes to array or file
                    Picture = ImageSource.FromFile(zodiacSignsPaths[i] + ".png")
                };
                zodiacSigns.Add(zodiacSign);
            }
            return zodiacSigns;
        }

        private static string LoadText(int index)
        {
            using (WebClient client = new WebClient())
            {
                string s = client.DownloadString(url);
            };
        }
    }
}
