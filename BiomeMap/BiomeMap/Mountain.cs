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

        List<Mountain> mountainsInRange = new List<Mountain>();

        public Mountain(int x, int y, int startX, int startY, int size, bool isStartTile, bool spread) : base(x,y,isStartTile)
        {
            biome = "mountain";
            printColor = ConsoleColor.Gray;
           
            if (isStartTile)
            {               
                CheckForMountainsInRange(25);
            }
                       
            if(spread)          
            {
                CheckNearby(startX, startY, size);
            }
            else
            {
                mountains.Add(this);
            }
        }

        public override void Spread(int x, int y, int startX, int startY, int size)
        {
            x = Math.Min(Math.Abs(x), tiles.GetLength(0) - 1);
            y = Math.Min(Math.Abs(y), tiles.GetLength(1) - 1);

            Tile newTile = tiles[x, y];

            if (newTile.biome != "mountain" && !newTile.noSpread)
            {
                Console.CursorTop = 1;
                Console.CursorLeft = 1;
                Console.WriteLine(Tile.amount);
                amount++;
                int xDif = startX - x;
                int yDif = startY - y;

                if (random.Next(size)> Math.Sqrt(xDif * xDif + yDif * yDif))
                {
                    newTile=new Mountain(x, y, startX, startY, size, false, true);                    
                }
            }

            //newTile.noSpread = true;            
        }
       
        public void CheckForMountainsInRange(int range)
        {
            for (int i = 0; i < mountains.Count; i++)
            {
                int xDif = x - mountains[i].x;
                int yDif = y - mountains[i].y;

                if (Math.Sqrt(xDif * xDif + yDif * yDif) < range)
                {
                    if (mountains[i] != this && mountains[i].isStartTile)
                    {
                        ConnectMountains(mountains[i].x, mountains[i].y);
                    }
                }
            }
        }
       
        public void ConnectMountains(int targetX, int targetY)
        {
            for (float t = 0; t <= 1; t+=0.01f)
            {
                int xPos = Convert.ToInt32(targetX - (targetX * t - x * t));
                int yPos = Convert.ToInt32(targetY - (targetY * t - y * t));

                if (tiles[xPos ,yPos].biome!="Mountain")
                {
                    tiles[xPos, yPos] = new Mountain(xPos,yPos,0,0,0,false,false);
                }
            }           
        }
    }
}
