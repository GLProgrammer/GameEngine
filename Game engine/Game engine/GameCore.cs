using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Game_engine
{
    class GameCore
    {
        private int RecomenedFPS;
        private float RecomendedTimeOnFrame;
        private float TimeBefore;
        private float TimeAfter;
        private float RealFPS;
        public void FluidGameLoop(int recommendedFPS)
        {
            Timer timer = new Timer();
            RecomendedTimeOnFrame = 1 / RecomenedFPS;  //Čas pro 1 frame
            while (true)
            {
                TimeBefore = 0;
                timer.Start();
                GetInput();
                Update();
                Render();
                timer.Stop();
                TimeAfter = (float)(timer.Interval);
                RealFPS = 1.0f / TimeAfter;
            }
            
        }

        private void Render()
        {
            throw new NotImplementedException();
        }

        private void GetInput()
        {
            throw new NotImplementedException();
        }

        private void Update()
        {
            
        }
    }
}
