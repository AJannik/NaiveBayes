using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace NaiveBayes
{
    public class LoadSaveWordDictionary
    {
        private JsonSerializerOptions options = new JsonSerializerOptions();

        public void Serialize(List<string> words)
        {
            options.WriteIndented = true;
            string jsonString = JsonSerializer.Serialize(words, options);
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "res", "worddictionary.json"), jsonString);
        }

        public List<string> Deserialize()
        {
            string jsonString = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "res", "worddictionary.json"));
            return JsonSerializer.Deserialize<List<string>>(jsonString);
        }
    }
}