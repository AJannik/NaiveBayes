using System;
using System.Collections.Generic;
using System.Text;

namespace NaiveBayes
{
    public class Controll
    {
        private WordDictionary WordDictionary { get; set; }

        private NumClasses NumClasses { get; set; }

        private List<ClassHits> ClassHits { get; set; } = new List<ClassHits>();

        private WordDictionaryManager WordDictionaryManager { get; } = new WordDictionaryManager();

        private NumClassesManager NumClassesManager { get; } = new NumClassesManager();

        private ClassHitsManager ClassHitsManager { get; } = new ClassHitsManager();

        private TestDataManager TestDataManager { get; } = new TestDataManager();

        private readonly string[] classes = {"atheism", "autos", "baseball", "christian", "crypt", "electronics", "forsale", "graphics", 
            "guns", "hockey", "macHardware", "medicine", "mideast", "motorcycles", "pcHardware", "politicsMisc", "religionMisc", "space", "windowsOS", "windowsX"};

        public bool ReBuildDictionary { get; } = false;

        public void Setup()
        {
            if (ReBuildDictionary)
            {
                WordDictionary = WordDictionaryManager.BuildDictionary(classes);
                NumClasses = NumClassesManager.BuildNumClasses();
                foreach (string item in classes)
                {
                    ClassHits.Add(ClassHitsManager.BuildClassHits(item, WordDictionary));
                }
            }
            else
            {
                WordDictionary = WordDictionaryManager.LoadDictionary();
                NumClasses = NumClassesManager.LoadNumClasses();
                foreach (string item in classes)
                {
                    ClassHits.Add(ClassHitsManager.LoadClassHits(item));
                }
            }
        }

        public void Classify()
        {
            TestDataManager.BuildTestDatas(WordDictionary);
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