using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace TicTacTortex
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork nn = new NeuralNetwork(64, 128, 64);
            nn.Initialize(ActivationFunction.Step);
            TrainingSet ts = new TrainingSet();

            StreamReader sr = new StreamReader(args[0]);

            while (!sr.EndOfStream)
            {
                string ioString = sr.ReadLine();
                double[] inputs = new double[9];
                double[] outputs = new double[9];
                ts.IOMappings.Add(inputs, outputs);
            }
        }
    }
}
