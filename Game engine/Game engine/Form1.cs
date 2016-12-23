using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_engine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int state = 0;
        Engine eng;
        FormObject mujHezkyTestovaciObjektik;
        private void button1_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case 0:
                    eng = new Engine(this, 10);

                    Image img = Image.FromFile(@"..\..\Texture\Stone.jpg");
                    mujHezkyTestovaciObjektik = new FormObject(10, 10, img);
                    eng.Add(mujHezkyTestovaciObjektik);
                    eng.Start();

                    state++;
                    break;

                case 1:
                    mujHezkyTestovaciObjektik.dx = 1;
                    state++;
                    break;
                case 2:
                    mujHezkyTestovaciObjektik.dx = -1;
                    state++;
                    break;
                case 3:
                    eng.Stop();
                    state = 0;
                    break;
            }
        }
    }
}
