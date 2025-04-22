
using System.Net.Sockets;
using System.Net;
using System.Text;


IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync(Dns.GetHostName());
IPAddress ipAddress = ipHostInfo.AddressList[0];

var ipEndPoint =  new IPEndPoint(ipAddress, 3000);

using Socket client = new(
    ipEndPoint.AddressFamily,
    SocketType.Stream,
    ProtocolType.Tcp);

await client.ConnectAsync(ipEndPoint);
Console.WriteLine($"Connected: {ipEndPoint.Address}:{ipEndPoint.Port}");
var message = "";
while (message.IndexOf("<|EOF|>") < 0)
{
    // Send message.
    message = Console.ReadLine();
    var messageBytes = Encoding.UTF8.GetBytes(message);
    _ = await client.SendAsync(messageBytes, SocketFlags.None);
    Console.WriteLine($"Socket client sent message: \"{message}\"");
}

// Receive ack.
var buffer = new byte[1_024];
var received = await client.ReceiveAsync(buffer, SocketFlags.None);
var response = Encoding.UTF8.GetString(buffer, 0, received);

Console.WriteLine(response);

Console.Read();

client.Shutdown(SocketShutdown.Both);