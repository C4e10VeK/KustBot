using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace KustBot.Commands
{
    [Group("admin")]
    [Description("Admin commands for server")]
    [Hidden]
    class AdminComands : BaseCommandModule
    {
        [RequirePermissions(Permissions.ManageRoles)]
        [Description("Creating role at server")]
        [Command("role_create")]
        public async Task RoleCreate(CommandContext ctx, params string[] roleName)
        {
            string RoleName = null;

            for (int i = 0; i < roleName.Length; i++)
            {
                RoleName += roleName[i] + " ";
            }

            await ctx.Guild.CreateRoleAsync(RoleName);
            await ctx.RespondAsync($"Role, {RoleName}, ctrated!!");
        }

        [RequirePermissions(Permissions.ManageRoles)]
        [Description("Deleting role at server")]
        [Command("role_del")]
        public async Task RoleDel(CommandContext ctx, params string[] roleName)
        {
            string RoleName = null;

            for (int i = 0; i < roleName.Length; i++)
            {
                RoleName += roleName[i] + " ";
            }

            try
            {
                var role = ctx.Guild.Roles.FirstOrDefault(x => x.Value.Name == RoleName);
                Console.WriteLine(role);
                await role.Value.DeleteAsync();
                await ctx.RespondAsync($"{role.Value.Name} deleted!!");
            }
            catch (Exception)
            {
                await ctx.RespondAsync($"Роль «{RoleName}» не существует");
            }
        }
    }
}
