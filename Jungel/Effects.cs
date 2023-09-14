using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungel
{
    public class Effects
    {
		private int index;

		public int Index		//3 - burning; 2 - freezing; 1 - healing; 4 attack boost
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

		private int boost;

		public int Boost		// attack is % !!!!
		{
			get { return boost; }
			set { boost = value; }
		}

		private string playerInfo;

		public string PlayerInfo
		{
			get { return playerInfo; }
			set { playerInfo = value; }
		}

		public Effects(int a1, string a2, int a3, string a4)
		{
			Index = a1;
			Name = a2;
			Boost = a3;
			PlayerInfo = a4;
		}
	}
}
