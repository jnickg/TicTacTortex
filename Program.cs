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
            NeuralNetwork nn = new NeuralNetwork(18, 36, 18);
            nn.Initialize(ActivationFunction.Step);
            // Test serialization of Neural Network
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NeuralNetwork));
            FileStream fs = new FileStream("nn.json", FileMode.OpenOrCreate, FileAccess.Write);
            js.WriteObject(fs, nn);
            fs.Close();
        }
    }
}
