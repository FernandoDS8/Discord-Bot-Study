using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    public class TestCommands : BaseCommandModule
    {
        [Command("hello")]
        [Description("Retorna Apresentação")]
        public async Task Hello (CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Olá! O que você deseja?");
        }

        [Command("add")]
        [Description("Retorna Soma")]
        public async Task Add(CommandContext ctx, [Description("Primeiro Número")] int nOne, [Description("Segundo Número")] int nTwo)
        {
            await ctx.Channel.SendMessageAsync((nOne + nTwo)
                .ToString())
                .ConfigureAwait(false);
        }

    }
}
