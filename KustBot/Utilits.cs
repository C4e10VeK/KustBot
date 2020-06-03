using DSharpPlus.Lavalink;
using DSharpPlus.Net;

namespace KustBot
{
    public class Utilits
    {
        public static LavalinkConfiguration lavalinkCfg = new LavalinkConfiguration
        {
            Password = "popka",
            RestEndpoint = new ConnectionEndpoint { Hostname = "192.168.1.5", Port = 2333 },
            SocketEndpoint = new ConnectionEndpoint { Hostname = "192.168.1.5", Port = 2333 },
        };
    }
}
