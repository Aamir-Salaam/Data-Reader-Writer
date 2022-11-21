using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Reader_Writer.Models
{
    /// <summary>
    /// Model for Yaml product data
    /// </summary>
    public class YamlProduct
    {
        /// <summary>
        /// Name of the product
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Categories for the product
        /// </summary>
        public string tags { get; set; }

        /// <summary>
        /// Twitter handle of the product
        /// </summary>
        public string twitter { get; set; }
    }
}
