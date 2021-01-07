using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace NaiveBayes
{
    public class LoadSaveJson
    {
        private JsonSerializerOptions options = new JsonSerializerOptions();

        public void Serialize<T>(T data, string filename)
        {
            options.WriteIndented = true;
            string jsonString = JsonSerializer.Serialize<T>(data, options);
            File.WriteAllText(Path.Combine(Program.myPath, "res", filename), jsonString);
        }

        public T Deserialize<T>(string filename)
        {
            string jsonString = File.ReadAllText(Path.Combine(Program.myPath, "res", filename));
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}