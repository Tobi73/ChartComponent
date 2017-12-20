using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ChartComponent.model
{
    public class TreeNodeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // we can serialize everything that is a TreeNode
            return typeof(TreeNode).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // we currently support only writing of JSON
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // we serialize a node by just serializing the _children dictionary
            var node = value as TreeNode;
            serializer.Serialize(writer, node.ChildNodes);
        }
    }
}
