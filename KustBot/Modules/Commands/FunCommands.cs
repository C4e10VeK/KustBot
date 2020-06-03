using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KustBot.Commands
{
    class FunCommands : BaseCommandModule
    {
        [Command("ruletka")]
        public async Task RuletkaRu(CommandContext ctx)
        {
            //await ctx.RespondAsync($"{ctx.User.Mention}. {Utilits.Ruletka()}!");
            await ctx.RespondAsync($"{ctx.User.Mention}. Идете переработка. Скоро все обновится!");
        }

        [Command("pour")]
        public async Task PouringAsyng(CommandContext ctx)
        {
            await ctx.RespondAsync($"{ctx.User.Mention} полил {ctx.Client.CurrentUser.Username}(InDev)");
        }

        [Command("whistle")]
        public async Task WhistleMemberAsync(CommandContext ctx, string memberName)
        {
            var user = ctx.Guild.Members.FirstOrDefault(x => x.Value.Nickname == memberName);
            if (user.Value == null)
            {
                user = ctx.Guild.Members.FirstOrDefault(x => x.Value.Username == memberName);
                if (user.Value == null)
                {
                    await ctx.RespondAsync($"«{memberName}», такого пользователя не существует");
                }
            }

            await ctx.RespondAsync($"{ctx.User.Mention}, свистнул {user.Value.Mention}");
        }
    }
}
