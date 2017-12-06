using System;

namespace MortyNet.NeuralNetwork
{
    public static class ActivationFunctions
    {
	    public static Func<double, double> Sigmoid => x => 1 / (1 + Math.Pow(Math.E, -x));
    }
}
