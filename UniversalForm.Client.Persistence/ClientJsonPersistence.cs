using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UniversalForm.JsonUtil;

namespace UniversalForm.Client.Persistence
{
    public class ClientJsonPersistence : JsonPersistence
    {
        private readonly IPEndPoint _endPoint;
        private Socket Server { get
            {
                if (!field.Connected)
                {
                    field.Connect(_endPoint);
                    Console.WriteLine($"Connected: {_endPoint.Address}:{_endPoint.Port}");
                }
                return field;
            }
            init;
        }
        public ClientJsonPersistence(IEnumerable<Type> questionTypes, IPEndPoint endPoint) : base(questionTypes)
        {
            _endPoint = endPoint;
            Server = new(
                endPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);
        }

        protected override string GetId(Form form)
        {
            return form.Title.Replace(' ', '_');
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

        protected override bool SaveJson(string id, string jsonStr)
        {
            var request = new Request
            {
                ID = Request.Type.GET_FORM,
                FormName = id,
                JsonStr = jsonStr
            };
            var response = SendAndRecieve(request);
            return response.ID == Response.Type.ACKNOWLEDGE;
        }
        private Response SendAndRecieve(Request request)
        {
            Server.Send(Encoding.UTF8.GetBytes(JsonParser.Serialize(request) + JsonParser.EOT));
            var buffer = new byte[BUFFER_SIZE];
            var sb = new StringBuilder();
            do
            {
                _ = Server.Receive(buffer, SocketFlags.None);
                sb.Append(Encoding.UTF8.GetString(buffer));
            } while (sb.ToString().IndexOf(JsonParser.EOT) < 0);
            var response = sb.ToString();
            return JsonParser.Deserialize<Response>(response.Substring(0, response.IndexOf(JsonParser.EOT)));
        }
    }
}
