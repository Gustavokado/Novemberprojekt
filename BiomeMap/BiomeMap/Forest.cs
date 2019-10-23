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
        }

        public override void printTile(int topPosX, int topPosY)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.CursorLeft = (x * 2) + topPosX * 2;
            Console.CursorTop = y + topPosY;
            Console.Write("██");
        }

        public override void spread(int startX, int startY, int size, int randomizer)
        {
            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int u = x - 1; u <= x + 1; u++)
                {
                    u = Math.Min(Math.Abs(u),tiles.GetLength(0)-1);
                    i = Math.Min(Math.Abs(i), tiles.GetLength(1) - 1); 

                    if (tiles[u, i] == null)
                    {
                        //Thread.Sleep(5);
                        
                        Console.CursorTop = 1;
                        Console.CursorLeft = 1;
                        Console.WriteLine(Tile.amount);
                        int xDif = startX - u;
                        int yDif = startY - i;
                        if (Tile.random.Next(size) > Math.Sqrt(xDif * xDif + yDif * yDif))
                        {
                            
                            tiles[u, i] = new Forest(u, i, startX, startY,size);
                            

                            //this.printTile(0, 0);
                            amount++;

                        }
                        else
                        {
                            tiles[u, i] = new Plains(u, i, startX, startY, 1);
                        }
                        
                    }

                    /* bool tileFound = false;
                     for (int v = 0; v < Tile.tiles.Count; v++)
                     {
                         if (Tile.tiles[v].x == u && Tile.tiles[v].y == i)
                         {
                             tileFound = true;
                         }
                     }
                     if (!tileFound)
                     {
                         int xDif = startX - u;
                         int yDif = startY - i;


                         if (Tile.random.Next(6)> Math.Sqrt(xDif * xDif + yDif * yDif))
                         {
                             tiles.Add(new Forest(u, i, startX, startY));
                         }
                     }*/
                }
            }           
        }
    }
}
