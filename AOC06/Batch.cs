using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC06
{
    internal class Batch
    {
        internal int Age { get; set; } = 8;
        internal int Size { get; set; }

        internal Batch(int size)
        {
            Size = size;
        }

        internal void Tick()
        {
            Age = (Age == 0) ? 6 : Age - 1;
        }
        
    }
}
