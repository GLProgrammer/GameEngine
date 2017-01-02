using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_engine
{
    class Mouse
    {
        public Vector2 GetMousePosition()
        {
            return new Vector2((float)Cursor.Position.X, (float)Cursor.Position.Y);           
        }
        
    }
}
