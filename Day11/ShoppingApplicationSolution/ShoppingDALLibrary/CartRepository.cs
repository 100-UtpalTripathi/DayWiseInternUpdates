﻿using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override Cart Delete(int key)
        {
            Cart cart = GetByKey(key);

            if (cart != null)
            {
                items.Remove(cart);
                return cart;
            }
            throw new KeyNotFoundException($"No cart with ID {key} found to delete!");
        }

        public override Cart GetByKey(int key)
        {
            // Find the cart with the specified key
            foreach (var cart in items)
            {
                if (cart.Id == key)
                {
                    return cart;
                }
            }
            throw new KeyNotFoundException($"Cart with ID {key} was not found.");
        }

        public override Cart Update(Cart item)
        {
            // Find the existing cart by its key
            Cart existingCart = GetByKey(item.Id);

            if (existingCart != null)
            {
                existingCart.CustomerId = item.CustomerId;
                existingCart.Customer = item.Customer;
                existingCart.CartItems = item.CartItems;
                return existingCart;
            }

            // If cart is not found, throw an exception
            throw new KeyNotFoundException($"Cart with ID {item.Id} was not found to update!");
        }
    }
}
