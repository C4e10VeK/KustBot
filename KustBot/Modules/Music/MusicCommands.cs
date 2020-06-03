using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Lavalink;
using DSharpPlus.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KustBot.Music
{
    class MusicCommands : BaseCommandModule
    {
        private static ConnectionEndpoint Endpoint = new ConnectionEndpoint { Hostname = "192.168.1.5", Port = 2333 };
        private Queue<LavalinkTrack> tracks = new Queue<LavalinkTrack>();

        [Command("play")]
        [Priority(0)]
        public async Task PlayTrackAsyncs(CommandContext ctx, params string[] text)
        {
            string trakName = null;

            for (int i = 0; i < text.Length; i++)
            {
                trakName += text[i] + " ";
            }

            await ctx.RespondAsync(trakName);
            var discordVoice = ctx.Member.VoiceState;
            var vchn = discordVoice.Channel;
            if (vchn == null)
                await ctx.RespondAsync($"{ctx.Member.Mention}, ты должен быть на канале!");

            LavalinkExtension lavalink;
            LavalinkNodeConnection lavalinkNode;
            LavalinkGuildConnection lavalinkGuild;
            LavalinkLoadResult play;

            lavalink = ctx.Client.GetLavalink();
            if (lavalink == null)
            {
                lavalink = ctx.Client.UseLavalink();
                lavalinkNode = await lavalink.ConnectAsync(Utilits.lavalinkCfg);
            }
            else
            {
                lavalinkNode = lavalink.GetNodeConnection(Endpoint);
            }
            lavalinkGuild = await lavalinkNode.ConnectAsync(vchn);
            play = await lavalinkNode.Rest.GetTracksAsync(trakName, LavalinkSearchType.Youtube);
            
            Console.WriteLine($"{play.Tracks.First()} - кол-во элементов в очереди");

            await lavalinkGuild.PlayAsync(tracks.Dequeue());
            await ctx.RespondAsync($"Now playing {trakName}").ConfigureAwait(false);
        }

        [Command("pause")]
        public async Task PauseTrackAsync(CommandContext ctx)
        {
            var guild = ctx.Guild.CurrentMember.Guild;

            var lavalink = ctx.Client.GetLavalink();
            var node = lavalink.GetNodeConnection(Endpoint);
            var connection = node.GetConnection(guild);

            await connection.PauseAsync();
        }

        [Command("resume")]
        public async Task ResumeTrackAsync(CommandContext ctx)
        {
            var guild = ctx.Guild.CurrentMember.Guild;

            var lavalink = ctx.Client.GetLavalink();
            var node = lavalink.GetNodeConnection(Endpoint);
            var connection = node.GetConnection(guild);

            await connection.ResumeAsync();
        }

        [Command("stop")]
        public async Task StopTrackAsync(CommandContext ctx)
        {
            var guild = ctx.Guild.CurrentMember.Guild;

            var lavalink = ctx.Client.GetLavalink();
            var node = lavalink.GetNodeConnection(Endpoint);
            var connection = node.GetConnection(guild);

            await connection.StopAsync();
            await connection.DisconnectAsync();
        }
    }
}
