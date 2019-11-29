using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BiomeMap
{
    class Program
    {        
        static void Main(string[] args)
        {         
            Tile[,] tiles = Tile.tiles; //skapar en referens till den static 2D tile arrayen som finns i Tile så att man slipper skriva Tile.tiles hela tiden
            List<Mountain> mountains = new List<Mountain>();

            for (int y = 0; y < tiles.GetLength(1); y++) // fyller arrayen med en bas-tilen plains som kommer overrideas senare
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    new Plains(x,y); // alla tiles man skapar läggs automatiskt till i arrayen genom Tiles konstruktor                                     
                }
            }
            
            //----------------Forest stuff-----------------//

            int forestsAmount = Tile.random.Next(5, 70); // så att antalet skogar som skapas inte är samma varje gång

            for (int i = 0; i < forestsAmount; i++)
            {
                int x = Tile.random.Next(tiles.GetLength(0)); // genererar startkordinater och skapar skogar med de kordinatera
                int y = Tile.random.Next(tiles.GetLength(1));

                new Forest(x, y, x, y, Tile.random.Next(3, 35)); // random numret är skogens size värde som bestämmer den maximala radien skogen kan ha
            }
            
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    tiles[x, y].NoSpread = false; // en funktionalitet som beskrivs mer i forestklassen som återställs här
                }
            }

            //------------------Mountain stuff------------------//

            int mountainsAmount = Tile.random.Next(10, 35);
           
       
            for (int i = 0; i < mountainsAmount; i++)
            {
                int x = Tile.random.Next(Tile.tiles.GetLength(0));
                int y = Tile.random.Next(Tile.tiles.GetLength(1));
                
                new Mountain(x, y, x, y, 30, true,false); // den första boolen säger att det är ett startberg vilket startar processen att ansluta de till andra berg och den andra boolen säger att berget inte ska sprida sig än
            }
            
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    tiles[x, y].PrintTile(0, 0);  //skriver ut hela kartan efter att bergen har anslutits men inte spridit sig, mest för att kunna testa hur det ser ut
                }
            }

            Console.ReadLine();

            for (int i = 0; i < Mountain.mountains.Count; i++) // efter att alla anslutningar har skapats sprider alla bergen, även de emellan
            {
                Mountain.mountains[i].InitiateSpreading(Tile.random.Next(1, 8)); // förrut kördes checknearby direkt här men den lösningen med en mellan metod är dels tydligare och hjälper med inkapsling då man inte använder bergens x och y värden i program
            }


            //----------Print map-----------------//

            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    tiles[x, y].PrintTile(0, 0);
                }
            }
            
            Console.ReadLine();
        }
    }
}
