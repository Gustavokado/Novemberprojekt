using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeMap
{
    class Plains:Tile
    {
        public Plains(int x, int y) : base(x,y) 
        {
            display = "H";
            biome = "plains";
            
        }
        public override void PrintTile(int topPosX, int topPosY)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorLeft = (x * 2) + topPosX * 2;
            Console.CursorTop = y + topPosY;
            Console.Write("██");
        }
    }
}
