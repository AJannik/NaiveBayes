using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NaiveBayes
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
    }
}