using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml;

using ExtendedXmlSerializer;
using ExtendedXmlSerializer.Configuration;
using ExtendedXmlSerializer.ExtensionModel.Content;
using static System.Net.Mime.MediaTypeNames;

namespace Homework18.Model.OpenSaveOperations
{
    public class XmlKeeper : IOpenSave
    {
        public IEnumerable<IAnimal> GetAnimals(string fileName)
        {

            IExtendedXmlSerializer serializer = new ConfigurationContainer().Create();
            string xml;
            using (StreamReader reader = new StreamReader(fileName, false))
            {
                xml = reader.ReadToEnd();
            }

            IEnumerable<IAnimal> deserialized = serializer.Deserialize<IEnumerable<IAnimal>>(xml); ;

            return deserialized;
        }


        public void SaveAnimals(IEnumerable<IAnimal> animals, string fileName)
        {
            var serializer = new ConfigurationContainer().Create();

            string xml = serializer.Serialize(animals);
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                writer.Write(xml);
            }
        }
    }
}
