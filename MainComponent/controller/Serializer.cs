using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ChartComponent;

namespace MainComponent.controller
{
    class Serializer
    {
        public static string Serialize(RootModel tree, string path)
        {
            try
            {
                //     XmlSerializer serializer = new XmlSerializer(typeof(Project));
                DataContractSerializer serializer = new DataContractSerializer(typeof(RootModel));
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    using (XmlWriter writer = XmlWriter.Create(fs))
                    {
                        serializer.WriteObject(writer, tree);
                        //            serializer.Serialize(writer, project);
                    }
                }
            }
            catch (Exception ex)
            {
                return "не сохранил дерефо графиков в" + path + Environment.NewLine + ex.ToString();
            }
            return "Сохранено";
        }

        public static RootModel Deserialize(string path)
        {
            RootModel tree = null;
            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(RootModel));
                //               XmlSerializer serializer = new XmlSerializer(typeof(Project));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (XmlReader writer = XmlReader.Create(fs))
                    {
                        tree = (RootModel)serializer.ReadObject(writer);
                        //               project = (Project)serializer.Deserialize(writer);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //  if (project == null) project = new Project();
            return tree;
        }
    }
}
