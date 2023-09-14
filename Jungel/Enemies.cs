using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungel
{
    public class Enemies
    {
		private int index;

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

		private int hp;

		public int Hp
		{
			get { return hp; }
			set { hp = value; }
		}

		private int damage;

		public int Damage
		{
			get { return damage; }
			set { damage = value; }
		}

		public Enemies(int a1, string a2, int a3, int a4)
		{
			Index = a1;
			Name = a2;
			Hp = a3;
			Damage = a4;
		}
	}
}
