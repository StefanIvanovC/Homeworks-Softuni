using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal DefoultCakePrice = 5m;
        private const double defaultCalories = 1000;
        private const double DefaultGrams = 250;
        public Cake(string name)
            : base(name, DefoultCakePrice, DefaultGrams, defaultCalories)
        {
        }
    }
}
