using System;
using MortyNet.NeuralNetwork;

namespace MortyNet.XOR
{
	internal class Program
    {
        static void Main(string[] args)
        {
			//XOR function
			//0, 0 | 0
			//0, 1 | 1
			//1, 0 | 1
			//1, 1 | 0

	        var dataset = new[]
	        {
				new XORSample { A = 0, B = 0, Label = 0 },
				new XORSample { A = 0, B = 1, Label = 1 },
				new XORSample { A = 1, B = 0, Label = 1 },
				new XORSample { A = 1, B = 1, Label = 0 },
			};

	        var net = new SimpleNeuralNetwork(ActivationFunctions.Sigmoid);
			net.AddLayer(2);
			net.AddLayer(3);
			net.AddLayer(1);
			net.Build();

			foreach (var sample in dataset)
	        {
		        var output = net.ForwardPass(new [] { (float)sample.A, (float)sample.B });
				Console.WriteLine($"Forward pass: {sample.A}, {sample.B}. Output: {output[0]}. Label: {sample.Label}");
			}

	        Console.ReadKey();
        }
    }
}
