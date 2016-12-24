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

        Engine eng;
        FormObject mujHezkyTestovaciObjektik;
        private void button1_Click(object sender, EventArgs e)
        {
            eng = new Engine(this, 30, 1);

            Image img = Image.FromFile(@"..\..\Texture\Stone.jpg");
            mujHezkyTestovaciObjektik = new FormObject(10, 10, 20, 50, true, false, img);
            mujHezkyTestovaciObjektik.dx = 3;
            mujHezkyTestovaciObjektik.dy = 5;
            eng.Add(mujHezkyTestovaciObjektik);
            eng.Start();
        }
    }
}
