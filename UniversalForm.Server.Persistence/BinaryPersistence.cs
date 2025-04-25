using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UniversalForm.Server.Persistence
{
    public class BinaryPersistence : IPersistence
    {
        private static readonly string FORM_EXTENSION = "uff";
        private static readonly string STAT_EXTENSION = "ufs";
        readonly string _dirPath;
        public BinaryPersistence(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
            _dirPath = dirPath;
        }
        public string GetJsonForm(string formName)
        {
            if (!File.Exists(formName))
                return IPersistence.ERROR;
            try
            {
                using (FileStream fs = new FileStream(GetFileLocation(formName, FORM_EXTENSION), FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader r = new BinaryReader(fs))
                    {
                        return r.ReadString();
                    }
                }
            } catch
            {
                return IPersistence.ERROR;
            }
        }
        public string GetJsonStatistics(string formName)
        {
            if (!File.Exists(formName))
                return IPersistence.ERROR;
            try
            {
                using (FileStream fs = new FileStream(GetFileLocation(formName, STAT_EXTENSION), FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader r = new BinaryReader(fs))
                    {
                        return r.ReadString();
                    }
                }
            } catch
            {
                return IPersistence.ERROR;
            }
        }
        public bool SaveForm(string formName, string jsonStr)
        {
            if (File.Exists(formName + FORM_EXTENSION))
                File.Delete(formName + FORM_EXTENSION);
            try
            {
                using (var fs = new FileStream(GetFileLocation(formName, FORM_EXTENSION), FileMode.CreateNew))
                {
                    using (var bw = new BinaryWriter(fs))
                    {
                        bw.Write(jsonStr);
                    }
                }
                System.Console.WriteLine($"Saved {_dirPath + "/" + formName + FORM_EXTENSION}");
                return true;
            } catch
            {
                return false;
            }
        }
        public bool SaveStatistics(string formName, string jsonStr)
        {
            if (File.Exists(formName + STAT_EXTENSION))
                File.Delete(formName + STAT_EXTENSION);
            try
            {
                using (var fs = new FileStream(GetFileLocation(formName, STAT_EXTENSION), FileMode.CreateNew))
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
        public bool CheckLogin(string username, string password)
        {
            return true; // TODO: Implement login check
        }
        public string GetJsonFormList(string username) // TODO: not like this
        {
            return JsonSerializer.Serialize(Directory.GetFiles(_dirPath + "/username", "*." + FORM_EXTENSION));
        }

        private string GetFileLocation(string formName, string extension)
        {
            return _dirPath + "/" + formName + "." + extension;
        }
    }
}
