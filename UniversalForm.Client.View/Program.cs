using System.Net;
using UniversalForm.Client.Model;
using UniversalForm.Client.Persistence;
using UniversalForm.Utils;

namespace UniversalForm.Client.View;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var endPoint = IniReader.ReadServerAddress("settings.ini");
        if (endPoint == null)
        {
            MessageBox.Show("Invalid server address in settings.ini");
            return;
        }
        var persistence = new ClientJsonPersistence(Model.FormModel.getQuestionTypes(), endPoint);
        var model = new Model.FormModel(persistence);
        var view = new Menu(model);
        Application.Run(view);
    }
}

