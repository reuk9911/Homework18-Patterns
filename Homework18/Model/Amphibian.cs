using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model
{
    public class Amphibian : AbstractAnimal
    {
        public decimal Length { get; set; }

        public Amphibian() : base()
        {
            this._animalType = "Земноводное";
        }

        public Amphibian(string breed, DateTime birthday) : base(breed, birthday)
        {
            this._animalType = "Земноводное";
        }
    }
}
