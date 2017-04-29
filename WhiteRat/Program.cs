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

		static void Main(string[] args)
		{
			int[] config = { 2, 1 };
			net = new Network(config);

			Console.WriteLine(net.layers);

			Console.WriteLine("Got to here!");
			Console.ReadLine();
		}
	}
}
