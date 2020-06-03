using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KustBot.Interactivity
{
    [Group("manger")]
    [Hidden]
    [RequirePermissions(Permissions.Administrator)]
    class RoleInteractivity : BaseCommandModule
    {
        [Command("role_choose")]
        public async Task RoleChoose(CommandContext ctx)
        {
            /*var interactivity = ctx.Client.GetInteractivity();

            var roleChoose = new DiscordEmbedBuilder
            {
                Title = "Выбери роль",
                Color = DiscordColor.White
            };

            var chooseMessage = await ctx.Channel.SendMessageAsync(embed: roleChoose);

            var testRole1 = DiscordEmoji.FromName(ctx.Client, ":yarn:");
            var testRole2 = DiscordEmoji.FromName(ctx.Client, ":fork_and_knife:");

            await chooseMessage.CreateReactionAsync(testRole1).ConfigureAwait(false);
            await chooseMessage.CreateReactionAsync(testRole2).ConfigureAwait(false);

            var member = ctx.Member.Id;

            var resulteRoleChoose = await interactivity.WaitForReactionAsync(x => x.Message == chooseMessage && 
            x.User.Id == member
            && (x.Emoji == testRole1 || x.Emoji == testRole2)).ConfigureAwait(false);

            if (resulteRoleChoose.Result.Emoji == testRole1)
            {
                var role1 = ctx.Guild.GetRole(703172131151675454);
                await ctx.Member.GrantRoleAsync(role1).ConfigureAwait(false);
            }
            else if (resulteRoleChoose.Result.Emoji == testRole2)
            {
                var role2 = ctx.Guild.GetRole(703407135823888404);
                await ctx.Member.GrantRoleAsync(role2).ConfigureAwait(false);
            }
            else
            {
                await ctx.RespondAsync($"{ctx.User.Mention} - говно").ConfigureAwait(false);
                
            }*/
            await ctx.RespondAsync($"{ctx.User.Mention}, бот принял ислам эта функция в InDev");
        }
    }
}
