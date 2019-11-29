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
        public Forest(int x, int y, int startX, int startY, int size) : base(x,y,true)
        {
            biome = "forest";
            printColor = ConsoleColor.DarkGreen;
            CheckNearby(startX, startY, size); // så fort en skog skapas går den igenom rutorna runtomkring och försöker skapa nya skogar som igen kollar runt osv. kordinaterna för den första skogen passas alltid igenom vilket är viktigt för spread metoden           
        }

        public override void Spread(int x, int y, int startX, int startY, int size)
        {
            x = Math.Min(Math.Abs(x), tiles.GetLength(0) - 1); //ser till att den nya tilen inte skapas utanför kartan
            y = Math.Min(Math.Abs(y), tiles.GetLength(1) - 1);

            Tile newTile = tiles[x, y]; // en referens till den tilen som ska overrideas

            if (newTile.GetBiomeType() != "forest" && !newTile.NoSpread) // ska bara skapa en ny skog ifall det inte redan finns en där. nospread innebär att varje tile bara testas en gång, annars skulle det finnas 8 chanser att en viss tile skapas vilket skapar väldigt lite variation i formen på skogarna
            {                
                int xDif = startX - x; 
                int yDif = startY - y;

                if (random.Next(size) > Math.Sqrt(xDif * xDif + yDif * yDif)) // med hjälp av phytagoras sats jämförs avståndet till ett random tal upp del del storleken som passades in
                {
                    new Forest(x, y, startX, startY, size); // om en ny skapas startar processen om igen
                }
                newTile.NoSpread = true; // när en tile testas blir dens nospread true så att den inte kommer att bli utbytt alls, när alla skogar är klara sätts alla nospread till true igen för att andra biomes ska kunna funka
            }                      
        }
    }
}
