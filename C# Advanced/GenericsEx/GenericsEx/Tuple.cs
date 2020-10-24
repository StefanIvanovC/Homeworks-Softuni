using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsEx
{
    public class Tuple<Tfirst, Tsecond>
    {
        public Tuple(Tfirst firstItem, Tsecond secondItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
        }

        public Tfirst FirstItem { get; set; }

        public Tsecond SecondItem { get; set; }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}";
        }
    }
}
