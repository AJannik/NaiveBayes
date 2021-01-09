using NaiveBayes.FileIO;
using System.IO;

namespace NaiveBayes.Learning
{
    public class NumTrainingDataClassesManager
    {
        private LoadSaveJson loadSaveJson = new LoadSaveJson();

        private string Filename { get; } = "numclasses.json";

        public NumTrainingDataClasses BuildNumClasses(string[] classNames)
        {
            NumTrainingDataClasses numClasses = new NumTrainingDataClasses();
            for (int i = 0; i < numClasses.NumTrainingData.Length; i++)
            {
                numClasses.NumTrainingData[i] = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", classNames[i])).Length;
            }

            StoreNumClasses(numClasses);

            return numClasses;
        }

        public NumTrainingDataClasses LoadNumClasses()
        {
            if (!File.Exists(Path.Combine(Program.myPath, "res", "LearnedData", Filename)))
            {
                throw new FileNotFoundException("NumClasses has to be build first");
            }

            NumTrainingDataClasses numClasses = loadSaveJson.Deserialize<NumTrainingDataClasses>(Filename);

            return numClasses;
        }

        public void StoreNumClasses(NumTrainingDataClasses numClasses)
        {
            loadSaveJson.Serialize(numClasses, Filename);
        }
    }
}