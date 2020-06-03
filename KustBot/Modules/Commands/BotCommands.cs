using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using KustBot.Commands;

namespace KustBot
{
    public class BotCommands : BaseCommandModule
    {
        [Command("info")]
        public async Task InfoAsync(CommandContext ctx)
        {
            var infoEmbed = new DiscordEmbedBuilder
            {
                Title = "Information about bot",
                Color = DiscordColor.Red,
                Description = "Я хрен знаю ждя чего создан. " + "Работаю когда захочу. \n" +
                "Бот принял ислам!!",
            };
            infoEmbed.AddField("Commands", "!!info", true);
            infoEmbed.AddField("Fun commands", "!!pour \n !!whistle \n !!ruletka", true);

            await ctx.RespondAsync(embed: infoEmbed.Build());
        }

        /*[Command("newname")]
        public async Task ChangeName(CommandContext ctx, string name)
        {
            await ctx.TriggerTypingAsync();

            await ctx.Member.ModifyAsync(name);
        }*/

        /*[Command("accept")]
        public async Task AcceptCmd(CommandContext ctx)
        {
            var user = ctx.User;
            var role = ctx.Guild.Roles.FirstOrDefault(x => x.Name == "Gachi");
            var member = ctx.Member;

            await ctx.Guild.GrantRoleAsync(member, role);
            await ctx.RespondAsync($"{role.Name} выдана {member.Username}. Добро пожаловать на сервер!");
        }*/
    }
}
