using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeMap
{
    class MountainBetween: Mountain
    {      
        public MountainBetween(int x, int y, int startX, int startY, int size, bool isStartTile, int targetX, int targetY, double previousDistance) :base ( x,  y,  startX,  startY,  size,  isStartTile,false)
        {
            
            int angle = CalculateAngles(x, y, targetX, targetY);

            int xDif = x - targetX;
            int yDif = y -targetY;

            double distance = Math.Sqrt(xDif * xDif + yDif * yDif);

            if (distance<=previousDistance)
            {
                ContinueMountains(angle, targetX, targetY, startX, startY, distance);
            }      
        }
        
        void ContinueMountains(int angle, int targetX, int targetY, int startX, int startY, double distance)
        {
            if (angle < 0)
            {
                angle += 360;
            }

            if (angle > 22 && angle <= 67)
            {
                new MountainBetween(x + 1, y - 1, startX, startY, 0, true, targetX, targetY, distance);
            }
            else if (angle > 67 && angle <= 112)
            {
                new MountainBetween(x + 1, y, startX, startY, 0, true, targetX, targetY, distance);
            }
            else if (angle > 112 && angle <= 157)
            {
                new MountainBetween(x + 1, y + 1, startX, startY, 0, true, targetX, targetY, distance);
            }
            else if (angle > 157 && angle <= 202)
            {
                new MountainBetween(x, y + 1, startX, startY, 0, true, targetX, targetY, distance);
            }
            else if (angle > 202 && angle <= 247)
            {
                new MountainBetween(x - 1, y + 1, startX, startY, 0, true, targetX, targetY, distance);
            }
            else if (angle > 247 && angle <= 292)
            {
                new MountainBetween(x - 1, y, startX, startY, 0, true, targetX, targetY, distance);
            }
            else if (angle > 292 && angle <= 337)
            {
                new MountainBetween(x - 1, y - 1, startX, startY, 0, true, targetX, targetY, distance);
            }
            else if ((angle > 337 && angle <= 360) || (angle > 0 && angle <= 22))
            {
                new MountainBetween(x, y - 1, startX, startY, 0, true, targetX, targetY, distance);
            }
        }
    }
}
