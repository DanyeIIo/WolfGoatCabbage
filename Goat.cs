using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class Goat : IItem
    {
        public string Name { get => "Goat"; }
        public int Weight { get => 2; }
        public bool Check { get => false; }
    }
}
