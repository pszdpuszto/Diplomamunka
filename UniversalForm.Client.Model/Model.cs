using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.Model
{
    public class Model
    {
        public static IEnumerable<Type> getQuestionTypes() => typeof(Model).Assembly.GetTypes().Where(t => t.BaseType == typeof(Question)).ToList();

        IPersistence _persistence;
        Form? _form;
        string? _userName;

        public Model(IPersistence persistence) 
        {
            _persistence = persistence;
        }

        public bool LogIn(string userName, string password)
        {
            if (_persistence.LogIn(userName, password))
            {
                _userName = userName;
                return true;
            }
            return false;
        }

        public bool LoadForm(string  formName)
        {
            var newForm = _persistence.LoadForm(formName);
            if (newForm == null)
                return false;
            _form = newForm;
            return true;
        }

        public bool SaveForm()
        {
            if (_form == null || _userName == null) 
                return false;
            return _persistence.SaveForm(_userName, _form);
        }

        public void CreateDebugForm()
        {
            Question[] qs = new Question[10];
            for (int i = 0; i < 5; i++)
            {
                qs[i]= new QTextArea("Title for q" + i, "desc\n\n\n\nfarrt", "defText");
            }
            for (int i = 0; i < 5; i++)
            {
                qs[5+i] = new QSingleSelect("Title for q" + (i + 5), "desc\n\n\n\nfarrt", new List<string> { "option1", "option2", "wow3" });
            }
            _form = new Form("Test form", "test description", [.. qs]);
        }

        public void ResetForm()
        {
            _form = null;
        }

        public string GetTitle() => (_form == null) ? "" : _form.Title;
        public string GetDescription() => (_form == null) ? "" : _form.Description;
        public Question? NextQuestion() => _form?.NextQuestion();
        public Question? PreviousQuestion() => _form?.PreviousQuestion();
    }
}
