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
        //var fileName = "Data/admin1.ufu";
        //using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        //{
        //    using (var w = new BinaryWriter(fs))
        //    {
        //        w.Write("""
        //                {
        //                  "username": "admin1",
        //                  "password": "Yw5EKD7BBm0QnGI6AdA2NfYXr2SZ\u002BGg3Yj6xb1xkWwo=",
        //                  "forms": [
        //                    "Test_form",
        //                	"TestForm2"
        //                  ]
        //                }
        //                """);
        //    }
        //}
        //return;
        ServerConsole serverConsole = new( new(HOST, PORT, new BinaryPersistence(DATA_DIR)));
        serverConsole.Start();

        serverConsole.ReadConsole();

        serverConsole.Stop();
    }
}