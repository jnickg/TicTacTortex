using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TicTacTortex
{
    public class NeuralNetwork
    {
        private double[] inputs;
        private double[] hidden;
        private double[] outputs;

        private double learnStep = 0.1; // Should be in NN because it's relative to weight range

        private ActivationFunction _f = ActivationFunction.Step;
        private Random _r = new Random();

        private int num_Inputs;
        private int num_Hidden;
        private int num_Outputs;
        private double[,] weights_ItoH;
        private double[,] weights_HtoO;

        public double[] Inputs
        {
            get { return inputs; }
            set { inputs = value; }
        }

        public double[] Hidden
        {
            get { return hidden; }
            set { hidden = value; }
        }

        public double[] Outputs
        {
            get { return outputs; }
            set { outputs = value; }
        }

        public int Num_Inputs
        {
            get { return num_Inputs; }
            set { num_Inputs = value; }
        }
        
        public int Num_Hidden
        {
            get { return num_Hidden; }
            set { num_Hidden = value; }
        }
        

        public int Num_Outputs
        {
            get { return num_Outputs; }
            set { num_Outputs = value; }
        }

        public double[,] Weights_InputToHidden
        {
            get { return weights_ItoH; }
            set { weights_ItoH = value; }
        }
        

        public double[,] Weights_HiddenToOutput
        {
            get { return weights_HtoO; }
            set { weights_HtoO = value; }
        }

        public double LearnStep
        {
            get { return learnStep; }
            set { learnStep = value; }
        }


        public NeuralNetwork(int num_Inputs, int num_Hidden, int num_Outputs)
        {
            this.num_Inputs = num_Inputs;
            this.num_Hidden = num_Hidden;
            this.num_Outputs = num_Outputs;
            // +1 for bias
            this.weights_ItoH = new double[num_Inputs + 1, num_Hidden];
            this.weights_HtoO = new double[num_Hidden + 1, num_Outputs];
            this.inputs = new double[num_Inputs + 1];
            this.hidden = new double[num_Hidden + 1];
            this.outputs = new double[num_Outputs];
        }

        public void Initialize(ActivationFunction f = ActivationFunction.Step)
        {
            // update activation function
            _f = f;
            // default bias
            inputs[num_Inputs] = 1.0;
            hidden[num_Hidden] = 1.0;
            // set random weights I-H layer
            for (int i = 0; i < num_Inputs + 1; ++i)
            {
                for (int j = 0; j < num_Hidden; ++j)
                {
                    weights_ItoH[i, j] = ((_r.NextDouble() * 2) - 1);
                }
            }
            // set random weights H-O layer
            for (int i = 0; i < num_Hidden + 1; ++i)
            {
                for (int j = 0; j < num_Outputs; ++j)
                {
                    weights_HtoO[i, j] = ((_r.NextDouble() * 2) - 1);
                }
            }
        }

        public void RunOn(double[] input)
        {
            // copy inputs
            for (int i = 0; i < num_Inputs; ++i)
            {
                inputs[i] = input[i];
            }
            // input to hidden layer
            for (int i = 0; i < num_Hidden + 1; ++i)
            {
                double sum = 0.0;
                for (int j = 0; j < num_Inputs + 1; ++j)
                {
                    // sum input values factored by their weight
                    sum += inputs[i] * weights_ItoH[j, i];
                }
                // copy activation function of sum to node in next layer
                hidden[i] = Activation.Process(_f, sum);
            }
            // hidden to output layer
            for (int i = 0; i < num_Outputs; ++i)
            {
                double sum = 0.0;
                for (int j = 0; j < num_Hidden + 1; ++j)
                {
                    // sum hidden values factored by their weight
                    sum += hidden[i] * weights_HtoO[j, i];
                }
                // copy activation function of sum to output node
                outputs[i] = Activation.Process(_f, sum);
            }
        }
    }


}
