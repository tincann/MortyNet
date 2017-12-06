using System;
using System.IO;
using System.Linq;
using MortyNet.DigitRecognition.Data;
using SixLabors.ImageSharp;

namespace MortyNet.DigitRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
	        var datasetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "dataset");
	        var trainingImagesPath = Path.Combine(datasetDirectory, "train-images.idx3-ubyte");
	        var trainingLabelsPath = Path.Combine(datasetDirectory, "train-labels.idx1-ubyte");

	        var trainingSet = MNISTLoader.LoadImageSamples(trainingImagesPath, trainingLabelsPath).Take(5);


	        var i = 0;
	        foreach (var sample in trainingSet)
	        {
		        var pixels = sample.Data.Select(x => new Rgba32(x, x, x));
		        var image = Image.LoadPixelData(pixels.ToArray(), sample.DataColumns, sample.DataRows);

		        var path = Path.Combine("dataset", "examples", $"{i}_{sample.Label}.png");
		        Directory.CreateDirectory(Path.GetDirectoryName(path));
				using (var fs = File.OpenWrite(path))
		        {
					image.SaveAsPng(fs);
				}

				i++;
	        }
		}
    }
}
