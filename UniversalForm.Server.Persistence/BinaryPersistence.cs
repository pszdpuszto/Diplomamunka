using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalForm.Utils;

namespace UniversalForm.Server.Persistence
{
    public class BinaryPersistence : IPersistence
    {
        public struct User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public List<string> Forms { get; set; }
        }
        private static readonly string FORM_EXTENSION = "uff";
        private static readonly string STAT_EXTENSION = "ufs";
        private static readonly string USER_EXTENSION = "ufu";
        readonly string _dirPath;
        public BinaryPersistence(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
            _dirPath = dirPath;
        }
        public string GetJsonForm(string formName)
        {
            var fileName = GetFileLocation(formName, FORM_EXTENSION);
            if (!File.Exists(fileName))
                return IPersistence.ERROR;
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader r = new BinaryReader(fs))
                    {
                        return r.ReadString();
                    }
                }
            }
            catch
            {
                return IPersistence.ERROR;
            }
        }
        public string GetJsonStatistics(string formName)
        {
            var fileName = GetFileLocation(formName, STAT_EXTENSION);
            if (!File.Exists(fileName))
                return IPersistence.ERROR;
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader r = new BinaryReader(fs))
                    {
                        return r.ReadString();
                    }
                }
            }
            catch
            {
                return IPersistence.ERROR;
            }
        }
        public bool SaveForm(string userName, string formName, string jsonStr)
        {
            var userFileName = GetFileLocation(userName, USER_EXTENSION);
            var formFileName = GetFileLocation(formName, FORM_EXTENSION);
            if (!File.Exists(userFileName))
                return false;
            /* save form */
            if (File.Exists(formFileName))
                File.Delete(formFileName);
            try
            {
                using (var fs = new FileStream(formFileName, FileMode.CreateNew))
                {
                    using (var bw = new BinaryWriter(fs))
                    {
                        bw.Write(jsonStr);
                    }
                }
                System.Console.WriteLine($"Saved {formName}");
            }
            catch
            {
                return false;
            }
            /* update user form list */
            try
            {
                var user = LoadUser(userName);
                if (!user.HasValue)
                    return false;
                user.Value.Forms.Add(formName);
                using (var fs = new FileStream(userFileName, FileMode.Create))
                {
                    using (var bw = new BinaryWriter(fs))
                    {
                        bw.Write(JsonParser.Serialize(user.Value));
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool SaveStatistics(string formName, string jsonStr)
        {
            var fileName = GetFileLocation(formName, STAT_EXTENSION);
            if (File.Exists(fileName))
                File.Delete(fileName);
            try
            {
                using (var fs = new FileStream(fileName, FileMode.CreateNew))
                {
                    using (var bw = new BinaryWriter(fs))
                    {
                        bw.Write(jsonStr);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IPersistence.LoginResult CheckLogin(string username, string password)
        {
            var fileName = GetFileLocation(username, USER_EXTENSION);
            if (!File.Exists(fileName))
                return IPersistence.LoginResult.USER_NOT_FOUND;
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader r = new BinaryReader(fs))
                    {
                        var str = r.ReadString();
                        var user = JsonParser.Deserialize<User>(str);
                        return PasswordHasher.VerifyPassword(password, user.Password) ? IPersistence.LoginResult.SUCCESS : IPersistence.LoginResult.PASSWORD_INCORRECT;
                    }
                }
            }
            catch
            {
                return IPersistence.LoginResult.IO_ERROR;
            }
        }
        public bool RegisterUser(string username, string password)
        {
            var fileName = GetFileLocation(username, USER_EXTENSION);
            if (File.Exists(fileName))
                return false;
            try
            {
                using (var fs = new FileStream(fileName, FileMode.CreateNew))
                {
                    using (var bw = new BinaryWriter(fs))
                    {
                        var user = new User
                        {
                            Username = username,
                            Password = PasswordHasher.HashPassword(password),
                            Forms = new List<string>()
                        };
                        bw.Write(JsonParser.Serialize(user));
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetFileLocation(string formName, string extension)
        {
            return _dirPath + "/" + formName + "." + extension;
        }

        private User? LoadUser(string username)
        {
            var fileName = GetFileLocation(username, USER_EXTENSION);
            if (!File.Exists(fileName))
                return null;
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    using (var bw = new BinaryReader(fs))
                    {
                        return JsonParser.Deserialize<User>(bw.ReadString());
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public string GetForms(string userName)
        {
            var user = LoadUser(userName);
            if (user == null)
                return IPersistence.ERROR;
            return JsonParser.Serialize(user.Value.Forms);
        }
    }
}
