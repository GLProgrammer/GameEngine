using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_engine
{
    class FormObject
    {
        // dx, dy jsou zmeny dx, dy, ktery se meni pri kazdem vykresleni
        public int x, y, dx, dy;
        public bool active;

        public FormObject(int x, int y)
        {
            this.x = x;
            this.y = y;
            active = true;
        }
    }
}
