using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        public override CartItem Delete(int key)
        {
            CartItem cartItem = GetByKey(key);

            if (cartItem != null)
            {
                items.Remove(cartItem);
                return cartItem;
            }

            throw new KeyNotFoundException($"No cart item with ID {key} found to delete!");
        }

        public override CartItem GetByKey(int key)
        {
            CartItem cartItem = items.FirstOrDefault(ci => ci.CartId == key);

            if (cartItem == null)
            {
                throw new KeyNotFoundException($"Cart item with ID {key} was not found.");
            }

            return cartItem;
        }

        public override CartItem Update(CartItem item)
        {
            CartItem existingCartItem = GetByKey(item.CartId);

            if (existingCartItem != null)
            {
                existingCartItem.ProductId = item.ProductId;
                existingCartItem.Quantity = item.Quantity;
                existingCartItem.Price = item.Price;
                existingCartItem.Discount = item.Discount;
                existingCartItem.PriceExpiryDate = item.PriceExpiryDate;
                return existingCartItem;
            }

            throw new KeyNotFoundException($"Cart item with ID {item.CartId} was not found to update!");
        }
    }
}
