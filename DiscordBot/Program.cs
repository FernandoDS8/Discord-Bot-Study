using System;

namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instância da Classe Bot
            var bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
