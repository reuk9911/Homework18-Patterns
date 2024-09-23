using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model
{
    public class Amphibian : AbstractAnimal
    {
        private decimal length;

        public decimal Length
        {
            get { return length; }
            set
            {
                if (length != value)
                {
                    length = value;
                    RaisePropertyChangedEvent("Length");
                }
            }
        }

        public Amphibian() : base()
        {
            this._animalType = "Земноводное";
        }

        public Amphibian(string breed, int age) : base(breed, age)
        {
            this._animalType = "Земноводное";
        }
    }
}
