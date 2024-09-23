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
    public class EditAmphibianVM : BaseVM
    {
        /// <summary>
        /// Длина земноводного
        /// </summary>
        public decimal Length { get; set; }

        /// <summary>
        /// Животное, которое будет редактироваться
        /// </summary>
        public Amphibian Amphibian { get; set; }

        public EditAmphibianVM() : base()
        {
        }

        public EditAmphibianVM(Amphibian newAmphibian)
        {
            this.Amphibian = newAmphibian;

            this.Breed = newAmphibian.Breed;
            this.Age = newAmphibian.Age;
            this.Length = newAmphibian.Length;
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ?? new RelayCommand(obj =>
                {
                    this.Amphibian.Breed = this.Breed;
                    this.Amphibian.Age = this.Age;
                    this.Amphibian.Length = this.Length;
                    ((Window)obj).Close();

                });
            }
        }
    }
}
