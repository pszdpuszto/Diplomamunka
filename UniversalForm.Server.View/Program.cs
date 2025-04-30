using System.Net;
using UniversalForm.Server.Persistence;
using UniversalForm.Server.Model;
using UniversalForm.Utils;

namespace UniversalForm.Server.View;

class Program
{
    static readonly string DATA_DIR = "Data";
    public static void Main()
    {
        var endPoint = IniReader.ReadServerAddress("settings.ini");
        if (endPoint == null)
        {
            Console.WriteLine("Failed to read server address from settings.ini. Exiting application...");
            return;
        }
        Model.Server model;
        try
        {
            model = new(endPoint, new BinaryPersistence(DATA_DIR));
        } catch
        {
            Console.WriteLine("Failed to start server. Exiting application...");
            return;
        }
        ServerConsole serverConsole = new(model);
        serverConsole.Start();

        serverConsole.ReadConsole();

        serverConsole.Stop();
    }
}