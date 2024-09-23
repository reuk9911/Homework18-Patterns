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
        /// <summary>
        /// Длина земноводного
        /// </summary>
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
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Amphibian() : base()
        {
            this._animalType = "Земноводное";
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="breed">Кличка</param>
        /// <param name="age">Возраст</param>
        public Amphibian(string breed, int age) : base(breed, age)
        {
            this._animalType = "Земноводное";
        }
    }
}
