using System.Text;
using BotTest.Commands;
using BotTest.Slash_Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using Newtonsoft.Json;


namespace BotTest;

public class Bot
{
    public DiscordClient Client { get; private set; }
    public InteractivityExtension Interactivity { get; private set; }
    public CommandsNextExtension Commands { get; private set; }
    public async Task RunAsync()
    {
        string json = string.Empty;
        using (var fs = File.OpenRead("config.json"))
        using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
            json = await sr.ReadToEndAsync();

        var configJson = JsonConvert.DeserializeObject<ConfigJSON>(json);

        DiscordConfiguration config = new DiscordConfiguration()
        {
            Intents = DiscordIntents.All,
            Token = configJson.Token,
            TokenType = TokenType.Bot,
            AutoReconnect = true
        };

        Client = new DiscordClient(config);
        Client.UseInteractivity(new InteractivityConfiguration()
        {
            Timeout = TimeSpan.FromMinutes(2)
        });

        //EVENT HANDLERS
        Client.Ready += OnClientReady;

        var commandsConfig = new CommandsNextConfiguration
        {
            StringPrefixes = new string[] { configJson.Prefix },
            EnableMentionPrefix = true,
            EnableDms = true,
            EnableDefaultHelp = false
        };

        Commands = Client.UseCommandsNext(commandsConfig);
        SlashCommandsExtension slashCommandsConfig = Client.UseSlashCommands();

        //NORMAL COMMANDS
        Commands.RegisterCommands<Fun>();

        //SLASH COMMANDS
        slashCommandsConfig.RegisterCommands<ComSl>();

        await Client.ConnectAsync();
        await Task.Delay(-1);
    }
    private Task OnClientReady(DiscordClient sender, ReadyEventArgs readyEventArgs)
    {
        return Task.CompletedTask;
    }
}