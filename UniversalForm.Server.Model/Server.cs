using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using UniversalForm.Server.Persistence;
using UniversalForm.Utils;

namespace UniversalForm.Server.Model
{

    public class Server
    {
        private struct Client
        {
            public const int BUFFER_SIZE = 4096;
            public Client(Socket socket) { this.socket = socket; }
            public Socket socket;
            public byte[] buffer = new byte[BUFFER_SIZE];
            public StringBuilder sb = new();
        }

        private readonly string _hostName;
        private readonly int _port;
        private IPEndPoint _endPoint;

        private bool _running = false;

        private ManualResetEvent _threadSync = new(false);
        private ArrayList _peers = new();

        private IPersistence _persistence;
        public Server(string hostName, int port, IPersistence persistence)
        {
            _hostName = hostName;
            _port = port;

            _endPoint = CreateIPEndPoint().Result;

            _persistence = persistence;
        }

        public void Start()
        {
            if (_running) return;
            try
            {
                using Socket listener = new(
                    _endPoint.AddressFamily,
                    SocketType.Stream,
                    ProtocolType.Tcp
                    );
                listener.Bind(_endPoint);
                listener.Listen(100);

                _running = true;
                while (_running)
                {
                    _threadSync.Reset();
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    _threadSync.WaitOne();

                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            } 

        }

        public void Stop() { 
            _running = false;
            if (_peers.Count > 0)
            {
                Console.WriteLine($"Unfinished transactions: {_peers.Count}");
            }
            Console.WriteLine("Closed");
        }

        public bool RegisterAdmin(string userName, string password)
        {
            return _persistence.RegisterUser(userName, password);
        }
        public bool UsernameAvailable(string username)
        {
            return _persistence.CheckLogin(username, string.Empty) == IPersistence.LoginResult.USER_NOT_FOUND;
        }
        private string ProcessRequest(string jsonStr)
        {
            var request = JsonParser.Deserialize<Request>(jsonStr);
            switch (request.ID)
            {
                case Request.Type.GET_FORM:
                    var formStr = _persistence.GetJsonForm(request.FormName);
                    if (formStr == IPersistence.ERROR)
                    {
                        return JsonParser.Serialize<Response>(new Response
                        {
                            ID = Response.Type.ERROR,
                            JsonStr = "Form not found"
                        });
                    }
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.FORM,
                        JsonStr = _persistence.GetJsonForm(request.FormName)
                    });
                case Request.Type.SAVE_FORM:
                    if (_persistence.SaveForm(request.Username, request.FormName, request.JsonStr))
                    {
                        return JsonParser.Serialize<Response>(new Response
                        {
                            ID = Response.Type.ACKNOWLEDGE,
                            JsonStr = "Form saved"
                        });
                    }
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.ERROR,
                        JsonStr = "Error saving form"
                    });
                case Request.Type.SAVE_STATISTICS:
                    if (_persistence.SaveStatistics(request.FormName, request.JsonStr))
                        return JsonParser.Serialize<Response>(new Response
                        {
                            ID = Response.Type.ACKNOWLEDGE,
                            JsonStr = "Statistics saved"
                        });
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.ERROR,
                        JsonStr = "Error saving statistics"
                    });
                case Request.Type.GET_STATISTICS:
                    var statStr = _persistence.GetJsonStatistics(request.FormName);
                    if (statStr == IPersistence.ERROR)
                    {
                        return JsonParser.Serialize<Response>(new Response
                        {
                            ID = Response.Type.ERROR,
                            JsonStr = "Statistics not found"
                        });
                    }
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.STATISTICS,
                        JsonStr = _persistence.GetJsonStatistics(request.JsonStr)
                    });
                case Request.Type.LOGIN:
                    if (_persistence.CheckLogin(request.Username, request.JsonStr) == IPersistence.LoginResult.SUCCESS)
                        return JsonParser.Serialize<Response>(new Response
                        {
                            ID = Response.Type.ACKNOWLEDGE,
                            JsonStr = "Login successful"
                        });
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.ERROR,
                        JsonStr = "Login failed"
                    });
                case Request.Type.GET_FORM_LIST:
                    var formList = _persistence.GetForms(request.Username);
                    if (formList == IPersistence.ERROR)
                    {
                        return JsonParser.Serialize<Response>(new Response
                        {
                            ID = Response.Type.ERROR,
                            JsonStr = "Error getting form list"
                        });
                    }
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.FORM_LIST,
                        JsonStr = formList
                    });
                default:
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.ERROR,
                        JsonStr = "Unknown request type"
                    });
            }
        }

        private async Task<IPEndPoint> CreateIPEndPoint()
        {
            IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync(_hostName);
            IPAddress ipAddress = ipHostInfo.AddressList[0];

            return new IPEndPoint(ipAddress, _port);
        }

        private void Send(Socket handler, String data)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);

            handler.BeginSend(byteData,
                0,
                byteData.Length,
                SocketFlags.None,
                new AsyncCallback(SendCallback),
                handler);

        }

        private void AcceptCallback(IAsyncResult ar)
        {
            _threadSync.Set();
            Socket listener = (Socket)ar.AsyncState!;
            Socket handler = listener.EndAccept(ar);

            Client client = new(handler);
            lock (_peers.SyncRoot)
            {
                _peers.Add(handler.RemoteEndPoint);
            }
            
            Console.WriteLine($"Connected client: {handler.RemoteEndPoint}");
            handler.BeginReceive(
                client.buffer,
                0,
                Client.BUFFER_SIZE,
                SocketFlags.None,
                new AsyncCallback(ReadCallback),
                client
                );
        }

        private void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            Client client = (Client)ar.AsyncState!;

            int BytesRead;
            try
            {
                BytesRead = client.socket.EndReceive(ar);
            } catch
            {
                Console.WriteLine($"Disconnected client: {client.socket.RemoteEndPoint}");
                lock (_peers.SyncRoot)
                {
                    _peers.Remove(client.socket.RemoteEndPoint);
                }
                client.socket.Close();
                return;
            }

            if (BytesRead > 0)
            {
                client.sb.Append(Encoding.UTF8.GetString(client.buffer, 0, BytesRead));
                content = client.sb.ToString();
                if (content.IndexOf(JsonParser.EOT) > -1)
                {
                    content = content.Substring(0, content.IndexOf(JsonParser.EOT));
                    Console.WriteLine($"Read {content.Length} bytes of data: {content}");

                    var responseJsonStr = ProcessRequest(content) + JsonParser.EOT;

                    Send(client.socket, responseJsonStr);
                    Console.WriteLine($"Sent {responseJsonStr.Length} bytes of data: {responseJsonStr}");

                    client.sb.Clear();
                }
                //else
                //{
                    client.socket.BeginReceive(
                        client.buffer,
                        0,
                        Client.BUFFER_SIZE,
                        SocketFlags.None,
                        new AsyncCallback(ReadCallback),
                        client
                        );
                //}
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState!;
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine($"Sent {bytesSent} bytes to client.");

                /*lock (_peers.SyncRoot)
                {
                    _peers.Remove(handler.RemoteEndPoint);
                }
                handler.Shutdown(SocketShutdown.Both);
                Console.WriteLine($"Disconnected client: {handler.RemoteEndPoint}");
                handler.Close();*/

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
