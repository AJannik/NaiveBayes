using System;
using System.Collections.Generic;
using System.Text;

namespace NaiveBayes
{
    public class Controll
    {
        private WordDictionary WordDictionary { get; set; }

        private NumClasses NumClasses { get; set; }

        private List<ClassHits> classHits { get; set; } = new List<ClassHits>();

        private WordDictionaryManager WordDictionaryManager { get; } = new WordDictionaryManager();

        private NumClassesManager NumClassesManager { get; } = new NumClassesManager();

        private ClassHitsManager ClassHitsManager { get; } = new ClassHitsManager();

        public bool ReBuildDictionary { get; } = true;

        public void Setup()
        {
            if (ReBuildDictionary)
            {
                WordDictionary = WordDictionaryManager.BuildDictionary();
                NumClasses = NumClassesManager.BuildNumClasses();
                classHits.Add(ClassHitsManager.BuildClassHits("atheism", WordDictionary));
            }
            else
            {
                WordDictionary = WordDictionaryManager.LoadDictionary();
                NumClasses = NumClassesManager.LoadNumClasses();
                classHits.Add(ClassHitsManager.LoadClassHits("atheism"));
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