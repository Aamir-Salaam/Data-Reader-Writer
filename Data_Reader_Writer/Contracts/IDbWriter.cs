using Data_Reader_Writer.Models;
using Data_Reader_Writer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Reader_Writer.Contracts
{
    /// <summary>
    /// Db writer that writes to database
    /// </summary>
    public interface IDbWriter
    {
        /// <summary>
        /// Write <see cref="ProductInfo"/> data to database
        /// </summary>
        /// <param name="entity"><see cref="ProductInfo"/> entity to write</param>
        /// <param name="repository"><see cref="ProductInfoRepository"/> to use for writing</param>
        void WriteToDb(ProductInfo entity, ProductInfoRepository repository);
    }
}
