using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungel
{
    internal class SpecialSkills
    {
		private int index;		// 1 - healing 2 - attack 3 remove status

		public int Index
		{
			get { return index; }
			set { index = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private int done;		// 1 - effect ref 2 - how much 3 - change player status 0

		public int Done
		{
			get { return done; }
			set { done = value; }
		}


		private string screen;

		public string sceern
		{
			get { return screen; }
			set { screen = value; }
		}

		private int ap;

		public int Ap
		{
			get { return ap; }
			set { ap = value; }
		}

		public SpecialSkills(int a1, string a2, int a3, string a4, int a5)
		{
			Index = a1;
			Name = a2;
			Done = a3;
			Name = a4;
			Ap = a5;
		}
	}
}
