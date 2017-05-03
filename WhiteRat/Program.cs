using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WhiteRat
{
	class Program
	{
		static Network net;

		static void Main(string[] args)
		{
			int[] config = { 256, 16, 1 };
			net = new Network(config);

			int[][] tD_prepared = PrepareTrainingData();
			net.PerceptronLearn(tD_prepared);

			int[][] testData = PrepareTestData();

			for (int i = 0; i < testData.Length; i++)
			{
				net.FeedForward(testData[i].Take(testData[i].Length - 1).ToArray());
				Console.WriteLine(tD_prepared[i][256] + " -> " + net.output[0]);
			}

			Console.WriteLine("\nGot to here!");
			Console.ReadLine();
		}

		static int[][] PrepareTrainingData()
		{
			string testDataPath = @"..\..\Xs\TrainingData";
			string[] test = Directory.GetFiles(testDataPath);

			int[][] imgs = new int[test.Length][];

			for (int i = 0; i < imgs.Length; i++)
			{
				imgs[i] = new int[257];
				Bitmap img = new Bitmap(test[i]);

				int pixelCounter = 0;

				for (int x = 0; x < img.Width; x++)
				{
					for (int y = 0; y < img.Height; y++)
					{
						int value = img.GetPixel(x, y).G;
						imgs[i][pixelCounter] = value;
						pixelCounter++;
					}
				}

				int result = (Path.GetFileName(test[i])[0] == 'x') ? 1 : 0;
				imgs[i][pixelCounter] = result;
			}

			return imgs;
		}

		static int[][] PrepareTestData()
		{
			string testDataPath = @"..\..\Xs\TestData";
			string[] test = Directory.GetFiles(testDataPath);

			int[][] imgs = new int[test.Length][];

			for (int i = 0; i < imgs.Length; i++)
			{
				imgs[i] = new int[257];
				Bitmap img = new Bitmap(test[i]);

				int pixelCounter = 0;

				for (int x = 0; x < img.Width; x++)
				{
					for (int y = 0; y < img.Height; y++)
					{
						int value = img.GetPixel(x, y).G;
						imgs[i][pixelCounter] = value;
						pixelCounter++;
					}
				}

				int result = (Path.GetFileName(test[i])[0] == 'x') ? 1 : 0;
				imgs[i][pixelCounter] = result;
			}

			return imgs;
		}
	}
}
