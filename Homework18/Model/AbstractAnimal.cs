using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model
{
    public abstract class AbstractAnimal : IAnimal
    {

        #region

        protected string _animalType;

        #endregion

        #region свойства
        public string AnimalType { get => _animalType; }

        public string Breed { get; set; }

        public DateTime Birthday { get; set; }

        public string Age
        {
            get
            {
                if (Birthday == DateTime.MinValue)
                    return "Not Determined";
                else
                    return (DateTime.Now.Year - Birthday.Year).ToString();
            }
        }

        #endregion

        #region Конструкторы

        public AbstractAnimal()
        {
            this._animalType = "Not Determined";
            this.Birthday = DateTime.MinValue;
            this.Breed = "Not Determined";
        }

        public AbstractAnimal(string breed, DateTime birthday)
        {
            this.Breed = breed;
            this.Birthday = birthday;
        }

        #endregion
    }

}
