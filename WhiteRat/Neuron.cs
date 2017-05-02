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

		public float threshold;

		public Neuron(int inputsNo)
		{
			numberOfInputs = inputsNo;
			weights = new float[numberOfInputs];
			inputs = new float[numberOfInputs];
			//inputs[0] = 1;

			threshold = 0;

			ID = numberOfNeurons;
			numberOfNeurons++;
		}

		public void ComputeOutput()
		{
			float inputsSum = 0;

			for (int i = 0; i < numberOfInputs; i++)
				inputsSum += weights[i] * inputs[i];

			//Perceptron
			this.output = ActivationFunction(inputsSum);
		}

		private int ActivationFunction(float sum)
		{
			//Perceptron
			return (sum >= threshold) ? 1 : 0;
		}
	}
}
