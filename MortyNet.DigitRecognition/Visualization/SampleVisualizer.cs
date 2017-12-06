using System.IO;
using System.Linq;
using MortyNet.DigitRecognition.Data;
using SixLabors.ImageSharp;

namespace MortyNet.DigitRecognition.Visualization
{
    public class SampleVisualizer
    {
	    public static void SaveAsPng(ImageSample sample, string path)
	    {
			var pixels = sample.Data.Select(x => new Rgba32(x, x, x)).ToArray();
		    var image = Image.LoadPixelData(pixels, sample.DataColumns, sample.DataRows);

		    Directory.CreateDirectory(Path.GetDirectoryName(path));
		    using (var fs = File.OpenWrite(path))
		    {
			    image.SaveAsPng(fs);
		    }
		}
    }
}
