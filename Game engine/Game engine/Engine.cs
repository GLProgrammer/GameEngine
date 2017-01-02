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
        private bool highlightOnClick;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="FPS"></param>
        /// <param name="collision">0 = No collision    1 = Collision only with borders of form     2 = Collision with borders of form & all objects</param>
        /// <param name="highlightOnClick">Should I highlight objects when you click them?</param>
        public Engine(Form form, int FPS, int collision, bool highlightOnClick)
        {
            this.g = form.CreateGraphics();
            targetForm = form;
            this.collision = collision;
            scene = new List<FormObject>();

            var timer = new Timer();

            timer.Interval = 1000 / FPS;


            this.timer = timer;
            timer.Tick += new EventHandler(MyTimer_Tick);

            this.highlightOnClick = highlightOnClick;
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            Draw();
        }




        public void Start() { timer.Start(); }
        public void Stop() { timer.Stop(); }
        public void Add(FormObject obj) { scene.Add(obj); }
        public void Add(FormObject[] obj) { scene.AddRange(obj); }
        public void Remove(FormObject obj) { scene.Remove(obj); }
        public void Remove(FormObject[] obj) { foreach (FormObject o in obj) Remove(o); }
        public void RemoveAll() { scene.Clear(); g.Clear(targetForm.BackColor); }
        private void Draw()
        {
            g.Clear(targetForm.BackColor);

            // Nepouzivat foreach, jinak by se cyklus po pridani prvku castecne opakoval
            int max = scene.Count;
            for (int i = 0; i < max; i++)
            {
                FormObject obj = scene[i];
                if (obj.active)
                {



                    if (highlightOnClick && obj.highlight > 100)
                    {
                        Brush b = new SolidBrush(Color.FromArgb(obj.highlight, 0, 0, 255));
                        obj.highlight -= 5;
                        g.FillRectangle(b, obj.x, obj.y, obj.width, obj.length);
                    }
                    else
                    {
                        if (obj.texture == null)
                            g.DrawRectangle(Pens.Black, obj.x, obj.y, obj.width, obj.length);
                        else
                            g.DrawImage(obj.texture, obj.x, obj.y, obj.width, obj.length);
                    }

                    obj.x += obj.dx;
                    obj.y += obj.dy;

                    if (obj.gravity)
                        obj.dy += 0.5f;

                    #region Collision

                    if (!obj.ghost && collision > 0)
                    {
                        // Collision with borders of form
                        if (obj.x < 0 || obj.x + obj.width > targetForm.ClientSize.Width)
                        {
                            obj.dx = -(obj.dx / 100 * 90);

                            if (obj.x < 0)
                                obj.x = 0;

                            if (obj.x + obj.width > targetForm.ClientSize.Width)
                                obj.x = targetForm.ClientSize.Width - obj.width;
                        }

                        if (obj.y < 0 || obj.y + obj.length > targetForm.Size.Height)
                        {
                            obj.dy = -(obj.dy / 100 * 90);

                            if (obj.y < 0)
                                obj.y = 0;

                            if (obj.y + obj.length > targetForm.ClientSize.Height)
                                obj.y = targetForm.ClientSize.Height - obj.length;
                        }

                        if (collision == 2)
                        {
                            // Vyber vsechny objekty ze sceny, ktere se protinaji
                            var cols = (from x in scene where obj.x >= x.x && obj.x <= x.x + x.width && obj.y >= x.y && obj.y <= x.y + x.length select x).ToArray();

                            for (int j = 0; j < cols.Count(); j++)
                            {
                                if (cols[j] == obj)
                                    continue;

                                obj.dx = -(obj.dx / 100 * 90);
                                obj.dy = -(obj.dy / 100 * 90);

                                cols[j].dx = -(cols[j].dx / 100 * 90);
                                cols[j].dy = -(cols[j].dy / 100 * 90);

                                obj.x += obj.dx;
                                obj.y += obj.dy;

                                cols[j].x += cols[j].dx;
                                cols[j].y += cols[j].dy;
                            }
                        }
                    }

                    #endregion
                }
            }
        }
        public void MouseClick(MouseEventArgs e)
        {
            if (highlightOnClick)
            {
                var cols = (from x in scene where (e.X >= x.x && e.X <= x.x + x.width) && (e.Y >= x.y && e.Y <= x.y + x.length) select x).ToArray();

                for (int i = 0; i < cols.Count(); i++)
                {
                    cols[i].highlight = 255;
                }
            }
        }
    }
}
