using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class Wolf : IItem
    {
        public string Name { get => "Wolf"; }
        public int Weight { get => 1; }
        public bool Check { get => true; }
    }
}
