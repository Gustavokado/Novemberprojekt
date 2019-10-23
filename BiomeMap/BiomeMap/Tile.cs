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
        bool isStartTile;
        protected string display;
        public string biome;
        public static Random random = new Random();
        //public static List<Tile> tiles = new List<Tile> { };
        public static Tile[,] tiles = new Tile[60, 60];
        public static int amount = 0;

        public Tile(int xPos, int yPos, int startX, int startY, int size)
        {
            x = xPos;
            y = yPos;
            tiles[x, y] = this;
            this.spread(startX,  startY, size, random.Next(0,size/2));
        }

        public virtual void printTile(int topPosX, int topPosY)
        {
            Console.CursorLeft = (x*2)+topPosX*2;
            Console.CursorTop = y + topPosY;
            Console.Write("T");
        }

        public virtual void spread(int startX, int startY, int size, int randomizer)
        {

        }
    }
}
