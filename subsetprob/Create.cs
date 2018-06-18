using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSum {
	class Create {

		public int[] Set { get; set; }
		private int Target { get; set; }
		private int TargetSize { get; set; }
		private int SetSize { get; set; }
		private double Deviation { get; set; }
		private double MaxDeviation { get; set; }
		private	Random rand = new Random();

		public Create() { }

		public Create(int setsize, int targetSize, double deviation, int target) {
			SetSize = setsize;
			Target = target;
			TargetSize = targetSize;
			Deviation = deviation / 100;
			MaxDeviation = (double)(Target / TargetSize) / Target;
			if (Deviation > MaxDeviation) {
				Deviation = MaxDeviation;
			}
			Deviation = Target * Deviation;
			Set = new int[TargetSize];
			for (int i = 0; i < TargetSize; i++) {
				Set[i] = ((Target) / (TargetSize));
				if (i % rand.Next(2, 30) == 0) {
					Set[i] -= rand.Next(1, (int)Deviation);

				} else {
					Set[i] += rand.Next(1, (int)Deviation);
				}
			}
			while (Set.Sum() != Target) {
				int remainder = Target - Set.Sum();
				if (remainder <= 1) {
					Set[0] += 1;
					break;
				}
				Set[rand.Next(0, Set.Length)] += rand.Next(1, remainder);
			}
		}

		public void FillSet() {
			int[] set = new int[SetSize];
			for (int i = 0; i < Set.Length; i++) {
				set[i] = Set[i];
			}
			for (int i = Set.Length; i < set.Length; i++) {
				set[i] = rand.Next(1, Target);
			}
			Set = set;
		}

		public void CheckSet() {
			for (int i = 0; i < Set.Length; i++) {
				for (int k = 0; k < Set.Length; k++) {
					if (i != k) {
						if (Set[i] == Set[k]) {
							Console.WriteLine("Solution set not unique!");
						}
					}
				}
			}
		}

		public void Print() {

			Console.WriteLine($"Target Sum: {Target:N0}");

			Console.WriteLine($"Solution Elements: {Set.Length}");
			Console.WriteLine($"Max Deviation: {MaxDeviation:P}");
			Console.WriteLine($"Devation %: {Deviation/Target:P}");
			Console.WriteLine($"Devation: {Deviation:N0}");

			List<int> answer = Set.ToList();
			answer.Sort();
			Console.WriteLine("Random Array:");
			foreach (int item in answer) {
				Console.WriteLine($"{item:N0}");
			}
			Console.WriteLine($"Total Sum: {Set.Sum():N0}");
		}
	}
}
