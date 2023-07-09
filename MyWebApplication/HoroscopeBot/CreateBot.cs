using MyWebApplication.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MyWebApplication
{
    class CreateBot
    {
        private FindXpas findXpas;
        private TelegramBotClient client;
        private HoroscopeArray horoscopeArray;

        public CreateBot(string token)
        {
            findXpas = new FindXpas();
            horoscopeArray = new HoroscopeArray();
            client = new TelegramBotClient(token);
            client.StartReceiving(Update, Error);
        }

        static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        async Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            var message = update.Message;
            #region Массив с выводимыми кнопками
            ReplyKeyboardMarkup keyboard = new(new[]
                               {
                            new  KeyboardButton[] {"Овен", "Телец", "Близнецы", "Рак" },
                            new  KeyboardButton[] {"Лев", "Дева", "Весы", "Скорпион" },
                            new  KeyboardButton[] {"Стрелец", "Козерог", "Водолей", "Рыба" }

                        }); ;

            ReplyKeyboardMarkup start = new(new[]
                               {
                            new  KeyboardButton[] {"/start"},
                           

                        }); ;
            #endregion

            // Вывод в консоль сообщений адресованых от пользователей  боту.
            if (message.Text != null)
            {
                Console.WriteLine($"{message.Chat.Username ?? "Anon"} | {message.Chat.Id} |{message.Text}");
            }

            // Обработка всех сообщений кроме знака зодиака и кнопки /start.
            if (message.Text != null && horoscopeArray.FindSign(message.Text) == false  && message.Text != "/start")
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Извини я не разговорный бот и не умею вести диалог." +
                    "Я могу лишь расказать тебе твой гороскоп на сегодня.");
              
                await client.SendTextMessageAsync(message.Chat.Id,  "Для этого нажми кнопку start" , replyMarkup: start);
            }


            // Обработка команды /start.
            if (message.Text == "/start")
            {             
                await client.SendTextMessageAsync(message.Chat.Id, "Выбери свой знак зодиака.", replyMarkup: keyboard);
            }

            // Вывод предсказания в зависимости от знака зодиака
            if (horoscopeArray.FindSign(message.Text))
            {
                // Парсинг предсказания с сайта.
                await client.SendTextMessageAsync(message.Chat.Id, findXpas.GetXpas(message.Text));
            }
        }
    }
}
