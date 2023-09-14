using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungel
{
    public class Player
    {
		//this the player info

		private int level;		//max level 5

		public int Level
		{
			get { return level; }
			set { level = value; }
		}

		private int itemIndex;	//3 item, sword, bow, spear

		public int ItemIndex
		{
			get { return itemIndex; }
			set { itemIndex = value; }
		}

		private int statusEffect;		//like posion, buff ect

		public int StatusEffect
		{
			get { return statusEffect; }
			set { statusEffect = value; }
		}

		private int hp;		// start 100 -> to 180

		public int Hp
		{
			get { return hp; }
			set { hp = value; }
		}

		private int ap;

		public int Ap
		{
			get { return ap; }
			set { ap = value; }
		}


		public Player(int level, int item, int status, int hp1, int ap1)
		{
			Level = level;
			ItemIndex = item;
			StatusEffect = status;
			Hp = hp1;
			Ap = ap1;
		}
	}
}
