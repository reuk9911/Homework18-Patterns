using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.CodeDom;

namespace Homework18.Model
{
    public class AnimalFactory
    {
        public static IAnimal GetAnimal(string animalType, string breed, DateTime birthday) 
        {
            Type myType = Type.GetType(animalType, false, true);
            if (myType == null)
                return new NullAnimal();
            
            bool inheritsIAnimal = myType.GetInterfaces().Contains(typeof(IAnimal));
            
            if (inheritsIAnimal == false)
                return new NullAnimal();
            


            ConstructorInfo ctor = myType.GetConstructor(new[] { typeof(string), typeof(DateTime) });
            object newAnimal = ctor.Invoke(new object[] { breed, birthday });

            return (IAnimal)newAnimal;

        }

    }
}
