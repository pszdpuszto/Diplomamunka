namespace UniversalForm.Server.Persistence
{
    public interface IPersistence
    {
        public enum LoginResult
        {
            SUCCESS,
            USER_NOT_FOUND,
            PASSWORD_INCORRECT,
            IO_ERROR
        }
        public const string ERROR = "ERROR";
        public bool RegisterUser(string userName, string password);
        public LoginResult CheckLogin(string userName, string password);
        public string GetJsonForm(string formName);
        public string GetJsonStatistics(string formName);
        public bool SaveForm(string userName, string formName, string jsonStr);
        public bool SaveStatistics(string formName, string jsonStr);
        public string GetForms(string userName);
        public bool DeleteForm(string userName, string formName);
        public bool DeleteUser(string userName);
    }
}
