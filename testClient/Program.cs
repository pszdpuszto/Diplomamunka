using System.Net;
using UniversalForm.Client.Model;
using UniversalForm.Client.Persistence;

IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync(Dns.GetHostName());
IPAddress ipAddress = ipHostInfo.AddressList[0];
var model = new Model(new ClientJsonPersistence(Model.getQuestionTypes(), new(ipAddress, 3000)));

model.CreateDebugForm();
model.SaveForm();
model.LoadForm("Test_form.uff");

Console.WriteLine(model.GetTitle() + "\n" + model.GetDescription());
Question? q;
while ((q = model.NextQuestion()) != null)
{
    Console.WriteLine(q);
}

Console.ReadLine();
