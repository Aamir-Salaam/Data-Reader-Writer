using Data_Reader_Writer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Reader_Writer.Repositories
{
    public class ProductInfoRepository: GenericRepository<ProductInfo>
    {
        public ProductInfoRepository(): base()
        {

        }

        public override ProductInfo FindById(int id)
        {
            var entity = base.FindById(id);

            if(entity is null)
            {
                throw new Exception($"Product with Id: {id} not found.");
            }

            return entity;
        }

        public override bool Update(ProductInfo product)
        {
            var entry = DataList.SingleOrDefault(data => data.Id == product.Id);

            if (entry is null)
            {
                return false;
            }

            entry.Name = product.Name;
            entry.Categories = product.Categories;
            entry.TwitterHandle = product.TwitterHandle;
            entry.DateModified = DateTime.Now;
            return true;
        }
    }
}
