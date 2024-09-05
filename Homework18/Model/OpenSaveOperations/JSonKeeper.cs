using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Homework18.Model.OpenSaveOperations
{
    public class JSonKeeper : IOpenSave
    {
        public IEnumerable<IAnimal> GetAnimals(string fileName)
        {
            if (!File.Exists(fileName))
                return null;

            string json = File.ReadAllText(fileName);

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

           return JsonConvert.DeserializeObject<IEnumerable<IAnimal>>(json, serializerSettings);
        }

        public void SaveAnimals(IEnumerable<IAnimal> animals, string fileName)
        {
            
            JsonSerializerSettings serializeSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string json = JsonConvert.SerializeObject(animals, Formatting.Indented, serializeSettings);
            //File.WriteAllText(fileName, json);
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                writer.Write(json);
            }

        }
    }
}
