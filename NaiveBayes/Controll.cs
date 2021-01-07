using System;
using System.Collections.Generic;
using System.Text;

namespace NaiveBayes
{
    public class Controll
    {
        private WordDictionary WordDictionary { get; set; }

        private NumClasses NumClasses { get; set; }

        private WordDictionaryManager WordDictionaryManager { get; } = new WordDictionaryManager();

        private NumClassesManager NumClassesManager { get; } = new NumClassesManager();

        public bool ReBuildDictionary { get; } = false;

        public void Setup()
        {
            if (ReBuildDictionary)
            {
                WordDictionary = WordDictionaryManager.BuildDictionary();
                NumClasses = NumClassesManager.BuildNumClasses();
            }
            else
            {
                WordDictionary = WordDictionaryManager.LoadDictionary();
                NumClasses = NumClassesManager.LoadNumClasses();
            }
        }

        public void PrintDictionary()
        {
            foreach (string word in WordDictionary.Words)
            {
                Console.WriteLine(word);
            }
        }
    }
}