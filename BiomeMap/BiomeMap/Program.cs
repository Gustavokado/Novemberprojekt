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

            Tile[,] tiles = Tile.tiles;

            for (int y = 0; y < Tile.tiles.GetLength(1); y++)
            {
                for (int x = 0; x < Tile.tiles.GetLength(0); x++)
                {
                    tiles[x,y] = new Plains(x,y);                                      
                }
            }
            
          //----------------Forest stuff-----------------//

            int forests = Tile.random.Next(5, 70);

            for (int i = 0; i < forests; i++)
            {
                int x = Tile.random.Next(Tile.tiles.GetLength(0));
                int y = Tile.random.Next(Tile.tiles.GetLength(1));

                tiles[x, y] = new Forest(x, y, x, y, Tile.random.Next(3, 35));
            }
            

            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    tiles[x, y].noSpread = false;
                }
            }




            //------------------Mountain stuff------------------//


            int mountainsAmount = Tile.random.Next(10, 35);

            List<MountainStart> startMountains = new List<MountainStart>();
        
            for (int i = 0; i < mountainsAmount; i++)
            {
                int x = Tile.random.Next(Tile.tiles.GetLength(0));
                int y = Tile.random.Next(Tile.tiles.GetLength(1));



                new Mountain(x, y, x, y, Tile.random.Next(5, 30), true);
                //Tile.tiles[x, y].isStartTile = true;

                Mountain.mountains.Add (new Mountain(x, y, x, y, Tile.random.Next(5, 30),true));
                Tile.tiles[x, y].isStartTile = true;               


                new MountainStart(x, y, x, y, 0,true);                              


                //startMountains.Add(new MountainStart(x, y, x, y, 0,true));   
                new Mountain(x, y, x, y, 30, true,false);
            }
            

            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    tiles[x, y].PrintTile(0, 0);  
                }
            }


            Console.ReadLine();

            for (int i = 0; i < Mountain.mountains.Count; i++)
            {
                Mountain.mountains[i].CheckNearby(Mountain.mountains[i].x, Mountain.mountains[i].y, Tile.random.Next(15, 50));
            }


            //----------Print map-----------------//

            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    tiles[x, y].PrintTile(0, 0);


                    // Thread.Sleep(5);
                }
            }
            Console.CursorTop = 1;
            Console.WriteLine(Tile.amount);

            
/*
            for (int i = 0; i < Tile.tiles.Count; i++)
            {
                Tile.tiles[i].printTile(0, 0);
                Thread.Sleep(5);
            }
            Console.CursorTop = 1;
            Console.WriteLine(Tile.tiles.Count);
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    tiles.Add(new Tile(x, y));
                }
            }
            int posX = 0;
            int posY = 0;
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < tiles.Count; i++)
                {
                    
                    tiles[i].printTile(posX,posY);
                    /*Console.WriteLine(tiles[i].x );
                    Console.WriteLine(tiles[i].y + "\n");
                    //Thread.Sleep(10);
                }
                //Console.WriteLine(tiles.Count);
                Console.WriteLine();
                posX = int.Parse(Console.ReadLine());
                posY = int.Parse(Console.ReadLine());
            }


    */






            Console.ReadLine();
        }
    }
}
