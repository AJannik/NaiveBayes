using System;
using System.Collections.Generic;
using System.IO;

namespace NaiveBayes
{
    public class WordDictionaryManager
    {
        private LoadSaveJson loadSaveJson = new LoadSaveJson();
        private TextFileReader textFileReader = new TextFileReader();

        private string Filename { get; } = "worddictionary.json";

        public WordDictionary BuildDictionary(string[] classes)
        {
            WordDictionary wordDictionary = new WordDictionary();

            foreach (string item in classes)
            {
                string[] files = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", item));

                foreach (string file in files)
                {
                    List<string> text = textFileReader.ReadFile(file);
                    AddText(text, wordDictionary);
                }
            }

            StoreDictionary(wordDictionary);
            return wordDictionary;
        }

        public WordDictionary LoadDictionary()
        {
            if (!File.Exists(Path.Combine(Program.myPath, "res", "LearnedData", Filename)))
            {
                throw new FileNotFoundException("Dictionary has to be build first");
            }

            WordDictionary wordDictionary = loadSaveJson.Deserialize<WordDictionary>(Filename);

            return wordDictionary;
        }

        public void StoreDictionary(WordDictionary wordDictionary)
        {
            loadSaveJson.Serialize(wordDictionary, Filename);
        }

        private void AddText(List<string> text, WordDictionary wordDictionary)
        {
            foreach (string line in text)
            {
                string[] textWords = line.Split(" ");
                foreach (string word in textWords)
                {
                    string newWord = word.Trim(new Char[] { ',', '*', '.', ':', ';', '-', '_', '<', '>', '!', '?', '/', '\'', '(', ')'});
                    if (!newWord.Equals("") && !wordDictionary.Words.Contains(newWord) && !newWord.Contains("@"))
                    {
                        wordDictionary.Words.Add(newWord);
                    }
                }
            }
        }
    }
}