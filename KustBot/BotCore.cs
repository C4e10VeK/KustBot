using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using KustBot.Commands;
using KustBot.Config;
using KustBot.Interactivity;
using KustBot.Music;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace KustBot
{
    public class BotCore
    {
        private static DiscordClient discord;
        private static CommandsNextExtension commands;
        private static InteractivityExtension interactivity;

        private static ConfigReader config = JsonConvert.DeserializeObject<ConfigReader>(File.ReadAllText("Config.json"));

        private static DiscordActivity discordActivity = new DiscordActivity 
        { 
            Name = config.game,
            ActivityType = ActivityType.Playing,
        };

        public async Task MainTask(string[] args)
        {
            Console.WriteLine(config.token);

            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = config.token,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefixes = config.prefix
            });

            interactivity = discord.UseInteractivity(new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromSeconds(-1)
            });

            //command register
            commands.RegisterCommands<BotCommands>();
            commands.RegisterCommands<AdminComands>();
            commands.RegisterCommands<FunCommands>();
            commands.RegisterCommands<RoleInteractivity>();
            commands.RegisterCommands<MusicCommands>();


            await discord.ConnectAsync(discordActivity, UserStatus.Online, DateTimeOffset.Now);
            await Task.Delay(-1);
        }
    }
}
