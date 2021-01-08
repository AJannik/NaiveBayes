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
                List<string> words = SplitTextToWords(TextFileReader.ReadFile(file));
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
            ClassHits classHits = new ClassHits();
            if (!File.Exists(Path.Combine(Program.myPath, "res", "LearnedData", $"{className}.json")))
            {
                throw new FileNotFoundException("ClassHits has to be build first");
            }

            classHits = loadSaveJson.Deserialize<ClassHits>($"{className}.json");

            return classHits;
        }

        public void StoreClassHits(ClassHits classHits)
        {
            loadSaveJson.Serialize(classHits, $"{classHits.Name}.json");
        }

        private List<string> SplitTextToWords(List<string> text)
        {
            List<string> words = new List<string>();

            foreach (string line in text)
            {
                string[] textWords = line.Split(" ");
                foreach (string word in textWords)
                {
                    string newWord = word.Trim(new Char[] { ',', '*', '.', ':', ';', '-', '_', '<', '>', '!', '?', '/', '\'', '(', ')' });
                    if (!newWord.Equals("") && !newWord.Contains("@"))
                    {
                        words.Add(newWord);
                    }
                }
            }

            return words;
        }
    }
}
