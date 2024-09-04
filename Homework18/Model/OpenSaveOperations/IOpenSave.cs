using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model.OpenSaveOperations
{
    public interface IOpenSave
    {
        void SaveAnimals(IEnumerable<IAnimal> animals, string path);
        IEnumerable<IAnimal> GetAnimals(string path);
    }
}
