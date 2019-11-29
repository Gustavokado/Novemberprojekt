using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeMap
{
    class Tile
    {
        protected int x; // en tiles position i 2D arrayen, protected för att subklasserna använder det
        protected int y;
        protected bool isStartTile; // säger ifall tilen är en starttile (duh), används dock sällan
        protected string biome;
        public static Random random = new Random(); // är public och static så att man bara behöver ha en random generator i programmet då det används ganska ofta
        public static Tile[,] tiles = new Tile[140, 80]; // den arrayen som alla tiles alltid är i och interagerar med, är statiic för att ändringar i den nånstans ska ske överallt       
        private bool noSpread = false; // funktionalitet som beskrivs mer i forest klassen
        protected ConsoleColor printColor; // färgen som en tile ska skrivas ut i, bestäms i supklassernas konstruktor

        public Tile(int xPos, int yPos, bool start)
        {
            isStartTile = start;

            x = (xPos < 0) ? 0 : ((xPos > tiles.GetLength(0)-1) ? tiles.GetLength(0)-1 : xPos);  //dubbelkollar att positionen för den nya tilen finns i arrayen         
            y = (yPos < 0) ? 0 : ((yPos > tiles.GetLength(1)-1) ? tiles.GetLength(1)-1 : yPos);
            
            tiles[x, y] = this; // sätter den nya tilen till rätt plats så man inte behöver göra det när man skapar en tile
        }

        public void CheckNearby(int startX, int startY, int size)
        {
            for (int i = y - 1; i <= y + 1; i++) // går igenom alla positioner runt den tile som ska spridas, den här metoden är samma för alla olika tiles
            {
                for (int u = x - 1; u <= x + 1; u++)
                {
                    Spread(u, i, startX, startY, size); // kör spreadmetoden för den specifika typen av tile                  
                }
            }
        }

        public void PrintTile(int topPosX, int topPosY) // skriver ut den tilen, parametrarna används inte för tillfället, de var tänka att användas när man kan gå runt i världen och kartan ska flyttas
        {
            Console.ForegroundColor = printColor; // varje typ av tile har sin egen färg
            Console.CursorLeft = (x * 2) + topPosX * 2;
            Console.CursorTop = y + topPosY;
            Console.Write("██");
        }

        public virtual void Spread(int x, int y, int startX, int startY, int size) // spreadmetoden är virtual så att alla olika tiles kan ha sin egen version och sprida på olika sätt
        {
        }  
        
        public string GetBiomeType() // inkapsling av biome variabeln
        {
            return biome;
        }
        
        public bool NoSpread // noSpread behöver kunna ändras så jag valde att använda en property 
        {
            get
            {
                return noSpread;
            }
            set
            {
                noSpread = value;
            }
        }
    }
}
