using Data_Reader_Writer.Contracts;
using Data_Reader_Writer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization.NamingConventions;

namespace Data_Reader_Writer.Logic.Readers
{
    /// <summary>
    /// Parser for JSON data
    /// </summary>
    public class JsonParser : IJsonParser
    {
        public string Readpath { get; set; }

        public JsonParser(string readPath)
        {
            Readpath = readPath;
        }

        ///<inheritdoc/>
        public List<JsonProduct> ParseFromStream()
        {
            using (StreamReader file = File.OpenText(Readpath))
            {
                var jsonProducts = new List<JsonProduct>();

                dynamic data = JsonConvert.DeserializeObject(file.ReadToEnd());

                var products = data.products;

                var jsonSerialized = JsonConvert.SerializeObject(products);

                var jsonProductsList = JsonConvert.DeserializeObject<List<JsonProduct>>(jsonSerialized);

                return jsonProductsList;
            }
        }
    }
}
