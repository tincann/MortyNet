using System;
using System.Collections.Generic;
using System.Linq;
using MortyNet.NeuralNetwork.Helpers;

namespace MortyNet.NeuralNetwork
{
	//Inefficient conceptual neural network
    public class SimpleNeuralNetwork
    {
	    private readonly Func<double, double> _activationFunc;
	    private readonly List<Layer> _layers = new List<Layer>();

	    private Layer InputLayer => _layers[0];
	    private Layer OutputLayer => _layers[_layers.Count - 1];

		public SimpleNeuralNetwork(Func<double, double> activationFunc)
	    {
		    _activationFunc = activationFunc;
	    }

	    public void AddLayer(int count)
	    {
			var layer = new Layer(layerIndex: _layers.Count);
		    while (count-- > 0)
		    {
			    layer.Add(new Neuron());
		    }
			_layers.Add(layer);
	    }

	    public void Build()
	    {
		    for (var layerIndex = 1; layerIndex < _layers.Count; layerIndex++)
		    {
				//connect layers
			    var prevousLayer = _layers[layerIndex - 1];
			    var currentLayer = _layers[layerIndex];

			    foreach (var neuron in currentLayer)
			    {
				    neuron.Weights = ArrayHelper.RandomNormal(prevousLayer.Count, 0, 0.1);
			    }
			}
	    }

	    public double[] ForwardPass(float[] input)
	    {
		    if (input.Length != _layers[0].Count)
		    {
			    throw new Exception("Input doesn't match number of input neurons");
		    }

			//Fill input neurons
		    for (var i = 0; i < input.Length; i++)
		    {
			    _layers[0][i].Value = input[i];
		    }

		    for (var layerIndex = 1; layerIndex < _layers.Count; layerIndex++)
		    {
			    var previousLayer = _layers[layerIndex - 1];
			    var currentLayer = _layers[layerIndex];
				foreach (var neuron in currentLayer)
				{
					var sum = neuron.Weights.Select((w, i) => w * previousLayer[i].Value).Sum();
					neuron.Value = _activationFunc.Invoke(sum);
				}
		    }

		    return OutputLayer.Select(x => x.Value).ToArray();
	    }

	    public void Train(int maxEpochs, int batchSize)
	    {
		    for (var epoch = 0; epoch < maxEpochs; epoch++)
		    {
			    
		    }
	    }

	    private class Layer : List<Neuron>
	    {
		    public Layer(int layerIndex) { }
	    }

	    private class Neuron
	    {
		    public double Value;
		    public double[] Weights;
			//todo biases
	    }
	}

	
}
