using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Reader_Writer.Models
{
    /// <summary>
    /// Model representing the Product Information
    /// </summary>
    public class ProductInfo: GenericEntity
    {
        public string Name { get; set; }

        public string Categories { get; set; }

        public string TwitterHandle { get; set; }
    }
}
