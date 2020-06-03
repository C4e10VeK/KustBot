using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KustBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var botCore = new BotCore();
            botCore.MainTask(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
