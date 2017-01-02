using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_engine
{
    class Vector2
    {
        private int x, y;
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public Vector2 GetZero()
        {
            return new Vector2(0, 0);
        }
        public void SetX(int x)
        {
            this.x =x;
        }
        public void SetY(int y)
        {
            this.y = y;
        }
        public void SetVector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
