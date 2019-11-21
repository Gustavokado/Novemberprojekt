using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeMap
{
    class MountainBetween: Mountain
    {      
        public MountainBetween(int x, int y, int startX, int startY, int size, bool isStartTile, int targetX, int targetY, int previousDistance) :base ( x,  y,  startX,  startY,  size,  isStartTile)
        {
            //tiles[x, y] = this;
            int angle = CalculateAngles(x, y, targetX, targetY);

            //int distance = stuff

            if (!(targetX == x || targetY == y))
            {
                ConnectMountain(angle, targetX, targetY, startX, startY);
            }      
        }
        
        void ConnectMountain(int angle, int targetX, int targetY, int startX, int startY)
        {
            if (angle < 0)
            {
                angle += 360;
            }

            if (angle > 22 && angle <= 67)
            {
                new MountainBetween(x + 1, y - 1, startX, startY, 0, true, targetX, targetY);
            }
            else if (angle > 67 && angle <= 112)
            {
                new MountainBetween(x + 1, y, startX, startY, 0, true, targetX, targetY);
            }
            else if (angle > 112 && angle <= 157)
            {
                new MountainBetween(x + 1, y + 1, startX, startY, 0, true, targetX, targetY);
            }
            else if (angle > 157 && angle <= 202)
            {
                new MountainBetween(x, y + 1, startX, startY, 0, true, targetX, targetY);
            }
            else if (angle > 202 && angle <= 247)
            {
                new MountainBetween(x - 1, y + 1, startX, startY, 0, true, targetX, targetY);
            }
            else if (angle > 247 && angle <= 292)
            {
                new MountainBetween(x - 1, y, startX, startY, 0, true, targetX, targetY);
            }
            else if (angle > 292 && angle <= 337)
            {
                new MountainBetween(x - 1, y - 1, startX, startY, 0, true, targetX, targetY);
            }
            else if ((angle > 337 && angle <= 360) || (angle > 0 && angle <= 22))
            {
                new MountainBetween(x, y - 1, startX, startY, 0, true, targetX, targetY);
            }
        }
    }
}
