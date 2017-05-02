using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteRat
{
	class Program
	{
		static Network net;

		static TestData[] Prepare()
		{
			TestData[] tD = new TestData[4];

			TestData tD1 = new TestData();
			tD1.inputVector = new int[2] { 0, 0 };
			tD1.outputValue = 1;
			tD[0] = tD1;

			TestData tD2 = new TestData();
			tD2.inputVector = new int[2] { 0, 1 };
			tD2.outputValue = 1;
			tD[1] = tD2;

			TestData tD3 = new TestData();
			tD3.inputVector = new int[2] { 1, 0 };
			tD3.outputValue = 1;
			tD[2] = tD3;

			TestData tD4 = new TestData();
			tD4.inputVector = new int[2] { 1, 1 };
			tD4.outputValue = 0;
			tD[3] = tD4;

			return tD;
		}

		static void Main(string[] args)
		{
			int[] config = { 2, 1 };
			net = new Network(config);

			TestData[] tD_prepared = Prepare();
			net.PerceptronLearn(tD_prepared);
			
			net.FeedForward(new int[] { 0, 0 });
			Console.WriteLine(net.output[0]);
			net.FeedForward(new int[] { 0, 1 });
			Console.WriteLine(net.output[0]);
			net.FeedForward(new int[] { 1, 0 });
			Console.WriteLine(net.output[0]);
			net.FeedForward(new int[] { 1, 1 });
			Console.WriteLine(net.output[0]);

			Console.WriteLine("\nGot to here!");
			Console.ReadLine();
		}
	}
}
