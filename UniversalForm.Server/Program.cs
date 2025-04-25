using System.Net;
using UniversalForm.Server.Persistence;

namespace UniversalForms.Server;

class Program
{
    static readonly string HOST = Dns.GetHostName();
    static readonly int PORT = 3000;
    static readonly string DATA_DIR = "Data";
    public static void Main()
    {
        Server server = new(HOST, PORT, new BinaryPersistence(DATA_DIR));
        Task serverTask = Task.Run(() => server.Start());

        Console.Read();
        server.Stop();
    }
}