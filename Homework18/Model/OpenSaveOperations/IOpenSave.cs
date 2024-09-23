using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model.OpenSaveOperations
{
    public interface IOpenSave
    {
        /// <summary>
        /// Сохраняет животных в файл
        /// </summary>
        /// <param name="animals">Коллекция животных</param>
        /// <param name="path">Путь</param>
        void SaveAnimals(IEnumerable<IAnimal> animals, string path);
        /// <summary>
        /// Загружает животных в коллекцию из файла
        /// </summary>
        /// <param name="path">Путь</param>
        /// <returns>Коллекция животных</returns>
        IEnumerable<IAnimal> GetAnimals(string path);
    }
}
