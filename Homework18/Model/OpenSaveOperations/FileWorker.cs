using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model.OpenSaveOperations
{
    public class FileWorker
    {
        public IOpenSave Mode { get; set; }

        public FileWorker(IOpenSave Method)
        {
            this.Mode = Method;
        }

        public void Save(IEnumerable<IAnimal> animals, string fileName)
        {
            Mode.SaveAnimals(animals, fileName);
        }

        public IEnumerable<IAnimal> Load(string fileName)
        {
            return Mode.GetAnimals(fileName);
        }
    }
}
