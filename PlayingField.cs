using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class PlayingField
    {
        public void Play()
        {
            List<IItem> left = new List<IItem> { new Wolf(), new Goat(), new Cabbage() };
            List<IItem> right = new List<IItem>();
            IItem movePos1 = null;
            IItem movePos2 = null;
            int choose = 0;
            while (left.Count > 0)
            {
                Console.Clear();
                movePos1 = null;
                while (movePos1==null)
                {
                    Console.WriteLine("whom will we choose to finish bridge?");
                    left.ForEach(OutputName);
                    int.TryParse(Console.ReadLine(), out choose);
                    if (GetItem(ref left, ref movePos1, choose))
                    {
                        if (left.Count.Equals(0))
                        {
                            Console.WriteLine("Congratulations! You won!");
                            return;
                        }
                        if (Check(movePos2, left))
                        {
                            right.Add(movePos1);
                        }
                        else
                        {
                            Console.WriteLine("You lost... Try again better!");
                            return;
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("1: go back alone");
                Console.WriteLine("2: go back with item");
                choose = 0;
                while (choose < 1 || choose > 2)
                {
                    int.TryParse(Console.ReadLine(), out choose);
                    movePos2 = null;
                    if (choose == 1)
                    {
                        if (Check(movePos1, right))
                        {
                            choose = 0;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You lost... Try again better!");
                            return;
                        }
                    }
                    else if (choose == 2)
                    {
                        while (movePos2 == null)
                        {
                            Console.WriteLine("whom will we choose to back bridge?");
                            right.ForEach(OutputName);
                            int.TryParse(Console.ReadLine(), out choose);
                            if (GetItem(ref right, ref movePos2, choose))
                            {
                                if (Check(movePos1, right))
                                {
                                    left.Add(movePos2);
                                    
                                }
                                else
                                {
                                    Console.WriteLine("You lost... Try again better!");
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    Console.WriteLine("Enter to continue");
                    Console.ReadKey();
                }
            }
        }
        private bool GetItem(ref List<IItem> items,ref IItem move, int choose) 
        {
            foreach (var item in items)
            {
                if (item.Weight.Equals(choose))
                {
                    move = item;
                    items.Remove(item);
                    return true;
                }
            }
            Console.WriteLine("Invalid chose!");
            Console.WriteLine("Enter to continue");
            Console.ReadKey();
            return false;
        }
        private bool Check(IItem item, in List<IItem> items)
        {
            if(item == null)
            {
                return true;
            }
            //1 wolf = true | 2 goat = false | 3 cabbage = true 
            foreach (var it in items)
            {
                if(!it.Check.Equals(item.Check))
                {
                    return false;
                }
            }
            return true;
        }
        private void OutputName(IItem item)
        {
            Console.WriteLine($"{item.Weight}: {item.Name}");
        }
    }
}
