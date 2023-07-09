using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApplication
{
    class HoroscopeArray
    {
        private string[] _zodiacArray;


        public HoroscopeArray()
        {
            _zodiacArray = new string[]
                {
                "Овен",
                "Телец",
                "Близнецы",
                "Рак",
                "Лев",
                "Дева",
                "Весы",
                "Скорпион",
                "Стрелец",
                "Козерог",
                "Водолей",
                "Рыба"
            };
        }

        // Метод поиска определённого слова в массиве.
        public bool FindSign(string name)
        {
            for (int i = 0; i < _zodiacArray.Length; i++)
            {
                if (name == _zodiacArray[i])
                {
                    return true;
                }
            }
            return false;
        }

    }
}
