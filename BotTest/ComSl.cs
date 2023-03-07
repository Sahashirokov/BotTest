using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace BotTest;

public class ComSl:ApplicationCommandModule
{
    [SlashCommand("test", "This is our is First comannd")]
    public async Task TestSlashComand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
            new DiscordInteractionResponseBuilder().WithContent("StartingSlashComand..."));
        var emdedMessage = new DiscordEmbedBuilder()
        {
            Title = "Test",
            Description = "Hello"
        };
        await ctx.Channel.SendMessageAsync(embed: emdedMessage);
    }
}