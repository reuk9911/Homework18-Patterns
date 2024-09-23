using Homework18.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.ViewModels
{
    public class BaseVM
    {
        /// <summary>
        /// Кличка
        /// </summary>
        public string Breed { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        public BaseVM()
        {
            this.Breed = "Not Determined";
            this.Age = 0;
        }
        public BaseVM(string breed, int age)
        {
            Breed = breed;
            Age = age;
        }
    }
}
