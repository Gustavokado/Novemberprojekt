using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeMap
{
    class Mountain: Tile
    {
        public static List<Mountain> mountains = new List<Mountain>(); // en konstant lista med alla berg behövs i main 

        public Mountain(int x, int y, int startX, int startY, int size, bool isStartTile, bool spread) : base(x,y,isStartTile) 
        {
            biome = "mountain";
            printColor = ConsoleColor.Gray;
           
            if (isStartTile) // om ett berg är ett av de första ska det kolla efter andra startberg och koppla ihop de
            {               
                CheckForMountainsInRange(25); // 25 är rangen
            }
                       
            if(spread) // bergen ska bara sprida sig när de inte är startberg eller berg som försöker kopplas ihop         
            {
                CheckNearby(startX, startY, size);
            }
            else // om de inte ska sprida sig, dvs är start/anslutande läggs de automatiskt till i berglistan, om de las till oavsätt skapas in oändlig loop ii main där en forloop går igenom berglistan och kör checknearby
            {
                mountains.Add(this);
            }
        }

        public override void Spread(int x, int y, int startX, int startY, int size) // samma som för forest förutom att nospread är borta för att bergen skulle få en mer kompakt känsla
        {
            x = Math.Min(Math.Abs(x), tiles.GetLength(0) - 1);
            y = Math.Min(Math.Abs(y), tiles.GetLength(1) - 1);

            Tile newTile = tiles[x, y];

            if (newTile.GetBiomeType() != "mountain")
            {
                int xDif = startX - x;
                int yDif = startY - y;

                if (random.Next(size)> Math.Sqrt(xDif * xDif + yDif * yDif))
                {
                    newTile=new Mountain(x, y, startX, startY, size, false, true);                    
                }
            }           
        }
       
        public void CheckForMountainsInRange(int range) // går igenom alla berg och kopplar ihop de om de är tillräckligt nära
        {
            for (int i = 0; i < mountains.Count; i++)
            {
                int xDif = x - mountains[i].x;
                int yDif = y - mountains[i].y;

                if (Math.Sqrt(xDif * xDif + yDif * yDif) < range) // räknar distans
                {
                    if (mountains[i] != this && mountains[i].isStartTile)
                    {
                        ConnectMountains(mountains[i].x, mountains[i].y); // passar in positionen för det hittade berget
                    }
                }
            }
        }
       
        public void ConnectMountains(int targetX, int targetY) // simulerar en formel för en graf utifrån två punkter, skapar sedan ett berg i alla posiitioner i arrayen som grafen överlappar
        {
            for (float t = 0; t <= 1; t+=0.01f) // formeln utgår från ett värde t som går ett oändligt antal steg mellan 0 och 1, här är det hundra steg viilkket innebär att den kollar hundra positioner mellan de två bergen vilket är mer än tillräckligt
            {
                int xPos = Convert.ToInt32(targetX - (targetX * t - x * t)); // fancy matte som ger positionen på grafen utifrån de två punkterna(bergen)
                int yPos = Convert.ToInt32(targetY - (targetY * t - y * t));

                if (tiles[xPos ,yPos].GetBiomeType()!="Mountain") // ifall den positionen på grafen inte redan har ett berg skapas ett nytt
                {
                    tiles[xPos, yPos] = new Mountain(xPos,yPos,0,0,0,false,false); // båda boolsen är false vilket gör att de här bergen inte gör något när de skapas
                }
            }           
        }

        public void InitiateSpreading(int size) // gör koden i main tydligare när bergen ska sprida sig
        {
            CheckNearby(x, y, size);
        }
    }
}
