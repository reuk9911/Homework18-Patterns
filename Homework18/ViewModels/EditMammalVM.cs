using Homework18.Model;
using Skillbox_Homework17_Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework18.ViewModels
{
    public class EditMammalVM : BaseVM
    {
        public decimal CoatLength { get; set; }

        public Mammal Mammal { get; set; }

        public EditMammalVM() : base()
        {
        }

        public EditMammalVM(Mammal newMammal)
        {
            this.Mammal = newMammal;

            this.Breed = newMammal.Breed;
            this.Age = newMammal.Age;
            this.CoatLength = newMammal.CoatLength;
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ?? new RelayCommand(obj =>
                {
                    this.Mammal.Breed = this.Breed;
                    this.Mammal.Age = this.Age;
                    this.Mammal.CoatLength = this.CoatLength;
                    ((Window)obj).Close();

                });
            }
        }
    }
}
