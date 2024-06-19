using PizzaShoppingAPI.Models.DTOs;

namespace PizzaShoppingAPI.Interfaces
{
    public interface IPizzaService
    {
        Task<IEnumerable<PizzaDTO>> GetPizzasInStockAsync();
        Task UpdatePizzaAsync(int id, PizzaDTO pizzaDto);
    }
}
