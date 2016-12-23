using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Game_engine
{
    class FormObject
    {
        // dx, dy jsou zmeny dx, dy, ktery se meni pri kazdem vykresleni
        public int x, y, dx, dy;
        public bool active;
        public Image texture;

        public FormObject(int x, int y)
        {            
            this.x = x;
            this.y = y;
            dx = 0;
            dy = 0;
            active = true;
            texture = null;
        }


        public FormObject(int x, int y, Image texture)
        {
            this.x = x;
            this.y = y;
            dx = 0;
            dy = 0;
            active = true;
            this.texture = texture;
        }
    }
}
