using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacTortex
{
    public struct TrainingSet
    {
        public Dictionary<double[], double[]>  IOMappings;
        public ActivationFunction f;
    }

    public class NeuralNetworkTrainer
    {
        private NeuralNetwork nn;
        private TrainingSet ts;

        public NeuralNetworkTrainer(ref NeuralNetwork nn, TrainingSet ts)
        {
            this.nn = nn;
            this.ts = ts;
        }

        public void Train(int repetitions)
        {
            nn.Initialize(ts.f);
            for (int i = 0; i < repetitions; ++i)
            {
                // Loop through all examples
                foreach (var kvp in ts.IOMappings)
                {
                    // Key is Input; Value is Output
                    
                    // Train the neural network
                }
            }
        }
    }
}
