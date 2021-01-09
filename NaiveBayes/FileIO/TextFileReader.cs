using System;
using System.Collections.Generic;
using System.IO;

namespace NaiveBayes.FileIO
{
    public class TextFileReader
    {
        public List<string> ReadFile(string path)
        {
            List<string> lines = new List<string>();
            try
            {
                // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path))
                {
                    // Read the stream as a string, and write the string to the console.
                    string s;
                    bool header = true;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (!header)
                        {
                            lines.Add(s);
                        }

                        if (s.Equals(""))
                        {
                            header = false;
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return lines;
        }

        public List<string> SplitTextToWords(List<string> text)
        {
            List<string> words = new List<string>();

            foreach (string line in text)
            {
                string[] textWords = line.Split(" ");
                foreach (string word in textWords)
                {
                    string newWord = word.Trim(new Char[] { ',', '*', '.', ':', ';', '-', '_', '<', '>', '!', '?', '/', '\'', '(', ')' });
                    if (!newWord.Equals("") && !newWord.Contains("@"))
                    {
                        words.Add(newWord);
                    }
                }
            }

            return words;
        }
    }
}