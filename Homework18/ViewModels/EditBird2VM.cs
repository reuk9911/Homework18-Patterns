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
    public class EditBird2VM : BaseVM
    {
        /// <summary>
        /// Размах крыльев
        /// </summary>
        public decimal WingSpan { get; set; }

        /// <summary>
        /// Животное,которое будет редактироваться
        /// </summary>
        public Bird Bird { get; set; }

        public EditBird2VM() : base()
        {
        }

        public EditBird2VM(Bird newBird)
        {
            this.Bird = newBird;
            this.Breed = newBird.Breed;
            this.Age = newBird.Age;
            this.WingSpan = newBird.WingSpan;
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ?? new RelayCommand(obj =>
                {
                    this.Bird.Breed = this.Breed;
                    this.Bird.Age = this.Age;
                    this.Bird.WingSpan = this.WingSpan;
                    ((Window)obj).Close();

                });
            }
        }
    }
}
