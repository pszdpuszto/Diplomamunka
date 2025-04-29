using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UniversalForm.Utils
{
    public static class IniReader
    {
        public static IPEndPoint? ReadServerAddress(string iniFilePath)
        {
            try
            {
                IPAddress ipAddress = null;
                int port = 0;

                string[] lines = File.ReadAllLines(iniFilePath);
                foreach (string line in lines)
                {
                    if (line.StartsWith("ServerAddress="))
                    {
                        var addressStr = line.Substring("ServerAddress=".Length).Trim();
                        if (addressStr == "localhost")
                        {
                            ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
                        } else
                        {
                            ipAddress = IPAddress.Parse(addressStr);
                        }
                    } else if (line.StartsWith("ServerPort="))
                    {
                        string portStr = line.Substring("ServerPort=".Length).Trim();
                        int.TryParse(portStr, out port);
                    }
                }
                if (ipAddress != null && port != 0)
                {
                    return new IPEndPoint(ipAddress, port);
                }
                return null;
            } catch
            {
                return null;
            }
        }
    }
}
