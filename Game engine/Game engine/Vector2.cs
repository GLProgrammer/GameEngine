using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_engine
{
    class Vector2
    {
        private float x, y;

        public Vector2() { }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float GetX() { return x; }
        public float GetY() { return y; }
        public Vector2 GetZero2() { return new Vector2(0, 0); }

        public void SetX(float x) { this.x = x; }
        public void SetY(float y) { this.y = y; }
        public void SetVector2(float x, float y)
        {
            this.x = x; this.y = y;
        }
    }
}
