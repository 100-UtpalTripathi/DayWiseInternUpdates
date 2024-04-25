using ShoppingModelLibrary;
using System.Collections.Generic;

namespace ShoppingBLLibrary
{
    public interface ICartService
    { 
        Cart AddProductToCart(int cartId, int productId, int quantity);

        Cart RemoveProductFromCart(int cartId, int productId);

        Cart GetCartById(int cartId);

        IEnumerable<Cart> GetAllCarts();

        double CalculateShippingCharges(double totalPurchaseValue);
        double ApplyDiscounts(Cart cart);
        bool ExceedsMaxQuantityLimit(Cart cart, int productId, int quantity);
    }
}
