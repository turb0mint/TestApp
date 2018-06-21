using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestApp
{
    
    enum STATE { NotInitalised,Running,DownToProduction};
    


    class Controller
    {
        public event EventHandler<STATE> StateChangeEvent;
        private Screen S1;
        private STATE _State;
        public STATE State { get { return _State; } }

        public Controller(Screen S1)
        {
            this.S1 = S1;
                        S1.output("Controller created");
        }

        public async Task Initalize()
        {
            if (_State != STATE.Running)
            {
              await Task.Run( () =>  Thread.Sleep(5000));
                _State = STATE.Running;
                StateChangeEvent?.Invoke(this, STATE.Running);
            } else
            {
               // S1.output("Controller is already Running");
            }
        }
        public void ShutDown()
        {
            _State = STATE.DownToProduction;
             S1.output("Controller DownToProduction");
        }

        








    }
}
