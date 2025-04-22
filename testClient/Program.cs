using UniversalForm.Model;
using UniversalForm.Persistence;

var model = new Model(new BinaryFileJsonPersistence(Model.getQuestionTypes()));

model.CreateDebugForm();
model.SaveForm();
model.LoadForm("Test_form.uff");

Console.WriteLine(model.GetTitle() + "\n" + model.GetDescription());
Question? q;
while ((q = model.NextQuestion()) != null)
{
    Console.WriteLine(q);
}
