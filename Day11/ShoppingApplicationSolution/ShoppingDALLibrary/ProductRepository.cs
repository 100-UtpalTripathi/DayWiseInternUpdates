﻿using ShoppingModelLibrary.Exceptions;
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
            Product Product = GetByKey(key);
            if (Product != null)
            {
                items.Remove(Product);
            }
            return Product;
        }

        public override Product GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoProductWithGivenIdException();
        }

        public override Product Update(Product item)
        {
            Product Product = GetByKey(item.Id);
            if (Product != null)
            {
                Product = item;
            }
            return Product;
        }
    }
