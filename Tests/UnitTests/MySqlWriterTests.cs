using Data_Reader_Writer.Logic.Writers;
using Data_Reader_Writer.Models;
using Data_Reader_Writer.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class MySqlWriterTests
    {
        [Test]
        public void WriteToDb_Success()
        {
            var productInfo = new ProductInfo
            {
                Id = 1,
                Name = "Dummy product",
                TwitterHandle = "@dummyProduct",
                Categories = "Dummy Category1, Dummy Category2"
            };

            var repository = new ProductInfoRepository();

            var logic = new MySqlWriter();

            logic.WriteToDb(productInfo, repository);

            var entry = repository.FindById(productInfo.Id);

            Assert.IsNotNull(entry);
            Assert.AreEqual(productInfo.Name, entry.Name);
        }
    }
}
