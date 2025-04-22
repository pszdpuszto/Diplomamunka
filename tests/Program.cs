using UniversalForm.Persistence;
using UniversalForm.Model;
using System.Text.Json;

var types = typeof(Model).Assembly.GetTypes().Where(t => t.BaseType == typeof(Question)).ToArray();


Console.WriteLine(types);
//var form = new Form("Test form", "test description");
//for (int i = 0; i < 5; i++)
//{
//    form.AddQuestion(new QTextArea("Title for q" + i, "desc\n\n\n\nfarrt", "defText"));
//}
//for (int i = 0;i < 5;i++)
//{
//    form.AddQuestion(new QSingleSelect("Title for q" + (i + 5), "desc\n\n\n\nfarrt", new List<string> { "option1", "option2", "wow3"}));
//}



