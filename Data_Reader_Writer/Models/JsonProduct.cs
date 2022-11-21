using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Reader_Writer.Models
{
    /// <summary>
    /// Model for Json product data
    /// </summary>
    public class JsonProduct
    {
        /// <summary>
        /// Name of the product
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Categories for the product
        /// </summary>
        public string[] categories { get; set; }

        /// <summary>
        /// Twitter handle for the product
        /// </summary>
        public string twitter { get; set; }
    }
}
