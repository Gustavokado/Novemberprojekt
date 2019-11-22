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


        public Mountain(int x, int y, int startX, int startY, int size, bool isStartTile) : base(x, y, startX, startY, size)
        {
            biome = "mountain";
            display = "A";
            if (!isStartTile)
            {

                CheckNearby(startX, startY, size);
            }
            

                CheckForMountainsInRange(mountains, 15);
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

            if (newTile.biome != "mountain" && !newTile.noSpread)
            {
                int[] anglesToMountains = new int[mountainsInRange.Count];

                for (int i = 0; i < anglesToMountains.Length; i++)
                {
                    anglesToMountains[i] = CalculateAngles(startX, startY, mountainsInRange[i].x, mountainsInRange[i].y);
                }

                int angleToStartTile = CalculateAngles(startX, startY, x, y);

                //Thread.Sleep(5);

                Console.CursorTop = 1;
                Console.CursorLeft = 1;
                Console.WriteLine(Tile.amount);
                amount++;
                int xDif = startX - x;
                int yDif = startY - y;

                if (anglesToMountains.Contains(angleToStartTile))
                {
                    newTile = new Mountain(x, y, startX, startY, size, false);
                }

                else if (Tile.random.Next(size)/ (Math.Sqrt(xDif * xDif + yDif * yDif)) > Math.Sqrt(xDif * xDif + yDif * yDif))
                {

                    newTile = new Mountain(x, y, startX, startY, size, false);
                    //this.printTile(0, 0);
                }
                newTile.noSpread = true;
            }
        }

        int CalculateAngles(int x1, int y1, int x2, int y2)
        {
            float xDiff = x2 - x1;
            float yDiff = y2 - y1;
            double angleDegrees = (Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI);
            int angleNumber = 0;

            if (angleDegrees<0)
            {
                angleDegrees += 360;
            }

            if (angleDegrees>22.5f && angleDegrees<=67.5f)
            {
                angleNumber = 1;
            }
            else if (angleDegrees> 67.5f && angleDegrees <= 112.5f)
            {
                angleNumber = 2;
            }
            else if (angleDegrees> 112.5f && angleDegrees <=157.5f)
            {
                angleNumber = 3;
            }
            else if (angleDegrees> 157.5f && angleDegrees <= 202.5f)
            {
                angleNumber = 4;
            }
            else if (angleDegrees>202.5f && angleDegrees <= 247.5f)
            {
                angleNumber = 5;
            }
            else if (angleDegrees>247.5f && angleDegrees <= 292.5f)
            {
                angleNumber = 6;
            }
            else if (angleDegrees>292.5f && angleDegrees<=337.5f)
            {
                angleNumber = 7;
            }
            else if ((angleDegrees>337.5f && angleDegrees<=360) || (angleDegrees >0 && angleDegrees <= 22.5f))
            {
                angleNumber = 8;
            }

            return angleNumber;
        }

        public void CheckForMountainsInRange( List<Mountain> mountains, int range)
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
