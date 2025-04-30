using System.Net;
using UniversalForm.Client.Model;
using UniversalForm.Client.Persistence;

IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync(Dns.GetHostName());
IPAddress ipAddress = ipHostInfo.AddressList[0];
var model = new FormModel(new ClientJsonPersistence(FormModel.getQuestionTypes(), new(ipAddress, 3000)));


model.LogIn("testUser", "testPassword");
model.LogIn("admin1", "password1");
model.CreateDebugForm(); 
model.SaveForm();
model.ResetForm();
model.LoadForm("Test_form");

Console.WriteLine(model.Title + "\n" + model.Description);
Question? q;
while ((q = model.NextQuestion()) != null)
{
    Console.WriteLine(q);
}

Console.ReadLine();
