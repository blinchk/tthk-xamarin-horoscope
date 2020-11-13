using System;
using System.Collections.Generic;
using System.Text;
using tthk_xamarin_horoscope.Models;
using Xamarin.Forms;

namespace tthk_xamarin_horoscope
{
    public class ZodiacSignGenerator
    {
        public static List<ZodiacSign> zodiacSigns;
        static string[] zodiacSignsTitles = new string[] { "Козерог", "Водолей", "Рыбы", "Овен", "Телец", "Близнецы", "Рак", "Лев", "Дева", "Весы", "Скорпион", "Стрелец" };
        static ImageSource[] zodiacSignsPictures = new ImageSource[] { 
            "1_capricorn.png", "2_aquarius.png", "3_pisces.png", 
            "4_aries.png", "5_taurus.png", "6_gemini.png", 
            "7_cancer.png", "8_leo.png", "9_virgo.png",
            "10_libra.png", "11_scorpio.png", "12_sagitarrius.png"
        };

        private void LoadZodiacSignsDescriptonsFromFile()
        {

        }

        public static List<ZodiacSign> GetZodiacSigns()
        {
            zodiacSigns = new List<ZodiacSign>();
            for (int i = 0; i < 12; i++)
            {
                ZodiacSign zodiacSign = new ZodiacSign()
                {
                    Title = zodiacSignsTitles[i],
                    Description = "",
                    StartDate = new DateTime(2000, 10, 10),
                    EndDate = new DateTime(2000, 10, 10), // TODO: Fill DateTimes to array or file
                    Picture = zodiacSignsPictures[i]
                };
            }
            return zodiacSigns;
        }
    }
}
