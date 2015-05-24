using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacTortex
{
    public enum ActivationFunction
    {
        Step,
        Sigmoid,
        TanH
    }

    public static class Activation
    {
        public static double Process(ActivationFunction f, double x)
        {
            switch (f)
            {
                case ActivationFunction.Step:
                    return (x > 1.0) ? 1.0 : 0.0;
                case ActivationFunction.Sigmoid:
                    return 1.0 / (1.0 + Math.Pow(Math.E, -x));
                case ActivationFunction.TanH:
                    return ((Math.Pow(Math.E, x) - Math.Pow(Math.E, -x)) / (Math.Pow(Math.E, x) + Math.Pow(Math.E, -x)));
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
