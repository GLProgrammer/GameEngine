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
        private int collision;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="FPS"></param>
        /// <param name="collision">0 = No collision    1 = Collision only with borders of form     2 = Collision with borders of form & all objects</param>
        public Engine(Form form, int FPS, int collision)
        {
            this.g = form.CreateGraphics();
            targetForm = form;
            this.collision = collision;
            scene = new List<FormObject>();

            var timer = new Timer();

            timer.Interval = 1000 / FPS;


            this.timer = timer;
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
                    g.Clear(targetForm.BackColor);

                    if (obj.texture == null)
                        g.DrawRectangle(Pens.Black, obj.x, obj.y, obj.width, obj.length);
                    else
                        g.DrawImage(obj.texture, obj.x, obj.y, obj.width, obj.length);

                    obj.x += obj.dx;
                    obj.y += obj.dy;

                    if (obj.gravity)
                        obj.y += (targetForm.Width / 100) * 0;

                    #region Collision

                    if (!obj.ghost && collision > 0)
                    {
                        // Collision with borders of form
                        if (obj.x <= 0 || obj.x + obj.width * 1.6 >= targetForm.Size.Width)
                            obj.dx = -obj.dx;
                        if (obj.y <= 0 || obj.y + obj.length * 1.6 >= targetForm.Size.Height)
                            obj.dy = -obj.dy;


                        if (collision == 2)
                        {
                            // TODO: kolize s objekty
                        }
                    }

                    #endregion
                }
            }
        }
    }
}
