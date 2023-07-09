using MyWebApplication.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MyWebApplication
{
    class Program
    {       
        static void Main(string[] args)
        {
            #region token
            const string token = "6350906649:AAFUIYQ5daxVec6IsJNoYB0faUhK8FzaBh8";
            #endregion          
            // Запуасакаем серверную часть бота.
            CreateBot client = new CreateBot(token);

            Console.ReadLine();
        }
    }
}
