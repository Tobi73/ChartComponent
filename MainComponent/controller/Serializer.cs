using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ChartComponent;
using Newtonsoft.Json;
using ChartComponent.model;

namespace MainComponent.controller
{
    class Serializer
    {
        public static void Serialize(RootModel tree, string path)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(JsonConvert.SerializeObject(tree.ToDTO(), settings).ToString());
                }
            }

        }

        public static RootModel Deserialize(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    var dto = JsonConvert.DeserializeObject<RootModelDTO>(sr.ReadToEnd());
                    var tree = new RootModel(dto);
                    return tree;
                }
            }
        }
    }
}
