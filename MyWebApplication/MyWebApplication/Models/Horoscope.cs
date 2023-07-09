using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Models
{
    
    public class Horoscope
    {     
        public string User { get; set; }
        public Dictionary<string, int> ZodiacDictionary;
        public string Description;

        public Horoscope()
        {
            ZodiacDictionary = new Dictionary<string, int>()
            {
                {"Овен",1},
                {"Телец",2},
                {"Близнецы",3},
                {"Рак",4},
                {"Лев",5},
                {"Дева",6},
                {"Весы",7},
                {"Скорпион",8},
                {"Стрелец",9},
                {"Козерог",10},
                {"Водолей",11},
                {"Рыба",12}
            };

            
        }

        public int GetXpathId()
        {
            return ZodiacDictionary[User];
        }
    }
}

