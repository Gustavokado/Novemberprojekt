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

            for (int y = 0; y < Tile.tiles.GetLength(1); y++)
            {
                for (int x = 0; x < Tile.tiles.GetLength(0); x++)
                {
                    new Plains(x, y, x, y, 1);                                      
                }
            }

           /* for (int y = 0; y < Tile.tiles.GetLength(1); y++)
            {
                for (int x = 0; x < Tile.tiles.GetLength(0); x++)
                {


                    Tile.tiles[x, y].printTile(0, 0);
                    // Thread.Sleep(5);
                }
            }*/

            int forests = Tile.random.Next(5, 20);
            for (int i = 0; i < forests; i++)
            {
                int x = Tile.random.Next(Tile.tiles.GetLength(0));
                int y = Tile.random.Next(Tile.tiles.GetLength(1));
                new Forest(x, y, x, y, Tile.random.Next(1, 35));
            }
            //new Forest(30, 30, 30, 30, Tile.random.Next(5,40));


           


            for (int y = 0; y < Tile.tiles.GetLength(1); y++)
            {
                for (int x = 0; x < Tile.tiles.GetLength(0); x++)
                {
                    Tile.tiles[x, y].printTile(0, 0);


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
