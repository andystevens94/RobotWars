using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Models
{
	public interface IBattleArena
	{
		public int Height { get; init; }
		public int Width { get; init; }
		public IList<Robot> Robots { get; set; }
	}
}