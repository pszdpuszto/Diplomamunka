using System.Net;
using System.Net.Sockets;

namespace UniversalForm.Utils
{
    public class IniReader
    {
        private string[] lines;
        public bool InitSuccess { get; private set; } = false;
        public IniReader(string iniFilePath)
        {
            try
            {
                lines = File.ReadAllLines(iniFilePath);
                InitSuccess = true;
            }
            catch
            {
                lines = [
                    "ServerAddress=localhost",
                    "ServerPort=3000",
                    "Verbose=0"
                    ];
            }
        }
        public IPEndPoint? ReadServerAddress()
        {
            try
            {
                IPAddress? ipAddress = null;
                int port = 0;

                foreach (string line in lines)
                {
                    if (line.StartsWith("ServerAddress="))
                    {
                        var addressStr = line.Substring("ServerAddress=".Length).Trim();
                        if (addressStr == "localhost")
                        {
                            ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
                        }
                        else if (addressStr == "automatic")
                        {
                            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                            {
                                socket.Connect("8.8.8.8", 65530);
                                IPEndPoint? endPoint = socket.LocalEndPoint as IPEndPoint;
                                if (endPoint == null)
                                    return null;
                                ipAddress = endPoint.Address;
                            }
                        }
                        else
                        {
                            ipAddress = IPAddress.Parse(addressStr);
                        }
                    }
                    else if (line.StartsWith("ServerPort="))
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
            }
            catch
            {
                return null;
            }
        }
        public bool IsVerbose()
        {
            foreach (string line in lines)
            {
                if (line.StartsWith("Verbose="))
                {
                    var verboseStr = line.Substring("Verbose=".Length).Trim().ToLower();
                    return verboseStr != "false" && verboseStr != "0";
                }
            }
            return false;
        }
    }
}
