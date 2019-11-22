using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeMap
{
    class Tile
    {
        public int x;
        public int y;
        bool isVisible;
        public bool isStartTile;
        protected string display;
        public string biome;
        public static Random random = new Random();
        //public static List<Tile> tiles = new List<Tile> { };
        public static Tile[,] tiles = new Tile[100, 50];
        public static int amount = 0;
        public bool noSpread = false;

        public Tile(int xPos, int yPos)
        {
            x = xPos;
            y = yPos;
            tiles[x, y] = this;
        }

        public void CheckNearby(int startX, int startY, int size)
        {
            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int u = x - 1; u <= x + 1; u++)
                {
                    Spread(u, i, startX, startY, size);                   
                }
            }
        }

        public virtual void PrintTile(int topPosX, int topPosY)
        {
            Console.CursorLeft = (x*2)+topPosX*2;
            Console.CursorTop = y + topPosY;
            Console.Write("T");
        }

        public virtual void Spread(int x, int y, int startX, int startY, int size)
        {

        }

        
    }
}
