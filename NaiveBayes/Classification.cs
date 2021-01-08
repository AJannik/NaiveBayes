using System;
using System.Collections.Generic;
using System.Text;

namespace NaiveBayes
{
    public class Classification
    {
        private Probability[] Probabilities { get; } = new Probability[20];

        public void Classify(TestData testData)
        {

        }

        public void CalculateProbabilities(NumTrainingDataClasses numTrainingDataClasses, string[] classesName)
        {
            for (int i = 0; i < Probabilities.Length; i++)
            {
                Probabilities[i].ClassName = classesName[i];
                Probabilities[i].ClassProbability = numTrainingDataClasses.NumTrainingData[i] / (float)numTrainingDataClasses.TotalNumTrainingData;
            }
        }
    }
}