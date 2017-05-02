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
				for (int j = 1; j < tempOutputs.Length; j++)
					tempOutputs[j] = layers[i - 1].neurons[j].output;

				//Use tempOutputs to set current layer inputs to previous layer outputs
				for (int j = 0; j < layers[i].neurons.Length; j++)
				{
					for (int k = 0; k < tempOutputs.Length; k++)
						layers[i].neurons[j].inputs[k + 1] = tempOutputs[k];
					layers[i].neurons[j].ComputeOutput();
				}
			}

			//Set network output vector
			for (int i = 0; i < output.Length; i++)
				output[i] = layers.Last().neurons[i].output;
		}

		public void PerceptronLearn(TestData[] tData)
		{
			int iterations = 10;

			for (int iteration = 0; iteration < iterations; iteration++)
			{
				for (int testCase = 0; testCase < tData.Length; testCase++)
				{
					FeedForward(tData[testCase].inputVector);
					float output = this.output[0];

					for (int i = 1; i < layers.Length; i++)
						for (int j = 0; j < layers[i].neurons.Length; j++)
							for (int k = 0; k < layers[i].neurons[j].inputs.Length; k++)
								layers[i].neurons[j].weights[k] += (tData[testCase].outputValue - output) * layers[i].neurons[j].inputs[k];
				}
			}
		}
	}

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
