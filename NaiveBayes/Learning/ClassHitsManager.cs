using NaiveBayes.FileIO;
using System.Collections.Generic;
using System.IO;

namespace NaiveBayes.Learning
{
    public class ClassHitsManager
    {
        private LoadSaveJson loadSaveJson = new LoadSaveJson();
        private TextFileReader TextFileReader = new TextFileReader();

        public ClassHits BuildClassHits(string className, WordDictionary wordDictionary)
        {
            ClassHits classHits = new ClassHits();
            classHits.Name = className;
            classHits.Hits = new int[wordDictionary.Words.Count];

            // Get Files
            string[] files = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", classHits.Name));
            foreach (string file in files)
            {
                CreateClassHits(wordDictionary, classHits, file);
            }

            StoreClassHits(classHits);
            return classHits;
        }

        public ClassHits LoadClassHits(string className)
        {
            if (!File.Exists(Path.Combine(Program.myPath, "res", "LearnedData", $"{className}.json")))
            {
                throw new FileNotFoundException("ClassHits has to be build first");
            }

            ClassHits classHits = loadSaveJson.Deserialize<ClassHits>($"{className}.json");

            return classHits;
        }

        public void StoreClassHits(ClassHits classHits)
        {
            loadSaveJson.Serialize(classHits, $"{classHits.Name}.json");
        }

        private void CreateClassHits(WordDictionary wordDictionary, ClassHits classHits, string file)
        {
            List<string> words = TextFileReader.SplitTextToWords(TextFileReader.ReadFile(file));
            foreach (string word in words)
            {
                int index = wordDictionary.Words.IndexOf(word);
                if (index != -1)
                {
                    classHits.Hits[index]++;
                }

                classHits.NumHits++;
            }
        }
    }
}
