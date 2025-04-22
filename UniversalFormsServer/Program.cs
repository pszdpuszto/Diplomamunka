
using System.Net;

namespace UniversalForms.Server;

class Program
{
    static readonly string hostName = Dns.GetHostName();
    public static void Main()
    {
        UFServer server = new(hostName, 11_000);
        Task serverTask = Task.Run(() => server.Start());

        Console.Read();
        server.Stop();
    }
}