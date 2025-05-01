using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UniversalForm.Client.Persistence;
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
            var request = JsonParser.Deserialize<Request>(jsonStr);
            switch (request.ID)
            {
                case Request.Type.GET_FORM:
                    Assert.AreEqual(request.FormName, TestValues.FormName, "Username mismatch");
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.FORM,
                        JsonStr = TestValues.FormString
                    });
                case Request.Type.SAVE_FORM:
                    Assert.AreEqual(request.Username, TestValues.UserName, "Username mismatch");
                    Assert.AreEqual(request.FormName, TestValues.FormName, "Form name mismatch");
                    Assert.AreEqual(request.JsonStr, TestValues.FormString, "Form string mismatch");
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.ACKNOWLEDGE,
                        JsonStr = "Form saved"
                    });
                case Request.Type.DELETE_FORM:
                    Assert.AreEqual(request.Username, TestValues.UserName, "Username mismatch");
                    Assert.AreEqual(request.FormName, TestValues.FormName, "Form name mismatch");
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.ACKNOWLEDGE,
                        JsonStr = "Form deleted"
                    });
                case Request.Type.SAVE_STATISTICS:
                    Assert.AreEqual(request.Username, TestValues.UserName, "Username mismatch");
                    Assert.AreEqual(request.FormName, TestValues.FormName, "Form name mismatch");
                    Assert.AreEqual(DatePatcher(request.JsonStr), TestValues.StatisticsListString, "Statistics mismatch");
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.ACKNOWLEDGE,
                        JsonStr = "Statistics saved"
                    });
                case Request.Type.GET_STATISTICS:
                    Assert.AreEqual(request.FormName, TestValues.FormName, "Username mismatch");
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.STATISTICS,
                        JsonStr = TestValues.StatisticsString
                    });
                case Request.Type.LOGIN:
                    Assert.AreEqual(request.Username, TestValues.UserName, "Username mismatch");
                    Assert.AreEqual(request.JsonStr, TestValues.Password, "Password mismatch");
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.ACKNOWLEDGE,
                        JsonStr = "Login successful"
                    });
                case Request.Type.GET_FORM_LIST:
                    Assert.AreEqual(request.Username, TestValues.UserName, "Username mismatch");
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.FORM_LIST,
                        JsonStr = TestValues.FormListString
                    });
                default:
                    return JsonParser.Serialize<Response>(new Response
                    {
                        ID = Response.Type.ERROR,
                        JsonStr = "Unknown request type"
                    });
            }
        }

        public static string DatePatcher(string json)
        {
            // Nem ideális, de egyszerű
            var jsonObj = JsonParser.Deserialize<FillStatistic>(json);
            jsonObj.Date = DateTime.Parse(TestValues.DatePatch);
            return JsonParser.Serialize(jsonObj);
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
