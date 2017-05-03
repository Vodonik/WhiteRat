using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteRat
{
	class Network
	{
		private int[] configuration;
		private int numberOfLayers;
		public Layer[] layers;
		public float[] output;

		public Network(int[] config)
		{
			configuration = config;
			numberOfLayers = config.Length;
			output = new float[config.Last()];

			layers = new Layer[numberOfLayers];

			//For to loop through layers (i is the i-th layer in layers)
			for (int i = 0; i < numberOfLayers; i++)
			{
				int neuronsInLayer = configuration[i];

				Layer layerToAdd = new Layer(neuronsInLayer);

				//For to loop through neurons (j is the j-th neuron in i-th layer)
				for (int j = 0; j < neuronsInLayer; j++)
				{
					Neuron n;

					if (i == 0)
						n = new Neuron(0);
					else
						n = new Neuron(configuration[i - 1]);

					layerToAdd.neurons[j] = n;
				}

				layers[i] = layerToAdd;
			}
		}

		private float[] tempOutputs;

		public void FeedForward(int[] inputVector)
		{
			//Set first layer outputs to inputVector
			for (int i = 0; i < inputVector.Length; i++)
				layers[0].neurons[i].output = inputVector[i];

			//Feedforward
			for (int i = 1; i < layers.Length; i++)
			{
				tempOutputs = new float[layers[i - 1].neurons.Length];

				//Set tempOutputs helper array to previous layer outputs
				for (int j = 0; j < tempOutputs.Length; j++)
					tempOutputs[j] = layers[i - 1].neurons[j].output;

				//Use tempOutputs to set current layer inputs to previous layer outputs
				for (int j = 0; j < layers[i].neurons.Length; j++)
				{
					layers[i].neurons[j].inputs = tempOutputs;
					layers[i].neurons[j].ComputeOutput();
				}
			}

			//Set network output vector
			for (int i = 0; i < output.Length; i++)
				output[i] = layers.Last().neurons[i].output;
		}

		public void PerceptronLearn(int[][] tData)
		{
			int iterations = 10;

			for (int iteration = 0; iteration < iterations; iteration++)
				foreach (int[] testCase in tData)
				{
					int[] inputVector = new int[] { testCase[0], testCase[1] };
					FeedForward(inputVector);
					float actual = this.output[0];
					float desired = testCase[2];

					foreach (Layer l in layers)
						foreach (Neuron n in l.neurons)
						{
							float error = desired - actual;
							for (int i = 0; i < n.inputs.Length; i++)
								n.weights[i] += error * n.inputs[i];
							n.bias += error;
						}

				}
		} //End PerceptronLearn() function
	} //End Network class

	struct Layer
	{
		public Neuron[] neurons;

		public Layer(int neuronNumber)
		{
			neurons = new Neuron[neuronNumber];
		}
	}

	struct TestData
	{
		public int[] inputVector { get; set; }
		public int outputValue { get; set; }
	}
}
