namespace NaiveBayes.Classification
{
    public class TestData
    {
        public TestData(string realClass, int length)
        {
            RealClass = realClass;
            Hits = new int[length];
        }

        public string RealClass { get; set; }

        public string Classification { get; set; }

        public int[] Hits { get; set; }
    }
}