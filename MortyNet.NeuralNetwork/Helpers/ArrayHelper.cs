using System;

namespace MortyNet.NeuralNetwork.Helpers
{
    public static class ArrayHelper
    {
	    public static double[] RandomNormal(int count, double mean, double stdDev)
	    {
			var rand = new Random();

		    var output = new double[count];

		    for (var i = 0; i < count; i++)
		    {
			    var u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
			    var u2 = 1.0 - rand.NextDouble();
			    var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
			    output[i] = mean + stdDev * randStdNormal;
		    }
		    return output;
	    }
	}
}
