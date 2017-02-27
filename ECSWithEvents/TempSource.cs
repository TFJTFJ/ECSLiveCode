using System;

namespace ECSWithEvents
{
    public class TempChangedEventArgs : EventArgs
    {
        public int Temp { get; set; }
    }

    public interface ITempSource
    {
        event EventHandler<TempChangedEventArgs> TempChangedEvent;
    }
}