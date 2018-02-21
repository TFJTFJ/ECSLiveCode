using System;

namespace ECSWithEvents
{
    public class TempChangedEventArgs : EventArgs
    {
        public int Temp { get; set; }
    }

    public interface ITempSensor
    {
        event EventHandler<TempChangedEventArgs> TempChangedEvent;
    }
}