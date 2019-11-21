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
        
        public Forest(int x, int y, int startX, int startY, int size) : base(x,y)
        {
            biome = "forest";
            display = "T";
            CheckNearby(startX, startY, size);           
        }

        public override void PrintTile(int topPosX, int topPosY)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.CursorLeft = (x * 2) + topPosX * 2;
            Console.CursorTop = y + topPosY;
            Console.Write("██");
        }

        public override void Spread(int x, int y, int startX, int startY, int size)
        {
            x = Math.Min(Math.Abs(x), tiles.GetLength(0) - 1);
            y = Math.Min(Math.Abs(y), tiles.GetLength(1) - 1);

            Tile newTile = tiles[x, y];

            if (newTile.biome != "forest" && !newTile.noSpread)
            {
                

                //Thread.Sleep(5);

                Console.CursorTop = 1;
                Console.CursorLeft = 1;
                Console.WriteLine(amount);
                amount++;
                int xDif = startX - x;
                int yDif = startY - y;

                if (random.Next(size) > Math.Sqrt(xDif * xDif + yDif * yDif))
                {
                    tiles[x, y] = new Forest(x, y, startX, startY, size);
                    //this.printTile(0, 0);
                }
                newTile.noSpread = true;
            }                      
        }
    }
}
