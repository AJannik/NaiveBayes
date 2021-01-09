namespace NaiveBayes.Classification
{
    public class Probability
    {
        public Probability(string className, int length, float classProb)
        {
            ClassName = className;
            WordsProbabilities = new float[length];
            ClassProbability = classProb;
        }

        public string ClassName { get; set; }

        public float ClassProbability { get; set; }

        public float[] WordsProbabilities { get; set; }
    }
}