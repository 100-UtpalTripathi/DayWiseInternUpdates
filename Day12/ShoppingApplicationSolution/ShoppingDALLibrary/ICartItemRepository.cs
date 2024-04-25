using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;

namespace ShoppingDALLibrary
{
    public interface ICartItemRepository
    {
        CartItem Add(CartItem item);
        ICollection<CartItem> GetAll();
        CartItem Delete(int cartId, int productId);
        CartItem Update(CartItem item);
        CartItem GetByKey(int cartId, int productId);
    }
}