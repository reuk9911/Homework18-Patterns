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
        public decimal Weight { get; set; }
        public Mammal() : base()
        {
            this._animalType = "Млекопитающее";
        }

        public Mammal(string breed, DateTime birthday) : base(breed, birthday)
        {
            this._animalType = "Млекопитающее";
        }

        public void ToRun() { }
    }
}
