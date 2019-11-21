using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeMap
{
    class MountainStart: Mountain
    {
        List<Mountain> mountainsInRange = new List<Mountain>();

        List<int> anglesToMountains = new List<int>();

        public MountainStart(int x, int y, int startX, int startY, int size, bool isStartTile) : base(x, y, startX, startY, size, isStartTile)
        {
            CheckForMountainsInRange(15);

            for (int i = 0; i < mountainsInRange.Count; i++)
            {
                anglesToMountains.Add(CalculateAngles(x, y, mountainsInRange[i].x, mountainsInRange[i].y));

                new MountainBetween(x, y, startX, startY, size, isStartTile, mountainsInRange[i].x, mountainsInRange[i].y);
            }           
        }

        void CheckForMountainsInRange(int range)
        {
            for (int i = 0; i < mountains.Count; i++)
            {
                int xDif = x - mountains[i].x;
                int yDif = y - mountains[i].y;

                if (Math.Sqrt(xDif * xDif + yDif * yDif) < range)
                {
                    if (mountains[i] != this)
                    {
                        mountainsInRange.Add(mountains[i]);
                    }
                }
            }
        }
    }
}
