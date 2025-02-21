using Sem3OnlineHealthInsuranceMgmt.Models;

namespace Sem3OnlineHealthInsuranceMgmt.Repository.IRepository;

public interface IInsuranceRepository : IRepository<Insurance>
{
    void Update(Insurance obj);
}