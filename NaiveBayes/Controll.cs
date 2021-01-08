using System;
using System.Collections.Generic;
using System.Text;

namespace NaiveBayes
{
    public class Controll
    {
        private WordDictionary WordDictionary { get; set; }

        private NumTrainingDataClasses NumClasses { get; set; }

        private List<ClassHits> ClassHits { get; set; } = new List<ClassHits>();

        private WordDictionaryManager WordDictionaryManager { get; } = new WordDictionaryManager();

        private NumClassesManager NumClassesManager { get; } = new NumClassesManager();

        private ClassHitsManager ClassHitsManager { get; } = new ClassHitsManager();

        private TestDataManager TestDataManager { get; } = new TestDataManager();

        private readonly string[] classNames = {"atheism", "autos", "baseball", "christian", "crypt", "electronics", "forsale", "graphics", 
            "guns", "hockey", "macHardware", "medicine", "mideast", "motorcycles", "pcHardware", "politicsMisc", "religionMisc", "space", "windowsOS", "windowsX"};

        public bool ReBuildDictionary { get; } = false;

        public void Setup()
        {
            if (ReBuildDictionary)
            {
                WordDictionary = WordDictionaryManager.BuildDictionary(classNames);
                NumClasses = NumClassesManager.BuildNumClasses(classNames);
                foreach (string item in classNames)
                {
                    ClassHits.Add(ClassHitsManager.BuildClassHits(item, WordDictionary));
                }
            }
            else
            {
                WordDictionary = WordDictionaryManager.LoadDictionary();
                NumClasses = NumClassesManager.LoadNumClasses();
                foreach (string item in classNames)
                {
                    ClassHits.Add(ClassHitsManager.LoadClassHits(item));
                }
            }
        }

        public void Classify()
        {
            Classification classification = new Classification();

            TestDataManager.BuildTestDatas(WordDictionary);
            classification.CalculateProbabilities(NumClasses, classNames, ClassHits.ToArray());
            classification.Classify(TestDataManager.TestDatas[0], classNames);
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