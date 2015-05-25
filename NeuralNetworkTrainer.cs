using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacTortex
{
    public struct TrainingSet
    {
        // Key is Input for a training pair, Value is Output
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
            nn.Initialize(ts.f);
        }

        public void Train(int repetitions)
        {
            for (int i = 0; i < repetitions; ++i)
            {
                // Loop through all examples
                foreach (var trainingPair in ts.IOMappings)
                {
                    // Key is Input; Value is Output
                    nn.RunOn(trainingPair.Key);

                    // Compare outputs to kvp.Value
                    double[] error_Hidden = new double[nn.Num_Hidden + 1];
                    double[] error_Outputs = new double[nn.Num_Outputs];
                    // Output layer
                    for (int j = 0; j < nn.Num_Outputs; ++j)
                    {
                        error_Outputs[j] =
                            nn.Outputs[j] *
                            (1.0 - nn.Outputs[j]) *
                            (trainingPair.Value[j] - nn.Outputs[j]);
                    }
                    // Hidden layer
                    for (int j = 0; j < nn.Num_Hidden; ++j)
                    {
                        double delta = 0.0;
                        for (int k = 0; k < nn.Num_Outputs; ++k)
                        {
                            delta += nn.Weights_HiddenToOutput[j, k] * error_Outputs[k];
                        }
                        error_Hidden[j] = nn.Hidden[j] * (1.0 - nn.Hidden[j]) * delta;
                    }

                    // Adjust weights 
                    for (int j = 0; j < nn.Num_Outputs; ++j)
                    {
                        for (int k = 0; k < nn.Num_Hidden + 1; ++k)
                        {
                            nn.Weights_HiddenToOutput[k, j] += 
                                nn.LearnStep * 
                                error_Outputs[j] * 
                                nn.Hidden[k];
                        }
                    }
                    for (int j = 0; j < nn.Num_Hidden; ++j)
                    {
                        for (int k = 0; k < nn.Num_Inputs + 1; ++k)
                        {
                            nn.Weights_InputToHidden[k, j] +=
                                nn.LearnStep *
                                error_Hidden[j] *
                                nn.Inputs[k];
                        }
                    }
                }
            }
        }
    }
}
