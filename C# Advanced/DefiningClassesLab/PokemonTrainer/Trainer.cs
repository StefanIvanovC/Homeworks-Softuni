using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.name = name;
            this.numberOfBadges = 0;
            this.pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public int NumberOfBadges
        {
            get
            {
                return this.numberOfBadges;
            }
        }
        public List<Pokemon> Pokemons
        {
            get
            {
                return this.pokemons;
            }
        }
        public void IncreaceNumberOfBadges()
        {
            this.numberOfBadges++;
        }
    }
}