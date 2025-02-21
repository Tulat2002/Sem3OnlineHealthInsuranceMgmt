using Sem3OnlineHealthInsuranceMgmt.Models;

namespace Sem3OnlineHealthInsuranceMgmt.Repository.IRepository;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    void Update(ShoppingCart obj);
}