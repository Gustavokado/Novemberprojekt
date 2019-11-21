using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeMap
{
    class Mountain: Tile
    {
        public static List<Mountain> mountains = new List<Mountain>();
        
        public Mountain(int x, int y, int startX, int startY, int size, bool isStartTile) : base(x,y)
        {
            biome = "mountain";
            display = "A";

            mountains.Add(this);
            
            if (!isStartTile)           
            {                
                CheckNearby(startX, startY, size);
            }           
        }

        public override void PrintTile(int topPosX, int topPosY)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.CursorLeft = (x * 2) + topPosX * 2;
            Console.CursorTop = y + topPosY;
            Console.Write("██");
        }
 
        public override void Spread(int x, int y, int startX, int startY, int size)
        {
            x = Math.Min(Math.Abs(x), tiles.GetLength(0) - 1);
            y = Math.Min(Math.Abs(y), tiles.GetLength(1) - 1);

            Tile newTile = tiles[x, y];

            int xDif = startX - x;
            int yDif = startY - y;

            if (newTile.biome != "mountain" && !newTile.noSpread)
            {
                //Thread.Sleep(5);

                Console.CursorTop = 1;
                Console.CursorLeft = 1;
                Console.WriteLine(Tile.amount);
                amount++;
                
                if (Tile.random.Next(size) / (Math.Sqrt(xDif * xDif + yDif * yDif)) > Math.Sqrt(xDif * xDif + yDif * yDif))
                {

                    //newTile = new Mountain(x, y, startX, startY, size, false);
                    //this.printTile(0, 0);
                }
            }

            newTile.noSpread = true;            
        }

        protected int CalculateAngles(int x1, int y1, int x2, int y2)
        {
            float xDiff = x2 - x1;
            float yDiff = y2 - y1;
            int angleDegrees = Convert.ToInt32(Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI);
            
            return angleDegrees;
        }
       
       
    }
}
