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

        public WordDictionary BuildDictionary()
        {
            WordDictionary wordDictionary = new WordDictionary();
            // TODO: read all files
            List<string> text = textFileReader.ReadFile(Path.Combine(Program.myPath, "res", "TrainingData", "atheism", "53154"));
            AddText(text, wordDictionary);
            StoreDictionary(wordDictionary);

            return wordDictionary;
        }

        public WordDictionary LoadDictionary()
        {
            if (!File.Exists(Path.Combine(Program.myPath, "res", Filename)))
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
                    string newWord = word.Trim(new Char[] { ',', '*', '.', ':', ';', '-', '_', '<', '>', '!', '?' });
                    if (!newWord.Equals("") && !wordDictionary.Words.Contains(newWord) && !newWord.Contains("@"))
                    {
                        wordDictionary.Words.Add(newWord);
                    }
                }
            }
        }
    }
}