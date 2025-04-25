using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalForm.Client.Persistence
{
    public class BinaryFileJsonPersistence(IEnumerable<Type> questionTypes) : JsonPersistence(questionTypes)
    {
        protected override string GetId(Form form) => form.Title.Replace(' ', '_') + ".uff";

        protected override string LoadJson(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader r = new BinaryReader(fs))
                    {
                        return r.ReadString();
                    }
                }
            } catch 
            {
                return ERROR;

            }
        }

        protected override bool SaveJson(string fileName, string jsonStr)
        {
            try 
            {
                if (File.Exists(fileName))
                {
                    return false;
                }
                using (var fs = new FileStream(fileName, FileMode.CreateNew))
                {
                    using (var bw = new BinaryWriter(fs))
                    {
                        bw.Write(jsonStr);
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
