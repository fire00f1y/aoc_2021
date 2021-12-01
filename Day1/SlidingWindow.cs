using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    public class SlidingWindow
    {
        private readonly List<int> _window;
        private int _cursor = 0;
        private readonly int _max;
        private bool _full = false;

        public SlidingWindow(int size)
        {
            _window = new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                _window.Add(0);
            }
            _max = size;
        }

        public void Add(int num)
        {
            _window[_cursor] = num;
            _cursor++;
            if (_cursor < _max) return;
            _full = true;
            _cursor = 0;
        }

        public bool Ready()
        {
            return _full;
        }

        public int Sum()
        {
            return _window.AsQueryable().Sum();
        }
    }
}