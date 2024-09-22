using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model
{
    public abstract class AbstractAnimal : IAnimal
    {

        # region свойства

        protected string _animalType;

        public string AnimalType { get => _animalType; }

        public string Breed { get; set; }

        public int Age { get; set; }

        #endregion

        #region Конструкторы

        public AbstractAnimal()
        {
            this._animalType = "Not Determined";
            this.Age = 0;
            this.Breed = "Not Determined";
        }

        public AbstractAnimal(string breed, int age)
        {
            this.Breed = breed;
            this.Age = age;
        }

        #endregion
    }

}
