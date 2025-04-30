using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UniversalForm.Utils;

namespace UniversalForm.Client.Persistence
{
    public class ClientJsonPersistence : JsonPersistence
    {
        public event EventHandler<ClientJsonPersistence>? ConnectionLost;
        private readonly IPEndPoint _endPoint;
        private Socket _server;
        public ClientJsonPersistence(IEnumerable<Type> questionTypes, IPEndPoint endPoint) : base(questionTypes)
        {
            _endPoint = endPoint;
            _server = new(
                endPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);
            _server.Connect(endPoint);
        }
        private Response SendAndRecieve(Request request)
        {
            try
            {
                _server.Send(Encoding.UTF8.GetBytes(JsonParser.Serialize(request) + JsonParser.EOT));
                var buffer = new byte[BUFFER_SIZE];
                var sb = new StringBuilder();
                do
                {
                    _ = _server.Receive(buffer, SocketFlags.None);
                    sb.Append(Encoding.UTF8.GetString(buffer));
                } while (sb.ToString().IndexOf(JsonParser.EOT) < 0);
                var response = sb.ToString();
                return JsonParser.Deserialize<Response>(response.Substring(0, response.IndexOf(JsonParser.EOT)));
            } catch (SocketException)
            {
                ConnectionLost?.Invoke(this, this);
                return new Response
                {
                    ID = Response.Type.ERROR,
                    JsonStr = ERROR
                };
            }
        }
        public bool Reconnect()
        {
            _server = new(
                _endPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);
            try
            {
                _server.Connect(_endPoint);
            } catch
            {
                return false;
            }
            return true;
        }

        private static readonly int BUFFER_SIZE = 4096;
        protected override string LoadJson(string name)
        {
            System.Console.WriteLine($"Loading {name}");
            var request = new Request
            {
                ID = Request.Type.GET_FORM,
                FormName = name,
                JsonStr = string.Empty
            };
            var response = SendAndRecieve(request);
            if (response.ID == Response.Type.FORM)
                return response.JsonStr;
            return ERROR;
        }

        protected override bool SaveJson(string userName, string id, string jsonStr)
        {
            var request = new Request
            {
                ID = Request.Type.SAVE_FORM,
                FormName = id,
                Username = userName,
                JsonStr = jsonStr
            };
            var response = SendAndRecieve(request);
            return response.ID == Response.Type.ACKNOWLEDGE;
        }

        public override bool LogIn(string userName, string password)
        {
            var request = new Request
            {
                ID = Request.Type.LOGIN,
                Username = userName,
                JsonStr = password
            };
            var response = SendAndRecieve(request);
            return response.ID == Response.Type.ACKNOWLEDGE;
        }

        public override string GetFormsJson(string username)
        {
            var request = new Request
            {
                ID = Request.Type.GET_FORM_LIST,
                Username = username
            };
            var response = SendAndRecieve(request);
            if (response.ID == Response.Type.FORM_LIST)
                return response.JsonStr;
            return ERROR;
        }

        protected override bool SaveJsonStat(string userName, string formName, string jsonStr)
        {
            var request = new Request
            {
                ID = Request.Type.SAVE_STATISTICS,
                FormName = formName,
                Username = userName,
                JsonStr = jsonStr
            };
            var response = SendAndRecieve(request);
            return response.ID == Response.Type.ACKNOWLEDGE;
        }

        public override bool DeleteForm(string userName, string formName)
        {
            var request = new Request
            {
                ID = Request.Type.DELETE_FORM,
                Username = userName,
                FormName = formName
            };
            var response = SendAndRecieve(request);
            return response.ID == Response.Type.ACKNOWLEDGE;
        }

        protected override string LoadJsonStat(string formName)
        {
            var request = new Request
            {
                ID = Request.Type.GET_STATISTICS,
                FormName = formName
            };
            var response = SendAndRecieve(request);
            if (response.ID == Response.Type.STATISTICS)
                return response.JsonStr;
            return ERROR;
        }
    }
}
