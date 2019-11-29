using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeMap
{
    class Plains:Tile
    {        
        public Plains(int x, int y) : base(x,y,true) // bastilen som först fyller arrayen, behöver ingen egen funktionalitet förutom sin egen färg
        {          
            biome = "plains";
            printColor = ConsoleColor.Green;
        }       
    }
}
