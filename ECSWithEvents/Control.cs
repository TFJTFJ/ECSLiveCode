using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSWithEvents
{
    public class Control
    {
        public Control(ITempSource tempSource, int threshold)
        {
            tempSource.TempChangedEvent += HandleTempChangedEvent;
            Threshold = threshold;
        }

        public event EventHandler IncreaseTempEvent;
        public event EventHandler DecreaseTempEvent;

        public int Threshold { get; set; }

        public void HandleTempChangedEvent(object source, TempChangedEventArgs args)
        {
            if(args.Temp < Threshold) OnIncreaseTempEvent();
            else OnDecreaseTempEvent();
        }

        protected virtual void OnIncreaseTempEvent()
        {
            IncreaseTempEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDecreaseTempEvent()
        {
            DecreaseTempEvent?.Invoke(this, EventArgs.Empty);
        }
    }

}
