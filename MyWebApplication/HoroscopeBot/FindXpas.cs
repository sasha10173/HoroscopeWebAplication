using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApplication
{
    class FindXpas
    {
        private ParsingURL pars;
        public FindXpas()
        {
            pars = new ParsingURL("https://www.chita.ru/horoscope/daily/");
        }

        public string GetXpas(string message)
        {
            Horoscope Horoscope = new Horoscope() { User = message };
            Horoscope.GetXpathId();
            string xpath = $"//*[@class='IGRa5'][{Horoscope.GetXpathId()}] //div[@class='BDPZt KUbeq']";

            return pars.GetElementString(xpath);
        }
    }
}
