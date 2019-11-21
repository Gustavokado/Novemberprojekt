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

        List<int> anglesToMountains = new List<int>();
        
        public Mountain(int x, int y, int startX, int startY, int size, bool isStartTile) : base(x, y, startX, startY, size)
        {
            biome = "mountain";
            display = "A";

            mountains.Add(this);

            if (isStartTile)
            {
                CheckForMountainsInRange(15);
                
                for (int i = 0; i < mountainsInRange.Count; i++)
                {
                    anglesToMountains.Add(CalculateAngles(x, y, mountainsInRange[i].x, mountainsInRange[i].y));
                }

                ConnectMountains(startX, startY);
            }

            else
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
        
        public void ConnectMountains(int startX, int startY)
        {
            //int x, int y, int startX, int startY, int size

            for (int i = 0; i < anglesToMountains.Count; i++)
            {
                if (anglesToMountains[i] < 0)
                {
                    anglesToMountains[i] += 360;
                }

                if (anglesToMountains[i] > 22 && anglesToMountains[i] <= 67)
                {
                    
                    mountains.Add(new Mountain(x + 1, y - 1, startX, startY, 0, true));
                }
                else if (anglesToMountains[i] > 67 && anglesToMountains[i] <= 112)
                {
                    mountains.Add(new Mountain(x + 1, y, startX, startY, 0, true));
                }
                else if (anglesToMountains[i] > 112 && anglesToMountains[i] <= 157)
                {
                    mountains.Add(new Mountain(x + 1, y + 1, startX, startY, 0, true));
                }
                else if (anglesToMountains[i] > 157 && anglesToMountains[i] <= 202)
                {
                    mountains.Add(new Mountain(x, y + 1, startX, startY, 0, true));
                }
                else if (anglesToMountains[i] > 202 && anglesToMountains[i] <= 247)
                {
                    mountains.Add(new Mountain(x - 1, y + 1, startX, startY, 0, true));
                }
                else if (anglesToMountains[i] > 247 && anglesToMountains[i] <= 292)
                {
                    mountains.Add(new Mountain(x - 1, y, startX, startY, 0, true));
                }
                else if (anglesToMountains[i] > 292 && anglesToMountains[i] <= 337)
                {
                    mountains.Add(new Mountain(x - 1, y - 1, startX, startY, 0, true));
                }
                else if ((anglesToMountains[i] > 337 && anglesToMountains[i] <= 360) || (anglesToMountains[i] > 0 && anglesToMountains[i] <= 22))
                {
                    mountains.Add(new Mountain(x, y - 1, startX, startY, 0, true));
                }
            }
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
                
                double[] anglesToMountains = new double[mountainsInRange.Count];

                for (int i = 0; i < anglesToMountains.Length; i++)
                {
                    anglesToMountains[i] = CalculateAngles(startX, startY, mountainsInRange[i].x, mountainsInRange[i].y);
                }

                double angleToStartTile = CalculateAngles(startX, startY, x, y);

                if (anglesToMountains.Contains(angleToStartTile))
                {
                    //newTile = new Mountain(x, y, startX, startY, size, false);
                }

                else if (Tile.random.Next(size) / (Math.Sqrt(xDif * xDif + yDif * yDif)) > Math.Sqrt(xDif * xDif + yDif * yDif))
                {

                    //newTile = new Mountain(x, y, startX, startY, size, false);
                    //this.printTile(0, 0);
                }
            }

            newTile.noSpread = true;            
        }

        int CalculateAngles(int x1, int y1, int x2, int y2)
        {
            float xDiff = x2 - x1;
            float yDiff = y2 - y1;
            int angleDegrees = Convert.ToInt32((Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI));
            
            return angleDegrees;
        }
       
        public void CheckForMountainsInRange(int range)
        {
            for (int i = 0; i < mountains.Count; i++)
            {
                int xDif = x - mountains[i].x;
                int yDif = y - mountains[i].y;

                if (Math.Sqrt(xDif * xDif + yDif * yDif)<range)
                {
                    if (mountains[i]!=this)
                    {
                        mountainsInRange.Add(mountains[i]);
                    }
                    
                }
            }            
        }
    }
}
