using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSum {
	class Solve {

		public List<int> Set = new List<int>();
		public DateTime TimeEnd { get; set; }

		public Solve(int[] set, int target) {
			bool[] pointer = new bool[set.Length];
			int sum = 0;
			int index = 0;
			Solving(set, pointer, target, sum, index);
		}

		private void Solving(int[] set, bool[] pointer, int target, int sum, int index) {
			if (sum == target) {
				TimeEnd = DateTime.Now;
				for (int i = 0; i < pointer.Length; i++) {
					if (pointer[i]) {
						Set.Add(set[i]);
					}
				}
				return;
			} else if (index == set.Length || sum > target) {
				return;
			} else {
				pointer[index] = true;
				sum += set[index];
				Solving(set, pointer, target, sum, index+1);
				sum -= set[index];
				pointer[index] = false;
				Solving(set, pointer, target, sum, index+1);
			}
			return;
		}
	}
}
