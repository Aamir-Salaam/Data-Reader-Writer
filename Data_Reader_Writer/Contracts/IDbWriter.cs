using Data_Reader_Writer.Models;
using Data_Reader_Writer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Reader_Writer.Contracts
{
    public interface IDbWriter
    {
        void WriteToDb(ProductInfo entity, ProductInfoRepository repository);
    }
}
