using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhiteRat
{
	public partial class Form1 : Form
	{
		static Network net;
		int[][] tD_prepared;
		int[][] testData;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			int[] config = { 2, 2, 2 };
			net = new Network(config);
		}

		private void btnPrepare_Click(object sender, EventArgs e)
		{
			tD_prepared = PrepareTrainingData();
			testData = PrepareTestData();
		}

		private void btnLearn_Click(object sender, EventArgs e)
		{
			net.PerceptronLearn(tD_prepared);
		}

		public int counter = 0;

		private void btnTest_Click(object sender, EventArgs e)
		{
			int[] imagePartOfCase = testData[counter].Take(testData[counter].Length - 1).ToArray();

			net.FeedForward(imagePartOfCase);
			string line = testData[counter][256] + " -> " + net.output[0];

			PaintPicture(imagePartOfCase);

			txtDebug.Text += line + Environment.NewLine;

			counter++;
		}

		private void PaintPicture(int[] pixels)
		{
			int size = 16;
			Bitmap img = new Bitmap(size, size);

			int index = 0;

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					img.SetPixel(i, j, Color.FromArgb(pixels[index], pixels[index], pixels[index]));
					index++;
				}
			}

			pbxDraw.Image = img;
		}

		private int[][] PrepareTrainingData()
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

		private int[][] PrepareTestData()
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

		private void button1_Click(object sender, EventArgs e)
		{
			int[] netConfig = new int[3] { 2, 3, 1 };
			NetworkSimple n = new NetworkSimple(netConfig);

			float[,] testInput = new float[1, 2] { { 6, 8 } };

			float[,] o = n.Forward(testInput);
		}
	}
}
