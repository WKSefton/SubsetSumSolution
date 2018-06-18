using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSum {
	class Program {

		public static int Target = 100000000;
		public static int TargetSize = 18;
		public static double Deviation = 100;
		public static int SetSize = 26;

		public static TimeSpan TimeTaken = new TimeSpan();
		public static List<int> Set = new List<int>() { 18897109, 12828837, 9461105,
			6371773, 5965343, 5946800, 5582170, 5564635, 5268860, 4552402, 4335391,
			4296250, 4224851, 4192887, 3439809, 3279833, 3095313, 2812896, 2783243,
			2710489, 2543482, 2356285, 2226009, 2149127, 2142508, 2134411};
		
		static void Main(string[] args) {
			//Create Create = new Create(SetSize, TargetSize, Deviation, Target);
			//Create.FillSet();
			//Create.CheckSet();
			//Create.Print();

			Create Create = new Create();
			Create.Set = Set.ToArray();

			DateTime TimeStart = DateTime.Now;
			Solve Solve = new Solve(Create.Set, Target);
			
			TimeTaken = Solve.TimeEnd - TimeStart;

			Console.WriteLine($"\nStart Time: {TimeStart}");
			Console.WriteLine($"End Time: {Solve.TimeEnd}");
			Console.WriteLine($"Time Taken: {TimeTaken}");
			Console.WriteLine($"MilliSeconds Taken: {TimeTaken.Milliseconds}");

			Console.WriteLine("\nSubset Found:");
			Solve.Set.Sort();
			Solve.Set.ForEach(x => Console.WriteLine($"{x:N0}"));
			Console.WriteLine($"Sum: {Solve.Set.Sum():N0}\n");

			Console.WriteLine("Original Set:");
			int RunningSum = 0;
			for(int i = 0; i < Create.Set.Length; i++) {
				if (Solve.Set.Contains(Create.Set[i])) {
					Console.WriteLine($"{Create.Set[i]:N0} Found In Set! Running Sum: {RunningSum+=Create.Set[i]:N0}");
				}
					Console.WriteLine($"{Create.Set[i]:N0}");
			}
		}
	}
}
