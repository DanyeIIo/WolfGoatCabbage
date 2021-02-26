using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    interface IItem
    {
        string Name { get; }
        int Weight { get; }
        bool Check { get; }
    }
}
