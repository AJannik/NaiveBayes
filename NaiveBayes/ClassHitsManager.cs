using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NaiveBayes
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
            string[] files = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", classHits.Name));
            foreach (string file in files)
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
    }
}
