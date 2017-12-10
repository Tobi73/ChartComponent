using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TreeComponent;

namespace MainComponent.controller
{
    class Serializer
    {
        public static string Serialize(TreeModel tree, string path)
        {
            try
            {
                //     XmlSerializer serializer = new XmlSerializer(typeof(Project));
                DataContractSerializer serializer = new DataContractSerializer(typeof(TreeModel));
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

        public static TreeModel Deserialize(string path)
        {
            TreeModel tree = null;
            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(TreeModel));
                //               XmlSerializer serializer = new XmlSerializer(typeof(Project));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (XmlReader writer = XmlReader.Create(fs))
                    {
                        tree = (TreeModel)serializer.ReadObject(writer);
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
