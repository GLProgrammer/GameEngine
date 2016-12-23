using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_engine
{
    class Engine
    {
        private Form targetForm;
        private Timer timer;
        private List<FormObject> scene;

        public Engine(Form form, int FPS)
        {
            targetForm = form;
            scene = new List<FormObject>();

            var timer = new Timer();

            timer.Interval = 1000 / FPS;


            this.timer = timer;
            //form.Controls.Add(timer);

            // TODO: Udelat metody Start(), Pause(), co startujou/pauzujou timer, udelat nejakou kolekci
            //       objektu, ktera by se updatovala po kazdym ticku timeru

            // TODO: Pridat delegata na timer, kde bysme obslouzili vsechny objekty
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
                #region Draw current object
                FormObject obj = scene[i];

                
                #endregion
            }
        }
    }
}
