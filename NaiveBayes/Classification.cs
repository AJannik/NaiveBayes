using System;
using System.Collections.Generic;
using System.Text;

namespace NaiveBayes
{
    public class Classification
    {
        private Probability[] Probabilities { get; } = new Probability[20];

        public const float c = 1f;

        public void Classify(TestData testData, string[] classNames)
        {
            float[] results = new float[20];
            int maxIndex = 0;
            float maxProb = 0f;
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = c * Probabilities[i].ClassProbability * WordsProbability(testData, i);
                if (maxProb < results[i])
                {
                    maxProb = results[i];
                    maxIndex = i;
                }
            }

            testData.Classification = classNames[maxIndex];
            Console.WriteLine($"Real Class: {testData.RealClass}; Classified as: {testData.Classification}");
        }

        public void CalculateProbabilities(NumTrainingDataClasses numTrainingDataClasses, string[] classesName, ClassHits[] classHits)
        {
            for (int i = 0; i < Probabilities.Length; i++)
            {
                Probabilities[i].ClassName = classesName[i];
                Probabilities[i].ClassProbability = numTrainingDataClasses.NumTrainingData[i] / (float)numTrainingDataClasses.TotalNumTrainingData;

                for (int j = 0; j < classHits[i].Hits.Length; j++)
                {
                    Probabilities[i].WordsProbabilities[j] = classHits[i].Hits[j] / (float)classHits[i].NumHits;
                }
            }
        }

        private float WordsProbability(TestData testData, int index)
        {
            float prob = 1f;
            for (int i = 0; i < testData.Hits.Length; i++)
            {
                prob *= testData.Hits[i] * Probabilities[index].WordsProbabilities[i];
            }

            return prob;
        }
    }
}