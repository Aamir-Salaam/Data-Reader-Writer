using Data_Reader_Writer.Contracts;
using Data_Reader_Writer.Models;
using Data_Reader_Writer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Reader_Writer.Logic.Writers
{
    /// <summary>
    /// Db writer that writes to some MySQL database
    /// </summary>
    public class MySqlWriter : IDbWriter
    {
        public void WriteToDb(ProductInfo productInfo, ProductInfoRepository productInfoRepository)
        {
            productInfoRepository.Insert(productInfo);

            Console.WriteLine($"importing: Name: '{productInfo.Name}'; Categories: '{string.Join(",", productInfo.Categories)}'; Twitter: '{productInfo.TwitterHandle}'");
        }
    }
}
