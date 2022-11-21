using System;
using Data_Reader_Writer.Models;
using Data_Reader_Writer.Repositories;
using NUnit.Framework;
using System.Text;

namespace UnitTests
{
    /// <summary>
    /// Tests for <see cref="ProductInfoRepository"/>
    /// </summary>
    [TestFixture]
    public class ProductInfoRepositoryTests
    {
        public ProductInfoRepository productInfoRepository;

        [SetUp]
        public void ProductInfoRepositoryTests1()
        {
            productInfoRepository = new ProductInfoRepository();
        }

        [Test]
        public void Insert_Success()
        {
            // Arrange
            var product = new ProductInfo
            {
                Name = "Dummy product",
                TwitterHandle = "@dummyProduct",
                Categories = "Dummy Category1, Dummy Category2"
            };

            // Act
            productInfoRepository.Insert(product);

            // Assert
            var productInDb = productInfoRepository.FindAll(prod => prod.Name == product.Name);

            Assert.IsNotNull(productInDb);
            Assert.AreEqual(1, product.Id);
        }

        [Test]
        public void Delete_Success()
        {
            // Arrange
            var product = new ProductInfo
            {
                Name = "Dummy product",
                TwitterHandle = "@dummyProduct",
                Categories = "Dummy Category1, Dummy Category2"
            };

            // Act
            productInfoRepository.Insert(product);

            // Assert
            var productInDb = productInfoRepository.FindById(product.Id);

            Assert.IsNotNull(productInDb);
            Assert.AreEqual(product.Name, productInDb.Name);

            // Act
            var result = productInfoRepository.Delete(product.Id);

            //Assert
            Assert.IsTrue(result);

            try
            {
                var productInDb2 = productInfoRepository.FindById(product.Id);
            }
            catch(Exception ex)
            {
                Assert.AreEqual($"Product with Id: {product.Id} not found.", ex.Message);
            }
        }

        [Test]
        public void UpdateProductInfo_Success()
        {
            // Arrange
            var product = new ProductInfo
            {
                Name = "Dummy product",
                TwitterHandle = "@dummyProduct",
                Categories = "Dummy Category1, Dummy Category2"
            };

            // Act
            productInfoRepository.Insert(product);

            // Assert
            var productInDb = productInfoRepository.FindById(product.Id);

            Assert.IsNotNull(productInDb);
            Assert.AreEqual(product.Name, productInDb.Name);

            var updateInfo = new ProductInfo
            {
                Id = product.Id,
                Name = "Dummy product2"
            };

            // Act
            var result = productInfoRepository.Update(updateInfo);

            // Assert
            Assert.IsTrue(result);

            var productInDb2 = productInfoRepository.FindById(product.Id);

            Assert.AreEqual(updateInfo.Name, productInDb2.Name);
        }

        [TearDown]
        public void Dispose()
        {
            productInfoRepository.DataList.Clear();
        }
    }
}