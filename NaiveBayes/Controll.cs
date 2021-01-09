using NaiveBayes.Classification;
using NaiveBayes.Learning;
using System;
using System.Collections.Generic;

namespace NaiveBayes
{
    public class Controll
    {
        private WordDictionary WordDictionary { get; set; }

        private NumTrainingDataClasses NumClasses { get; set; }

        private List<ClassHits> ClassHits { get; set; } = new List<ClassHits>();

        private WordDictionaryManager WordDictionaryManager { get; } = new WordDictionaryManager();

        private NumTrainingDataClassesManager NumClassesManager { get; } = new NumTrainingDataClassesManager();

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
            Classifier classifier = new Classifier();

            TestDataManager.BuildTestDatas(WordDictionary);
            classifier.CalculateProbabilities(NumClasses, classNames, ClassHits.ToArray());
            for (int i = 0; i < TestDataManager.TestDatas.Count; i++)
            {
                classifier.Classify(TestDataManager.TestDatas[i], classNames);
            }

            classifier.PrintErrorRate();
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