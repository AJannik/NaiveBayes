using System.IO;
using System.Text.Json;

namespace NaiveBayes.FileIO
{
    public class LoadSaveJson
    {
        private JsonSerializerOptions options = new JsonSerializerOptions();

        public LoadSaveJson()
        {
            options.WriteIndented = true;
        }

        public void Serialize<T>(T data, string filename)
        {
            string jsonString = JsonSerializer.Serialize<T>(data, options);
            File.WriteAllText(Path.Combine(Program.myPath, "res", "LearnedData", filename), jsonString);
        }

        public T Deserialize<T>(string filename)
        {
            string jsonString = File.ReadAllText(Path.Combine(Program.myPath, "res", "LearnedData", filename));
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}