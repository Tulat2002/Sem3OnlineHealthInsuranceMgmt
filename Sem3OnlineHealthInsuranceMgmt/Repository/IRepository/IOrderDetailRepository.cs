using Sem3OnlineHealthInsuranceMgmt.Models;

namespace Sem3OnlineHealthInsuranceMgmt.Repository.IRepository;

public interface IOrderDetailRepository : IRepository<OrderDetail>
{
    void Update(OrderDetail obj);
}