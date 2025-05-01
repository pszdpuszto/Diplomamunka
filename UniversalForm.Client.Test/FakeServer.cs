using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UniversalForm.Utils;

namespace UniversalForm.Client.Test
{ 

    public class FakeServer
        {
        private struct Client
        {
            public const int BUFFER_SIZE = 4096;
            public Client(Socket socket) { this.socket = socket; }
            public Socket socket;
            public byte[] buffer = new byte[BUFFER_SIZE];
            public StringBuilder sb = new();
        }

        private IPEndPoint _endPoint;

        private bool _running = false;

        private ManualResetEvent _threadSync = new(false);
        private ArrayList _peers = new();

        public event EventHandler<string>? LogEvent;
        public FakeServer(IPEndPoint endPoint)
        {

            _endPoint = endPoint;
        }

        public void Start()
        {
            if (_running) return;
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
                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                _threadSync.WaitOne();

            }
        }

        public void Stop()
        {
            _running = false;
        }
        private string ProcessRequest(string jsonStr)
        {
            /*var request = JsonParser.Deserialize<Request>(jsonStr);
            switch (request.ID)
            {
                case Request.Type.GET_FORM:

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
                case Request.Type.DELETE_FORM:
                    if (_persistence.DeleteForm(request.Username, request.FormName))
                    {
                        return JsonParser.Serialize<Response>(new Response
                        {
                            ID = Response.Type.ACKNOWLEDGE,
                            JsonStr = "Form deleted"
                        });
                    }
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.ERROR,
                        JsonStr = "Error deleting form"
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
                        JsonStr = statStr
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
            }*/
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
            }
            catch
            {
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

                    var responseJsonStr = ProcessRequest(content) + JsonParser.EOT;

                    Send(client.socket, responseJsonStr);

                    client.sb.Clear();
                }

                client.socket.BeginReceive(
                    client.buffer,
                    0,
                    Client.BUFFER_SIZE,
                    SocketFlags.None,
                    new AsyncCallback(ReadCallback),
                    client
                    );
            }
        }

        private void SendCallback(IAsyncResult ar)
        {

            Socket handler = (Socket)ar.AsyncState!;
            int bytesSent = handler.EndSend(ar);
        }
    }
}
