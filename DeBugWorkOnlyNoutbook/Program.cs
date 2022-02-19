using System;

class Programm
{
    class User
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public bool IsPremium { get; set; }
    }
    static void ShowAds()
    {
        Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
        // Остановка на 1 с
        Thread.Sleep(1000);

        Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
        // Остановка на 2 с
        Thread.Sleep(2000);

        Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
        // Остановка на 3 с
        Thread.Sleep(3000);
    }
    static  void Main()
    {
        List<User> users = new List<User>();
        users.Add(new User() { Name = "Dima",IsPremium = false});
        users.Add(new User() { Name = "Petya", IsPremium = false });
        users.Add(new User() { Name = "Vasya", IsPremium = true });
        foreach (User user in users)
        {
            if (user.IsPremium == false)
            {
                Console.WriteLine($"Hello {user.Name}");
                ShowAds();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Hello {user.Name} you have is Premium account");
                return;
                Console.WriteLine();
            }
        }

    }




           
            static int BinarySearch(int value , int[] array)
            {
                var left = array[0];
                var rigth = array.Length;
                while(left <= rigth)
                {
                    var middle = (rigth + left) / 2;
                    var midEl = array[middle];
                    if (midEl == value)
                    {
                        return middle;
                    }
                    else if (value < midEl)
                    {
                        rigth = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                return -1;
            }
            
            
            var botClient = new TelegramBotClient("{YOUR_ACCESS_TOKEN_HERE}");

            using var cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };
            botClient.StartReceiving( HandleUpdateAsync, HandleErrorAsync, receiverOptions, cancellationToken: cts.Token);

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();

            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                // Only process Message updates: https://core.telegram.org/bots/api#message
                if (update.Type != UpdateType.Message)
                    return;
                // Only process text messages
                if (update.Message!.Type != MessageType.Text)
                    return;

                var chatId = update.Message.Chat.Id;
                var messageText = update.Message.Text;

                Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

                // Echo received message text
                Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "You said:\n" + messageText,
                    cancellationToken: cancellationToken);
            }

            Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
            {
                var ErrorMessage = exception switch
                {
                    ApiRequestException apiRequestException
                        => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                    _ => exception.ToString()
                };

                Console.WriteLine(ErrorMessage);
                return Task.CompletedTask;
            }
        }
    }
}
    

