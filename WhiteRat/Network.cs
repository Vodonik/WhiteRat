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

		public Network(int[] config)
		{
			configuration = config;
			numberOfLayers = config.Length;

			layers = new Layer[numberOfLayers];

			for (int i = 0; i < numberOfLayers; i++)
			{
				int neuronsInLayer = configuration[i];
				Layer layerToAdd = new Layer(neuronsInLayer);
				for (int j = 0; j < neuronsInLayer; j++)
				{
					Neuron n;

					if (i == 0)
						n = new Neuron(0);
					else
						n = new Neuron(configuration[i - 1]);
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
}
