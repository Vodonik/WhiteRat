using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteRat
{
	class Neuron
	{
		public static int numberOfNeurons;
		public int ID;
		private int numberOfInputs;

		public float[]
			weights,
			inputs;

		public float output;

		public float bias;

		public Neuron(int inputsNo)
		{
			numberOfInputs = inputsNo;
			weights = new float[numberOfInputs];
			inputs = new float[numberOfInputs];
			bias = 0;

			ID = numberOfNeurons;
			numberOfNeurons++;
		}

		public void ComputeOutput()
		{
			float inputsSum = 0;

			for (int i = 0; i < numberOfInputs; i++)
				inputsSum += weights[i] * inputs[i];

			float biased = inputsSum + bias;

			//Sigmoid
			this.output = 1.0f / (1 + (float)Math.Exp(-biased));
		}
	}
}
