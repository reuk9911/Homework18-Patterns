using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model
{
    public interface IAnimal
    {
        string AnimalType { get; }

        string Breed { get; set; }

        int Age { get; set; }
    }
}
