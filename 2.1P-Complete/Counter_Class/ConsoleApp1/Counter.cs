using System;

namespace CounterClass
{
    public class Counter
    {
        private string _name;
        private int _count;

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public string NameCounter
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int Tick
        {
            get
            {
                return _count;
            }
        }

        public void IncrementCounter()
        {
            _count++;
        }

        public void ResetCounter()
        {
            _count = 0;
        }
    }
}
