using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model
{
    public class NullAnimal : AbstractAnimal
    {
        public NullAnimal() : base()
        {
            this._animalType = "Not Determined";
        }
    }
}
