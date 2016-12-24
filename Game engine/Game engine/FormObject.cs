﻿using System;
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
        public int x, y, dx, dy, length, width;
        public bool active, gravity, ghost;
        public Image texture;


        /// <param name="ghost">If ghost, it is not affected by any collision</param>
        public FormObject(int x, int y, int width, int length, bool gravity, bool ghost)
        {            
            this.x = x;
            this.y = y;
            this.width = width;
            this.length = length;
            dx = 0;
            dy = 0;
            active = true;
            this.gravity = gravity;
            this.ghost = ghost;
            texture = null;
        }


        
        /// <param name="ghost">If ghost, it is not affected by any collision</param>
        public FormObject(int x, int y, int width, int length, bool gravity, bool ghost, Image texture)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.length = length;
            dx = 0;
            dy = 0;
            active = true;
            this.gravity = gravity;
            this.ghost = ghost;
            this.texture = texture;
        }
    }
}
