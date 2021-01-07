using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NaiveBayes
{
    public class NumClassesManager
    {
        private LoadSaveJson loadSaveJson = new LoadSaveJson();

        private string Filename { get; } = "numclasses.json";

        public NumClasses BuildNumClasses()
        {
            NumClasses numClasses = new NumClasses();
            numClasses.atheism = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "atheism")).Length;
            numClasses.autos = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "autos")).Length;
            numClasses.baseball = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "baseball")).Length;
            numClasses.christian = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "christian")).Length;
            numClasses.crypt = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "crypt")).Length;
            numClasses.electronics = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "electronics")).Length;
            numClasses.forsale = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "forsale")).Length;
            numClasses.graphics = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "graphics")).Length;
            numClasses.guns = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "guns")).Length;
            numClasses.hockey = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "hockey")).Length;
            numClasses.macHardware = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "macHardware")).Length;
            numClasses.medicine = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "medicine")).Length;
            numClasses.mideast = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "mideast")).Length;
            numClasses.motorcycles = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "motorcycles")).Length;
            numClasses.pcHardware = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "pcHardware")).Length;
            numClasses.politicsMisc = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "politicsMisc")).Length;
            numClasses.religionMisc = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "religionMisc")).Length;
            numClasses.space = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "space")).Length;
            numClasses.windowsOS = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "windowsOS")).Length;
            numClasses.windowsX = Directory.GetFiles(Path.Combine(Program.myPath, "res", "TrainingData", "windowsX")).Length;
            StoreNumClasses(numClasses);

            return numClasses;
        }

        public NumClasses LoadNumClasses()
        {
            if (!File.Exists(Path.Combine(Program.myPath, "res", Filename)))
            {
                throw new FileNotFoundException("NumClasses has to be build first");
            }

            NumClasses numClasses = loadSaveJson.Deserialize<NumClasses>(Filename);

            return numClasses;
        }

        public void StoreNumClasses(NumClasses numClasses)
        {
            loadSaveJson.Serialize(numClasses, Filename);
        }
    }
}