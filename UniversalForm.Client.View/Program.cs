using System.Net.Sockets;
using UniversalForm.Client.Persistence;
using UniversalForm.Utils;

namespace UniversalForm.Client.View;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var iniReader = new IniReader("settings.ini");
        if (!iniReader.InitSuccess)
        {
            var result = MessageBox.Show("Failed to read settings.ini, default values are used. Continue?", "settings.ini error", MessageBoxButtons.YesNo); ;
            if (result == DialogResult.No)
                return;

        }
        var endPoint = iniReader.ReadServerAddress();
        if (endPoint == null)
        {
            MessageBox.Show("Invalid server address in settings.ini", "settings.ini error");
            return;
        }
        ClientJsonPersistence persistence;
        try
        {
            persistence = new ClientJsonPersistence(Model.FormModel.getQuestionTypes(), endPoint);
        }
        catch (SocketException)
        {
            MessageBox.Show("Unable to connect to the server.", "Connection error");
            return;
        }
        persistence.ConnectionLost += ConnectionLost;
        var model = new Model.FormModel(persistence);
        var view = new Menu(model);
        Application.Run(view);
    }

    static void ConnectionLost(object? sender, ClientJsonPersistence e)
    {
        var retry = new ConnectionLost(e);
        retry.ShowDialog();
        if (retry.FullExit)
        {
            Application.Exit();
        }
    }
}

