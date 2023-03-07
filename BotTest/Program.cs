// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");

using BotTest;

Bot bot = new Bot();
bot.RunAsync().GetAwaiter().GetResult();