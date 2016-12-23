using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Game_engine
{
    class Engine
    {
        private Form targetForm;
        private Timer timer;
        private List<FormObject> scene;
        private Graphics g;
        public Engine(Form form, int FPS)
        {
            this.g = form.CreateGraphics();
            targetForm = form;
            scene = new List<FormObject>();

            var timer = new Timer();

            timer.Interval = 1000 / FPS;


            this.timer = timer;
            //form.Controls.Add(timer);

            // TODO: Udelat metody Start(), Pause(), co startujou/pauzujou timer, udelat nejakou kolekci
            //       objektu, ktera by se updatovala po kazdym ticku timeru

            // TODO: Pridat delegata na timer, kde bysme obslouzili vsechny objekty
            timer.Tick += new EventHandler(MyTimer_Tick);
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            Draw();
        }




        public void Start() { timer.Start(); }
        public void Stop() { timer.Stop(); }
        public void Add(FormObject obj) { scene.Add(obj); }
        public void Add(FormObject[] obj) { scene.AddRange(obj); }
        private void Draw()
        {
            // Nepouzivat foreach, jinak by se cyklus po pridani prvku castecne opakoval
            int max = scene.Count;
            for (int i = 0; i < max; i++)
            {
                FormObject obj = scene[i];
                if (obj.active)
                {
                    g.DrawRectangle(Pens.Black, obj.x, obj.y, 50, 50);
                }

                obj.x += obj.dx;
                obj.y += obj.dy;               
            }
        }
    }
}
