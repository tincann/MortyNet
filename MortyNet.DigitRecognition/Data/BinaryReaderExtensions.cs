using System;
using System.IO;

namespace MortyNet.DigitRecognition.Data
{
    public static class BinaryReaderExtensions
    {
	    public static int ReadInt32BigEndian(this BinaryReader reader)
	    {
		    var buffer = new byte[4];
		    reader.Read(buffer, 0, 4);
			Array.Reverse(buffer);
		    return BitConverter.ToInt32(buffer, 0);
	    }
    }
}
