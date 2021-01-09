namespace NaiveBayes.Learning
{
    public class ClassHits
    {
        public ClassHits(string name, int length)
        {
            Name = name;
            Hits = new int[length];
        }

        public string Name { get; set; }

        public int[] Hits { get; set; }

        public int NumHits { get; set; }
    }
}