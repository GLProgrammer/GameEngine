using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_engine
{
    class Vector3 : Vector2
    {
        private float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float GetZ() { return z; }

        public Vector3 GetZero3()
        {
            return new Vector3(0, 0, 0);
        }

        public void SetZ(float z)
        {
            this.z = z;
        }


        public void SetVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
