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
        
        public Forest(int x, int y, int startX, int startY, int size) : base(x, y, startX, startY, size)
        {
            biome = "forest";
            display = "T";
            CheckNearby(startX, startY, size);           
        }

        public override void printTile(int topPosX, int topPosY)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.CursorLeft = (x * 2) + topPosX * 2;
            Console.CursorTop = y + topPosY;
            Console.Write("██");
        }

        public override void spread(int x, int y, int startX, int startY, int size)
        {
            x = Math.Min(Math.Abs(x), tiles.GetLength(0) - 1);
            y = Math.Min(Math.Abs(y), tiles.GetLength(1) - 1);

            Tile newTile = tiles[x, y];

            if (newTile.biome != "forest" && !newTile.noSpread)
            {
                random.Next(0, size / 2);

                //Thread.Sleep(5);

                Console.CursorTop = 1;
                Console.CursorLeft = 1;
                Console.WriteLine(Tile.amount);
                amount++;
                int xDif = startX - x;
                int yDif = startY - y;

                if (Tile.random.Next(size) > Math.Sqrt(xDif * xDif + yDif * yDif))
                {
                    newTile = new Forest(x, y, startX, startY, size);
                    //this.printTile(0, 0);
                }
                newTile.noSpread = true;
            }                      
        }
    }
}
