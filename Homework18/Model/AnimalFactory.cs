using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.CodeDom;

namespace Homework18.Model
{
    public static class AnimalFactory
    {
        public static IAnimal GetNewAnimal(string animalType, string breed, int age) 
        {
            Type myType = Type.GetType(animalType, false, true);
            if (myType == null)
                return new NullAnimal();
            
            bool inheritsIAnimal = myType.GetInterfaces().Contains(typeof(IAnimal));
            
            if (inheritsIAnimal == false)
                return new NullAnimal();
            


            ConstructorInfo ctor = myType.GetConstructor(new[] { typeof(string), typeof(int) });
            object newAnimal = ctor.Invoke(new object[] { breed, age });

            return (IAnimal)newAnimal;

        }

        public static IAnimal GetNewAnimal(string animalType)
        {
            Type myType = Type.GetType(animalType, false, true);
            if (myType == null)
                return new NullAnimal();

            bool inheritsIAnimal = myType.GetInterfaces().Contains(typeof(IAnimal));

            if (inheritsIAnimal == false)
                return new NullAnimal();

            //myType.GetConstructor()

            ConstructorInfo ctor = myType.GetConstructor(new Type[] { });
            object newAnimal = ctor.Invoke(new object[] { });

            return (IAnimal)newAnimal;

        }

    }
}
