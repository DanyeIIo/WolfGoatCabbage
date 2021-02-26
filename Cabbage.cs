using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class Cabbage : IItem
    {
        public string Name { get => "Cabbage"; }
        public int Weight { get => 3; }
        public bool Check { get => true; }
    }
}
