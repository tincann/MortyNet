using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MortyNet.DigitRecognition.Data
{
    public static class MNISTLoader
    {
		public static IEnumerable<ImageSample> LoadImageSamples(string imagePath, string labelPath)
	    {
		    using (var imageStream = new BinaryReader(File.OpenRead(imagePath)))
			using (var labelStream = new BinaryReader(File.OpenRead(labelPath)))
			{
				//skip magic number
				imageStream.BaseStream.Position = 4;

				var sampleCount = imageStream.ReadInt32BigEndian();
				var rowCount = imageStream.ReadInt32BigEndian();
				var columnCount = imageStream.ReadInt32BigEndian();

				//skip header for label file
				labelStream.BaseStream.Position = 8;

				for (var i = 0; i < sampleCount; i++)
				{
					var imageData = new byte[rowCount * columnCount];
					imageStream.Read(imageData, 0, imageData.Length);

					var label = (int)labelStream.ReadByte();
					
					yield return new ImageSample
					{
						DataRows = rowCount,
						DataColumns = columnCount,
						Data = imageData,
						Label = label
					};
				}
			}
	    }
    }

	public struct ImageSample
	{
		public int DataRows;
		public int DataColumns;
		public byte[] Data;
		public int Label;
	}
}
