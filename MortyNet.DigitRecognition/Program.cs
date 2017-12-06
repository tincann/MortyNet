using System.IO;
using System.Linq;
using MortyNet.DigitRecognition.Data;
using MortyNet.DigitRecognition.Visualization;

namespace MortyNet.DigitRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
	        var datasetDirectory = "dataset";
	        var trainingImagesPath = Path.Combine(datasetDirectory, "train-images.idx3-ubyte");
	        var trainingLabelsPath = Path.Combine(datasetDirectory, "train-labels.idx1-ubyte");

	        var trainingSet = MNISTLoader.LoadImageSamples(trainingImagesPath, trainingLabelsPath).Take(5);
			
	        var i = 0;
	        foreach (var sample in trainingSet)
	        {
			    var path = Path.Combine(datasetDirectory, "examples", $"{i}_{sample.Label}.png");
				SampleVisualizer.SaveAsPng(sample, path);
		        i++;
	        }
		}
    }
}
