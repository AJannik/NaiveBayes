using NaiveBayes.FileIO;
using NaiveBayes.Learning;
using System.Collections.Generic;
using System.IO;

namespace NaiveBayes.Classification
{
    public class TestDataManager
    {
        public List<TestData> TestDatas { get; set; } = new List<TestData>();

        private TextFileReader TextFileReader { get; } = new TextFileReader();

        public void BuildTestDatas(WordDictionary wordDictionary)
        {
            string[] directories = Directory.GetDirectories(Path.Combine(Program.myPath, "res", "TestData"));
            foreach (string directory in directories)
            {
                // Get Files
                string[] files = Directory.GetFiles(directory);
                foreach (string file in files)
                {
                    // Instantiate TestData
                    string[] realClass = directory.Split("\\");
                    TestData testData = new TestData(realClass[realClass.Length - 1], wordDictionary.Words.Count);

                    // Create WordVector n
                    CreateWordVector(wordDictionary, file, testData);
                    TestDatas.Add(testData);
                }
            }
        }

        // Vector consists of the number of occurences of words in the given text
        private void CreateWordVector(WordDictionary wordDictionary, string file, TestData testData)
        {
            List<string> words = TextFileReader.SplitTextToWords(TextFileReader.ReadFile(file));
            foreach (string word in words)
            {
                int index = wordDictionary.Words.IndexOf(word);
                if (index != -1)
                {
                    testData.Hits[index]++;
                }
            }
        }
    }
}