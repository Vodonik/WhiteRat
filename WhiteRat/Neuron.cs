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

		public int output;

		public Neuron(int inputsNo)
		{
			numberOfInputs = inputsNo + 1;
			weights = new float[numberOfInputs];
			inputs = new float[numberOfInputs];
			inputs[0] = 1;

			ID = numberOfNeurons;
			numberOfNeurons++;
		}

		public void ComputeOutput()
		{
			float inputsSum = 0;

			for (int i = 0; i < numberOfInputs; i++)
				inputsSum += weights[i] * inputs[i];

			float biasedInputsSum = inputsSum + weights[0];

			//Perceptron
			this.output = ActivationFunction(biasedInputsSum);
		}

		private int ActivationFunction(float sum)
		{
			//Perceptron
			return (sum > 0) ? 1 : 0;
		}
	}
}
