using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model
{
    public class Mammal: AbstractAnimal
    {
        private decimal coatLength;

        public decimal CoatLength
        {
            get { return coatLength; }
            set
            {
                if (coatLength != value)
                {
                    coatLength = value;
                    RaisePropertyChangedEvent("CoatLength");
                }
            }
        }

        public Mammal() : base()
        {
            this._animalType = "Млекопитающее";
        }

        public Mammal(string breed, int age) : base(breed, age)
        {
            this._animalType = "Млекопитающее";
        }

    }
}
