using System;
using System.Collections.Generic;
using System.Text;

namespace NaiveBayes
{
    public class Classification
    {
        private Probability[] Probabilities { get; } = new Probability[20];

        public const float c = 1f;

        private int numTests = 0;
        private int numWrong = 0;

        public void Classify(TestData testData, string[] classNames)
        {
            float[] results = new float[20];
            int maxIndex = 0;
            float maxProb = -0f;
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = MathF.Log(c) + MathF.Log(Probabilities[i].ClassProbability) + WordsProbability(testData, i);
                //Console.WriteLine($"Class: {classNames[i]}; Score: {results[i]}");
                if (maxProb > results[i])
                {
                    maxProb = results[i];
                    maxIndex = i;
                }
            }
            numTests++;
            testData.Classification = classNames[maxIndex];

            if (testData.Classification != testData.RealClass)
            {
                numWrong++;
            }
            //Console.WriteLine($"Real Class: {testData.RealClass}; Classified as: {testData.Classification}");
        }

        public void CalculateProbabilities(NumTrainingDataClasses numTrainingDataClasses, string[] classesName, ClassHits[] classHits)
        {
            for (int i = 0; i < Probabilities.Length; i++)
            {
                Probability probability = new Probability();
                probability.WordsProbabilities = new float[classHits[0].Hits.Length];
                probability.ClassName = classesName[i];
                probability.ClassProbability = numTrainingDataClasses.NumTrainingData[i] / (float)numTrainingDataClasses.TotalNumTrainingData;
                Probabilities[i] = probability;

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