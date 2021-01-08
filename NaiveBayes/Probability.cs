using System;
using System.Collections.Generic;
using System.Text;

namespace NaiveBayes
{
    public class Probability
    {
        public string ClassName { get; set; }

        public float ClassProbability { get; set; }

        public float[] WordsProbabilities { get; set; }
    }
}
