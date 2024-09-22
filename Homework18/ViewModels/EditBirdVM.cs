using Homework18.Model;
using Skillbox_Homework17_Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Homework18.ViewModels
{
    public class EditBirdVM : BaseVM
    {
        public decimal WingSpan { get; set; }

        private Bird bird;

        public EditBirdVM():base() 
        {
        }

        public EditBirdVM(Bird newBird)
        {
            this.bird = newBird;
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ?? new RelayCommand(obj =>
                {
                    this.bird.Breed = this.Breed;
                    this.bird.Age = this.Age;
                    this.bird.WingSpan = this.WingSpan;
                    ((Window)obj).Close();

                });
            }
        }

    }
}
