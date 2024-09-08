using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model
{
    public class Bird : AbstractAnimal
    {
        public decimal WingSpan { get; set; }

        public Bird() : base()
        {
            this._animalType = "Птица";
        }

        public Bird(string breed, DateTime birthday) : base(breed, birthday)
        {
            this._animalType = "Птица";
        }
    }
}
