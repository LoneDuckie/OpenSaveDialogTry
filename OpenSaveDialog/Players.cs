using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSaveDialog
{
    internal class Players
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public string SC { get; set; }
        public string Pos { get; set; }
        public int GP { get; set; }


        public Players(string name, string team, string sc, string pos, int gp)
        {
            Name = name;
            Team = team;
            SC = sc;
            Pos = pos;
            GP = gp;
        }
    }
}
