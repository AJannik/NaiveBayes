namespace NaiveBayes.Learning
{
    public class NumTrainingDataClasses
    {
        public int[] NumTrainingData { get; set; } = new int[20];

        public int TotalNumTrainingData 
        {
            get
            {
                int num = 0;
                foreach (int item in NumTrainingData)
                {
                    num += item;
                }
                return num;
            } 
        }
    }
}