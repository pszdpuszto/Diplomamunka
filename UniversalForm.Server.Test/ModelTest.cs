using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UniversalForm.Server.Model;
using UniversalForm.Server.Persistence;
using UniversalForm.Utils;

namespace UniversalForm.Server.Test
{
    internal class FakeClient
    {
        private const int BUFFER_SIZE = 4096;
        private Socket _socket;
        public FakeClient(IPEndPoint endPoint)
        {
            _socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(endPoint);
        }
        public Response SendAndReceive (Request request)
        {
            _socket.Send(Encoding.UTF8.GetBytes(JsonParser.Serialize(request) + JsonParser.EOT));
            var buffer = new byte[BUFFER_SIZE];
            var sb = new StringBuilder();
            do
            {
                _ = _socket.Receive(buffer, SocketFlags.None);
                sb.Append(Encoding.UTF8.GetString(buffer));
            } while (sb.ToString().IndexOf(JsonParser.EOT) < 0);
            var response = sb.ToString();
            return JsonParser.Deserialize<Response>(response.Substring(0, response.IndexOf(JsonParser.EOT)));
        }
    }
    internal class FakePersistence : IPersistence
    {
        public string[] ExpectedResults { get; set; } = new string[0];
        public const string expectedString = "expectedString";
        public IPersistence.LoginResult CheckLogin(string userName, string password)
        {
            Assert.AreEqual(ExpectedResults[0], userName, "User name mismatch");
            Assert.AreEqual(ExpectedResults[1], password, "Password mismatch");
            return IPersistence.LoginResult.SUCCESS;
        }

        public bool DeleteForm(string userName, string formName)
        {
            Assert.AreEqual(ExpectedResults[0], userName, "User name mismatch");
            Assert.AreEqual(ExpectedResults[1], formName, "Form name mismatch");
            return true;
        }

        public bool DeleteUser(string userName)
        {
            Assert.AreEqual(ExpectedResults[0], userName, "User name mismatch");
            return true;
        }

        public string GetForms(string userName)
        {
            Assert.AreEqual(ExpectedResults[0], userName, "User name mismatch");
            return expectedString;
        }

        public string GetJsonForm(string formName)
        {
            Assert.AreEqual(ExpectedResults[0], formName, "Form name mismatch");
            return expectedString;
        }

        public string GetJsonStatistics(string formName)
        {
            Assert.AreEqual(ExpectedResults[0], formName, "Form name mismatch");
            return expectedString;
        }

        public bool RegisterUser(string userName, string password)
        {
            Assert.AreEqual(ExpectedResults[0], userName, "User name mismatch");
            Assert.AreEqual(ExpectedResults[1], password, "Password mismatch");
            return true;
        }

        public bool SaveForm(string userName, string formName, string jsonStr)
        {
            Assert.AreEqual(ExpectedResults[0], userName, "User name mismatch");
            Assert.AreEqual(ExpectedResults[1], formName, "Form name mismatch");
            Assert.AreEqual(ExpectedResults[2], jsonStr, "Json string mismatch");
            return true;
        }

        public bool SaveStatistics(string formName, string jsonStr)
        {
            Assert.AreEqual(ExpectedResults[0], formName, "Form name mismatch");
            Assert.AreEqual(ExpectedResults[1], jsonStr, "Json string mismatch");
            return true;
        }
    }
    [TestClass]
    public sealed class ModelTest
    {
        internal struct TestCase
        {
            public string[] expectedResults;
            public Request request;
            public Response expectedResponse;
        }

        private List<TestCase> testCases = new()
        {
            new TestCase // login
            {
                expectedResults = new string[] { "user", "password" },
                request = new Request
                {
                    ID = Request.Type.LOGIN,
                    Username = "user",
                    JsonStr = "password"
                },
                expectedResponse = new Response
                {
                    ID = Response.Type.ACKNOWLEDGE,
                    JsonStr = "Login successful"
                }
            },
            new TestCase // get form
            {
                expectedResults = new string[] { "form" },
                request = new Request
                {
                    ID = Request.Type.GET_FORM,
                    FormName = "form",
                    JsonStr = string.Empty
                },
                expectedResponse = new Response
                {
                    ID = Response.Type.FORM,
                    JsonStr = FakePersistence.expectedString
                }
            },
            new TestCase // save form
            {
                expectedResults = new string[] { "user", "form", FakePersistence.expectedString },
                request = new Request
                {
                    ID = Request.Type.SAVE_FORM,
                    Username = "user",
                    FormName = "form",
                    JsonStr = FakePersistence.expectedString
                },
                expectedResponse = new Response
                {
                    ID = Response.Type.ACKNOWLEDGE,
                    JsonStr = "Form saved"
                }
            },
            new TestCase // get statistics
            {
                expectedResults = new string[] { "form" },
                request = new Request
                {
                    ID = Request.Type.GET_STATISTICS,
                    FormName = "form",
                    JsonStr = string.Empty
                },
                expectedResponse = new Response
                {
                    ID = Response.Type.STATISTICS,
                    JsonStr = FakePersistence.expectedString
                }
            },
            new TestCase // save statistics
            {
                expectedResults = new string[] { "form", FakePersistence.expectedString },
                request = new Request
                {
                    ID = Request.Type.SAVE_STATISTICS,
                    FormName = "form",
                    JsonStr = FakePersistence.expectedString
                },
                expectedResponse = new Response
                {
                    ID = Response.Type.ACKNOWLEDGE,
                    JsonStr = "Statistics saved"
                }
            },
            new TestCase // delete form
            {
                expectedResults = new string[] { "user", "form" },
                request = new Request
                {
                    ID = Request.Type.DELETE_FORM,
                    Username = "user",
                    FormName = "form",
                    JsonStr = string.Empty
                },
                expectedResponse = new Response
                {
                    ID = Response.Type.ACKNOWLEDGE,
                    JsonStr = "Form deleted"
                }
            },
            new TestCase // get form list
            {
                expectedResults = new string[] { "user" },
                request = new Request
                {
                    ID = Request.Type.GET_FORM_LIST,
                    Username = "user",
                    FormName = string.Empty,
                    JsonStr = string.Empty
                },
                expectedResponse = new Response
                {
                    ID = Response.Type.FORM_LIST,
                    JsonStr = FakePersistence.expectedString
                }
            }
        };

        [TestMethod]
        public void TestAll()
        {
            var persistence = new FakePersistence();
            IniReader iniReader = new IniReader(null);
            var server = new Model.Server(iniReader.ReadServerAddress()!, false, persistence);
            Task.Run(() => server.Start());
            var client = new FakeClient(iniReader.ReadServerAddress()!);
            foreach (var testCase in testCases)
            {
                persistence!.ExpectedResults = testCase.expectedResults;
                Response response = client!.SendAndReceive(testCase.request);
                Assert.AreEqual(testCase.expectedResponse, response, "Response different than expected");
            }
            server.Stop();
        }
    }
}
