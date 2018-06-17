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


		static void Main(string[] args) {

			Create Create = new Create(SetSize, TargetSize, Deviation, Target);
			Create.FillSet();
			Create.CheckSet();
			Create.Print();

			DateTime TimeStart = DateTime.Now;
			Solve Solve = new Solve(Create.Set, Target);
			DateTime TimeEnd = DateTime.Now;
			TimeTaken = TimeEnd - TimeStart;

			Console.WriteLine($"\nStart Time: {TimeStart}");
			Console.WriteLine($"End Time: {TimeEnd}");
			Console.WriteLine($"Time Taken: {TimeTaken}");
			Console.WriteLine($"MilliSeconds Taken: {TimeTaken.Milliseconds}");

			Console.WriteLine("\nSubset Found:");
			Solve.Set.Sort();
			Solve.Set.ForEach(x => Console.WriteLine($"{x:N0}"));
			Console.WriteLine($"Sum: {Solve.Set.Sum():N0}");

			for (int i = 0; i < Create.Set.Length; i++) {
				
			}
		}
	}
}
