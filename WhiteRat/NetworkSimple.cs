using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteRat
{
	class NetworkSimple
	{
		private Random rand;

		private int
			inputLayerSize,
			outputLayerSize,
			hiddenLayerNumber;

		private int numberOfTrainingExamples = 1;

		private int[]
			configuration,
			hiddenLayersSizes;

		private float[][,]
			weightsMatrices,
			sumsMatrices,
			outputMatrices;

		private void InitializeWeightsMatrices()
		{
			weightsMatrices = new float[configuration.Length - 1][,];

			for (int i = 0; i < weightsMatrices.Length; i++)
			{
				int rows = configuration[i];
				int cols = configuration[i + 1];
				weightsMatrices[i] = new float[rows, cols];

				for (int j = 0; j < rows; j++)
					for (int k = 0; k < cols; k++)
						weightsMatrices[i][j, k] = (float)rand.NextDouble();
			}
		}

		private void InitializeSumsMatrices()
		{
			sumsMatrices = new float[configuration.Length - 1][,];

			for (int i = 0; i < sumsMatrices.Length; i++)
			{
				int rows = numberOfTrainingExamples;
				int cols = configuration[i + 1];
				sumsMatrices[i] = new float[rows, cols];
			}
		}

		private void InitializeOutputsMatrices()
		{
			outputMatrices = new float[configuration.Length - 1][,];

			for (int i = 0; i < outputMatrices.Length; i++)
			{
				int rows = numberOfTrainingExamples;
				int cols = configuration[i + 1];
				outputMatrices[i] = new float[rows, cols];
			}
		}

		private void DisplayMatrices()
		{
			Console.WriteLine("Weights");
			foreach (float[,] matrix in weightsMatrices)
				Console.WriteLine(matrix.GetLength(0) + " x " + matrix.GetLength(1));

			Console.WriteLine("Sums");
			foreach (float[,] matrix in sumsMatrices)
				Console.WriteLine(matrix.GetLength(0) + " x " + matrix.GetLength(1));

			Console.WriteLine("Outputs");
			foreach (float[,] matrix in outputMatrices)
				Console.WriteLine(matrix.GetLength(0) + " x " + matrix.GetLength(1));
		}

		private void InitializeMatrices()
		{
			InitializeWeightsMatrices();
			InitializeSumsMatrices();
			InitializeOutputsMatrices();

			//DisplayMatrices();
		}

		public NetworkSimple(int[] config)
		{
			rand = new Random();
			configuration = config;
			inputLayerSize = configuration[0];
			outputLayerSize = configuration.Last();
			hiddenLayerNumber = configuration.Length - 2;

			hiddenLayersSizes = new int[hiddenLayerNumber];
			Array.Copy(configuration, 1, hiddenLayersSizes, 0, hiddenLayerNumber);

			InitializeMatrices();
		}
		
		public float[,] Forward(float[,] input)
		{
			float[,] X = input;

			for (int i = 0; i < configuration.Length - 1; i++)
			{
				sumsMatrices[i] = DotProduct(X, weightsMatrices[i]);
				outputMatrices[i] = Sigmoid(sumsMatrices[i]);

				X = outputMatrices[i];
			}

			return X;
		}

		private float[,] DotProduct(float[,] inputs, float[,] weights)
		{
			int rows = inputs.GetLength(0);
			int cols = weights.GetLength(1);
			float[,] sums = new float[rows, cols];

			for (int i = 0; i < rows; i++)
				for (int j = 0; j < cols; j++)
					for (int k = 0; k < weights.GetLength(0); k++)
						sums[i, j] += inputs[i, k] * weights[k, j];

			return sums;
		}

		private float[,] Sigmoid(float[,] sums)
		{
			int rows = sums.GetLength(0);
			int cols = sums.GetLength(1);
			float[,] activations = new float[rows, cols];

			for (int i = 0; i < rows; i++)
				for (int j = 0; j < cols; j++)
					activations[i, j] = 1.0f / (1 + (float)Math.Exp(-sums[i, j]));

			return activations;
		}
	}
}
