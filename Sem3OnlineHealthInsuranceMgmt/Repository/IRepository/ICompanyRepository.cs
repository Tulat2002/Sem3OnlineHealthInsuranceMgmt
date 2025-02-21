using Sem3OnlineHealthInsuranceMgmt.Models;

namespace Sem3OnlineHealthInsuranceMgmt.Repository.IRepository;

public interface ICompanyRepository : IRepository<Company>
{
    void Update(Company obj);
    // void Save();
}