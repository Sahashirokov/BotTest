using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace BotTest.Commands
{
    public class Fun : BaseCommandModule
    {
        [Command("test")]
        public async Task TestCommand(CommandContext ctx) 
        {
            await ctx.Channel.SendMessageAsync("Hello");
        }
    }
}
