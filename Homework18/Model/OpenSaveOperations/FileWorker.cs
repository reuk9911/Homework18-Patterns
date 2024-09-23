using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework18.Model.OpenSaveOperations
{
    public class FileWorker
    {
        /// <summary>
        /// Метод сохранения/открытия
        /// </summary>
        public IOpenSave Mode { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Method">Метод сохранения/открытия</param>
        public FileWorker(IOpenSave Method)
        {
            this.Mode = Method;
        }

        /// <summary>
        /// Сохраняет животных в файл
        /// </summary>
        /// <param name="animals">Коллекция животных</param>
        /// <param name="path">Путь</param>
        public void Save(IEnumerable<IAnimal> animals, string fileName)
        {
            Mode.SaveAnimals(animals, fileName);
        }
        /// <summary>
        /// Загружает животных в коллекцию из файла
        /// </summary>
        /// <param name="path">Путь</param>
        /// <returns>Коллекция животных</returns>
        public IEnumerable<IAnimal> Load(string fileName)
        {
            return Mode.GetAnimals(fileName);
        }
    }
}
