using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_engine
{
    class Vector3
    {
        private float x, y, z;

        public Vector3() { }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float GetX() { return x; }
        public float GetY() { return y; }
        public float GetZ() { return z; }
        public Vector3 GetZero3() { return new Vector3(0, 0, 0); }

        public void SetX(float x) { this.x = x; }
        public void SetY(float y) { this.y = y; }
        public void SetZ(float z) { this.z = z; }
        public void SetVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
