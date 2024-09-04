using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model.OpenSaveOperations
{
    public class XMLKeeper : IOpenSave
    {
        public IEnumerable<IAnimal> GetAnimals(string fileName)
        {
            throw new NotImplementedException();
        }

        public void SaveAnimals(IEnumerable<IAnimal> animals, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
