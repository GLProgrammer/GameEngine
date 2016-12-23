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

        public Engine(Form form, int FPS)
        {
            targetForm = form;

            var timer = new Timer();

            timer.Interval = 1000 / FPS;


            this.timer = timer;
            //form.Controls.Add(timer);

            // TODO: Udelat metody Start(), Pause(), co startujou/pauzujou timer, udelat nejakou kolekci
            //       objektu, ktera by se updatovala po kazdym ticku timeru

            // TODO: Pridat delegata na timer, kde bysme obslouzili vsechny objekty
        }
    }
}
