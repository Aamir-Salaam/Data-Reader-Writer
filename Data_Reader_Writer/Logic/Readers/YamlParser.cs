using Data_Reader_Writer.Contracts;
using Data_Reader_Writer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization.NamingConventions;

namespace Data_Reader_Writer.Logic.Readers
{
    /// <summary>
    /// Parser for Yaml data
    /// </summary>
    public class YamlParser: IYamlParser
    {
        public string Readpath { get; set; }

        public YamlParser(string readPath)
        {
            Readpath = readPath;
        }

        ///<inheritdoc/>
        public List<YamlProduct> ParseFromStream()
        {
            using (var reader = new StreamReader(Readpath))
            {
                // Load the stream
                var yamlProductsList = new List<YamlProduct>();
                var yaml = new YamlStream();
                yaml.Load(reader);

                var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                // Examine the stream
                var mapping = (YamlSequenceNode)yaml.Documents[0].RootNode;

                foreach (var entry in mapping.Children)
                {
                    var data = (YamlMappingNode)entry;
                    var productData = new YamlDotNet.Serialization.Serializer().Serialize(data);

                    var yamlProduct = deserializer.Deserialize<YamlProduct>(productData);

                    yamlProductsList.Add(yamlProduct);
                }

                return yamlProductsList;
            }
        }
    }
}
