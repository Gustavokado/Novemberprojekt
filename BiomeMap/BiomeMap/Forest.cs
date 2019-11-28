using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BiomeMap
{
    class Forest:Tile
    {
        public Forest(int x, int y, int startX, int startY, int size) : base(x,y,true)
        {
            biome = "forest";
            printColor = ConsoleColor.DarkGreen;
            CheckNearby(startX, startY, size);           
        }

        public override void Spread(int x, int y, int startX, int startY, int size)
        {
            x = Math.Min(Math.Abs(x), tiles.GetLength(0) - 1);
            y = Math.Min(Math.Abs(y), tiles.GetLength(1) - 1);

            Tile newTile = tiles[x, y];

            if (newTile.biome != "forest" && !newTile.noSpread)
            {
                Console.CursorTop = 1;
                Console.CursorLeft = 1;
                Console.WriteLine(amount);
                amount++;
                int xDif = startX - x;
                int yDif = startY - y;

                if (random.Next(size) > Math.Sqrt(xDif * xDif + yDif * yDif))
                {
                    new Forest(x, y, startX, startY, size);
                }
                newTile.noSpread = true;
            }                      
        }
    }
}
