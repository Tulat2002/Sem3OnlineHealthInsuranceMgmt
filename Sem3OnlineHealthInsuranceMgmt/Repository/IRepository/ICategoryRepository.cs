using Sem3OnlineHealthInsuranceMgmt.Models;

namespace Sem3OnlineHealthInsuranceMgmt.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category obj);
    void Save();
}