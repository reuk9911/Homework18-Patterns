using Homework18.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model
{
    public abstract class AbstractAnimal : IAnimal, INotifyPropertyChanged
    {

        # region свойства

        protected string _animalType;

        

        public string AnimalType { get => _animalType; }

        private string breed;

        public string Breed
        {
            get { return breed; }
            set 
            {
                if (breed != value)
                {
                    breed = value;
                    RaisePropertyChangedEvent("Breed");
                }
            }
        }


        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (age != value)
                {
                    age = value;
                    RaisePropertyChangedEvent("Age");
                }
            }
        }

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


        #region События

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }


}
