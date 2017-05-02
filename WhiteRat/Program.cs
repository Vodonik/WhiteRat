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

		static int[][] Prepare()
		{
			int[][] data = new int[4][];

			data[0] = new int[] { 0, 0, 1 };
			data[1] = new int[] { 0, 1, 0 };
			data[2] = new int[] { 1, 0, 0 };
			data[3] = new int[] { 1, 1, 0 };

			return data;
		}

		static void Main(string[] args)
		{
			int[] config = { 2, 1 };
			net = new Network(config);

			int[][] tD_prepared = Prepare();
			net.PerceptronLearn(tD_prepared);

			for (int i = 0; i < 4; i++)
			{
				int[] tc = new int[] { tD_prepared[i][0], tD_prepared[i][1] };
				net.FeedForward(tc);
				Console.WriteLine(tc[0] + " " + tc[1] + " | " + tD_prepared[i][2] + " -> " + net.output[0]);
			}

			Console.WriteLine("\nGot to here!");
			Console.ReadLine();
		}
	}
}
