namespace ClockClass
{
    public class Clock
    {
        Counter _seconds = new("seconds");
        Counter _minutes = new("minutes");
        Counter _hours = new("hours");

        public Clock()
        {

        }

        public void IncrementClock()
        {
            _seconds.IncrementCounter();
            if (_seconds.Tick > 59)
            {
                _seconds.ResetCounter();
                _minutes.IncrementCounter();

                if (_minutes.Tick > 59)
                {
                    _minutes.ResetCounter();
                    _hours.IncrementCounter();

                    if (_hours.Tick > 23)
                    {
                        _hours.ResetCounter();
                    }
                }
            }
        }

        public void ResetClock()
        {
            _seconds.ResetCounter();
            _minutes.ResetCounter();
            _hours.ResetCounter();
        }

        public string ReadClock()
        {
            return _hours.Tick.ToString("00") + ":" + _minutes.Tick.ToString("00") + ":" + _seconds.Tick.ToString("00");
        }
    }
}
