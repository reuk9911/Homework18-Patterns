using Homework18.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model
{
    public class Bird : AbstractAnimal
    {
        private decimal wingSpan;

        public decimal WingSpan
        {
            get { return wingSpan; }
            set
            {
                if (wingSpan != value)
                {
                    wingSpan = value;
                    RaisePropertyChangedEvent("WingSpan");
                }
            }
        }

        public Bird() : base()
        {
            this._animalType = "Птица";
        }

        public Bird(string breed, int age) : base(breed, age)
        {
            this._animalType = "Птица";
        }
    }
}
