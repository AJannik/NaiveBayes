using NaiveBayes.Learning;
using System;

namespace NaiveBayes.Classification
{
    public class Classifier
    {
        private Probability[] Probabilities { get; } = new Probability[20];

        public const float C = 1f;

        private int numTests = 0;
        private int numWrong = 0;

        public void Classify(TestData testData, string[] classNames)
        {
            float[] results = new float[20];
            int maxIndex = 0;
            float maxProb = -0f;

            // Naive-Bayes Classifier
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = MathF.Log(C) + MathF.Log(Probabilities[i].ClassProbability) + WordsProbability(testData, i);

                // store biggest score
                if (maxProb > results[i])
                {
                    maxProb = results[i];
                    maxIndex = i;
                }
            }
            numTests++;
            testData.Classification = classNames[maxIndex];

            // Error tracking
            if (testData.Classification != testData.RealClass)
            {
                numWrong++;
            }
        }

        
        public void CalculateProbabilities(NumTrainingDataClasses numTrainingDataClasses, string[] classesName, ClassHits[] classHits)
        {
            for (int i = 0; i < Probabilities.Length; i++)
            {
                // calculate P(Class) for every class from absolute frequency which is stored in NumTrainingDataClasses
                float classProb = numTrainingDataClasses.NumTrainingData[i] / (float)numTrainingDataClasses.TotalNumTrainingData;
                Probability probability = new Probability(classesName[i], classHits[0].Hits.Length, classProb);
                Probabilities[i] = probability;

                // calculate P(w | Class) for every class from absolute frequency which is stored in ClassHits 
                for (int j = 0; j < classHits[i].Hits.Length; j++)
                {
                    Probabilities[i].WordsProbabilities[j] = classHits[i].Hits[j] / (float)classHits[i].NumHits;
                }
            }
        }

        public void PrintErrorRate()
        {
            Console.WriteLine($"A total of {numTests} texts were classified. {numWrong} were wrong. The Errorrate therefore is {100f * numWrong / (float)numTests}%");
        }

        // ∑ n * Log( P(w | Class) )
        // n := number of word occurences
        private float WordsProbability(TestData testData, int index)
        {
            float prob = 0f;
            for (int i = 0; i < testData.Hits.Length; i++)
            {
                if (Probabilities[index].WordsProbabilities[i] != 0f)
                {
                    prob += testData.Hits[i] * MathF.Log(Probabilities[index].WordsProbabilities[i]);
                }
            }

            return prob;
        }
    }
}