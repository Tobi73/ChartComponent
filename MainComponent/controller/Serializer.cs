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
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace MainComponent.controller
{
    class Serializer
    {
        public static string Serialize(RootModel tree, string path)
        {
            //JsonConvert.SerializeObject(tree).ToString();
            try
            {
                var settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };
                var c = new Control();
                var rm = new RootModel();
                //JavaScriptSerializer jss = new JavaScriptSerializer();
                //var s = jss.Serialize(tree);
                //DataContractSerializer serializer = new DataContractSerializer(typeof(RootModel));
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(JsonConvert.SerializeObject(tree, settings).ToString());
                    }
                    //using (XmlWriter writer = XmlWriter.Create(fs))
                    //{
                    //    serializer.WriteObject(writer, tree);
                    //}
                }
            }
            catch (Exception ex)
            {
                return "не сохранил дерево графиков в" + path + Environment.NewLine + ex.ToString();
            }
            return "Сохранено";
        }

        public static RootModel Deserialize(string path)
        {
            RootModel tree = null;
            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(RootModel));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    //using (XmlReader writer = XmlReader.Create(fs))
                    //{
                    //    tree = (RootModel)serializer.ReadObject(writer);
                    //}
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        tree = JsonConvert.DeserializeObject<RootModel>(sr.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tree;
        }
    }
}
