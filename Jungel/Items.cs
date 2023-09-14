using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungel
{
    public class Items
    {
		//here the items stats, only 3 wepon is valabe

		private int index;

		public int Index		// 1 - sword, 2 - bow, 3 - spear
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

		private int damage;

		public int Damage
		{
			get { return damage; }
			set { damage = value; }
		}

		public Items(string a2, int a1, int a3)
		{
			index = a1;
			name = a2;
			damage = a3;
		}
	}
}
