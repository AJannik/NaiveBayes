using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NaiveBayes
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
                string[] files = Directory.GetFiles(directory);

                foreach (string file in files)
                {
                    TestData testData = new TestData();
                    string[] s = directory.Split("\\");
                    testData.RealClass = s[s.Length - 1];
                    testData.Hits = new int[wordDictionary.Words.Count];
                    List<string> words = TextFileReader.SplitTextToWords(TextFileReader.ReadFile(file));
                    foreach (string word in words)
                    {
                        int index = wordDictionary.Words.IndexOf(word);
                        if (index != -1)
                        {
                            testData.Hits[index]++;
                        }
                    }

                    TestDatas.Add(testData);
                }
            }
        }
    }
}