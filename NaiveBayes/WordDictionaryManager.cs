using System;
using System.Collections.Generic;
using System.IO;

namespace NaiveBayes
{
    public class WordDictionaryManager
    {
        private LoadSaveWordDictionary loadSaveJson = new LoadSaveWordDictionary();
        private TextFileReader textFileReader = new TextFileReader();

        public WordDictionary BuildDictionary()
        {
            WordDictionary wordDictionary = new WordDictionary();
            List<string> text = textFileReader.ReadFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "res", "TrainingData", "alt.atheism", "53154"));
            AddText(text, wordDictionary);

            return wordDictionary;
        }

        public WordDictionary LoadDictionary()
        {
            if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "res", "worddictionary.json")))
            {
                throw new FileNotFoundException("Dictionary has to be build first");
            }

            WordDictionary wordDictionary = new WordDictionary();
            wordDictionary.Words = loadSaveJson.Deserialize();

            return wordDictionary;
        }

        public void StoreDictionary(WordDictionary wordDictionary)
        {
            loadSaveJson.Serialize(wordDictionary.Words);
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