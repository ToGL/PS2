using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace PS2.Utilities
{
    public class JsonFileUtility
    {
        public T ReadFile<T>(string path)
        {
            using (var file = new StreamReader(path))
            {
                var json = file.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public void SaveFile<T>(string path, T data)
        {
            using (var file = new StreamWriter(path))
            {
                file.Write(JsonConvert.SerializeObject(data));
            }
        }

        public string GetJsonString<T>(T data) { 
            return JsonConvert.SerializeObject(data);
        }
        public T GetObjectFromJsonString<T>(string jsonString)
        {
            try {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (JsonReaderException e) {
                System.Windows.Forms.MessageBox.Show(e.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return default;              
        }
    }
}
