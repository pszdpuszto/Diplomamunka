using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.Model
{
    public class FormModel
    {
        public static IEnumerable<Type> getQuestionTypes() => typeof(FormModel).Assembly.GetTypes().Where(t => t.BaseType == typeof(Question)).ToList();

        IPersistence _persistence;
        StatisticsModel? _statisticsModel;
        string _formName = string.Empty;
        private Form? _form { get; set {
                _statisticsModel = (value != null) ? new(value) : null; 
                if (value != null && value.Anonymous)
                    UserName = "ANON";
                field = value; 
            } } = null;
        public int Index { get; private set; } = 0;
        public string? UserName { get; private set; }
        public void SetUserName(string userName)
        {
            if (_form != null && _form.Anonymous == false)
                UserName = userName;
        }

        public FormModel(IPersistence persistence) 
        {
            _persistence = persistence;
        }
        public void CreateEmptyForm(string formName)
        {
            _formName = formName;
            _form = new Form("", "", new());
        }
        public bool FormExists(string formName)
        {
            return _persistence.LoadForm(formName) != null;
        }

        public bool LogIn(string userName, string password)
        {
            if (_persistence.LogIn(userName, password))
            {
                UserName = userName;
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
            _formName = formName;
            return true;
        }

        public bool SaveForm()
        {
            if (_form == null || UserName == null) 
                return false;
            return _persistence.SaveForm(UserName, _formName, _form);
        }
        public List<string>? GetFormList()
        {
            if (UserName == null)
                return null;
            return _persistence.GetForms(UserName);
        }
        public bool SaveFormStatistics()
        {
            if (_form == null || _statisticsModel == null)
                return false;
            return _persistence.SaveFormStatistics(UserName!, _formName, _statisticsModel.QStatistics);
        }
        public bool DeleteForm(string formName)
        {
            if (UserName == null)
                return false;
            return _persistence.DeleteForm(UserName, formName);
        }
        public Statistics GetStatisticsOfCurrentQuestion()
        {
            if (_form == null || _statisticsModel == null)
                return new Statistics();
            return _statisticsModel.GetStatistics(Index);
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
                qs[5+i] = new QSingleSelect("Title for q" + (i + 5), "desc\n\n\n\nfarrt", new List<string> { "option1", "option2", "wow3" }, true);
            }
            _form = new Form("TestForm2", "test description", [.. qs]);
        }

        public void ResetForm()
        {
            _form = null;
            UserName = string.Empty;
        }

        public string Title
        {
            get
            {
                return (_form == null) ? "" : _form.Title;
            }
            set
            {
                if (_form != null)
                    _form.Title = value;
            }
        }
        public string Description 
        {
            get
            {
                return (_form == null) ? "" : _form.Description;
            }
            set
            {
                if (_form != null)
                    _form.Description = value;
            }
        }
        public bool HasQuestion() => (_form == null) ? false : _form.GetQuestion(Index) != null;
        public Question? FirstQuestion()
        { 
            var firstQuestion = _form?.GetQuestion(0);
            if (firstQuestion != null)
                Index = 0;
           return firstQuestion;
        }
        public Question? CurrentQuestion()
        {
            return _form?.GetQuestion(Index);
        }
        public bool HasNextQuestion() => (_form == null) ? false : _form.GetQuestion(Index + 1 ) != null;
        public Question? NextQuestion()
        {
            var nextQuestion = _form?.GetQuestion(Index + 1);
            if (nextQuestion != null)
            {
                Index++;
                return nextQuestion;
            }
            return null;
        }
        public bool HasPreviousQuestion() => (_form == null) ? false : _form.GetQuestion(Index - 1) != null;
        public Question? PreviousQuestion()
        {
            var previousQuestion = _form?.GetQuestion(Index - 1);
            if (previousQuestion != null)
            {
                Index--;
                return previousQuestion;
            }
            return null;
        }
        public void AddQuestion(Question q)
        {
            if (_form != null)
                _form.AddQuestion(q);
        }
        public void RemoveQuestion(Question q)
        {
            if (_form != null && _form.RemoveQuestion(q) && Index != 0)
               Index--;
        }
        public bool IsAnonymous()
        {
            return (_form == null) ? true : _form.Anonymous;
        }
        public bool Anonymous
        {
            get
            {
                return (_form == null) ? false : _form.Anonymous;
            }
            set
            {
                if (_form != null)
                    _form.Anonymous = value;
            }
        }
        public bool MeasureCorrections
        {
            get
            {
                return (_form == null) ? false : _form.MeasureCorrections;
            }
            set
            {
                if (_form != null)
                    _form.MeasureCorrections = value;
            }
        }
        public bool MeasureTime
        {
            get
            {
                return (_form == null) ? false : _form.MeasureTime;
            }
            set
            {
                if (_form != null)
                    _form.MeasureTime = value;
            }
        }
        public bool FocusTracking
        {
            get
            {
                return (_form == null) ? false : _form.FocusTracking;
            }
            set
            {
                if (_form != null)
                    _form.FocusTracking = value;
            }
        }
    }
}
