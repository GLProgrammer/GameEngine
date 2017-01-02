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
            eng = new Engine(this, 30, 2);
            img = Image.FromFile(@"..\..\Texture\Stone.jpg");
            rnd = new Random();
        }

        Random rnd;
        Engine eng;
        FormObject mujHezkyTestovaciObjektik;
        Image img;
        private void button1_Click(object sender, EventArgs e)
        {
            mujHezkyTestovaciObjektik = new FormObject(rnd.Next(0, ClientSize.Width), rnd.Next(10, 101), 20, 20, true, false);
            mujHezkyTestovaciObjektik.dx = rnd.Next(-3, 4);
            mujHezkyTestovaciObjektik.dy = rnd.Next(-3, 4);
            eng.Add(mujHezkyTestovaciObjektik);
            eng.Start();
            button3.Text = "| |";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            eng.RemoveAll();
            eng.Stop();
            button3.Text = "▶";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "| |")
            {
                button3.Text = "▶";
                eng.Stop();
            }
            else
            {
                button3.Text = "| |";
                eng.Start();
            }
        }
    }
}
