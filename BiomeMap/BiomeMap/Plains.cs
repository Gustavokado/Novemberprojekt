using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeMap
{
    class Plains:Tile
    {
        public Plains(int x, int y, int startX, int startY, int size) : base(x, y, startX, startY, size)
        {
            display = "H";
            
            
        }
        public override void printTile(int topPosX, int topPosY)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorLeft = (x * 2) + topPosX * 2;
            Console.CursorTop = y + topPosY;
            Console.Write("██");
        }
    }
}
