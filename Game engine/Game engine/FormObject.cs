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
        // dx, dy jsou zmeny x, y, ktery se meni pri kazdem vykresleni
        public float x, y, dx, dy, length, width;
        public bool active, gravity, ghost;
        public Image texture;
        public int highlight;


        /// <param name="ghost">If ghost, it is not affected by any collision</param>
        public FormObject(float x, float y, float width, float length, bool gravity, bool ghost)
        {            
            this.x = x;
            this.y = y;
            this.width = width;
            this.length = length;
            dx = 0f;
            dy = 0f;
            active = true;
            this.gravity = gravity;
            this.ghost = ghost;
            texture = null;
            highlight = 0;
        }


        
        /// <param name="ghost">If ghost, it is not affected by any collision</param>
        public FormObject(float x, float y, float width, float length, bool gravity, bool ghost, Image texture)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.length = length;
            dx = 0f;
            dy = 0f;
            active = true;
            this.gravity = gravity;
            this.ghost = ghost;
            this.texture = texture;
            highlight = 0;
        }
    }
}
