using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {

        public override Product Delete(int key)
        {
            Product product = items.FirstOrDefault(p => p.Id == key);
            if (product != null)
            {
                items.Remove(product);
                return product;
            }
            throw new NoItemWithGivenIdException($"No Product with ID {key} found to delete!");
        }

        public override Product GetByKey(int key)
        {
            Product product = items.FirstOrDefault(p => p.Id == key);
            if (product == null)
            {
                throw new NoItemWithGivenIdException($"Product with the ID {key} was not found.");
            }
            return product;
        }

        public override Product Update(Product item)
        {
            Product product = items.FirstOrDefault(p => p.Id == item.Id);
            if (product == null)
            {
                throw new NoItemWithGivenIdException($"Product with the ID {item.Id} was not found.");
            }
            product = item;
            return product;
        }


    }
}
