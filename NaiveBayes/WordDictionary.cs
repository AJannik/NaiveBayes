using System;
using System.Collections.Generic;
using System.Text;

namespace NaiveBayes
{
    public class WordDictionary
    {
        public List<string> words = new List<string>();

        public void AddText(List<string> text)
        {
            foreach (string line in text)
            {
                string[] textWords = line.Split(" ");
                foreach (string word in textWords)
                {
                    string newWord = word.Trim(new Char[] { ',', '*', '.', ':', ';', '-', '_', '<', '>', '!', '?' });
                    if (!newWord.Equals("") && !words.Contains(newWord) && !newWord.Contains("@"))
                    {
                        words.Add(newWord);
                    }
                }
            }
        }
    }
}