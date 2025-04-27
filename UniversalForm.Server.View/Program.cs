using System.Net;
using UniversalForm.Server.Persistence;
using UniversalForm.Server.Model;
using UniversalForm.Utils;

namespace UniversalForm.Server.View;

class Program
{
    static readonly string HOST = Dns.GetHostName();
    static readonly int PORT = 3000;
    static readonly string DATA_DIR = "Data";
    public static void Main()
    {
        ServerConsole serverConsole = new( new(HOST, PORT, new BinaryPersistence(DATA_DIR)));
        serverConsole.Start();

        serverConsole.ReadConsole();

        serverConsole.Stop();
    }
}