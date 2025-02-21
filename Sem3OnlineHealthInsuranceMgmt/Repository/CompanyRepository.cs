using System.Linq.Expressions;
using Sem3OnlineHealthInsuranceMgmt.Data;
using Sem3OnlineHealthInsuranceMgmt.Models;

namespace Sem3OnlineHealthInsuranceMgmt.Repository.IRepository;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    private ApplicationDbContext _db;

    public CompanyRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Company obj)
    {
        _db.Companies.Update(obj);
    }

    // public void Save()
    // {
    //     _db.SaveChanges();
    // }
}