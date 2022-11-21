using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Reader_Writer.Models
{
    /// <summary>
    /// Generic Entity that other entities can derive common properties from
    /// </summary>
    public class GenericEntity
    {
        /// <summary>
        /// Id of entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date of modification
        /// </summary>
        public DateTime DateModified { get; set; }
    }
}
