using Sem3OnlineHealthInsuranceMgmt.Data;
using Sem3OnlineHealthInsuranceMgmt.Models;

namespace Sem3OnlineHealthInsuranceMgmt.Repository.IRepository;

public class InsuranceRepository : Repository<Insurance>, IInsuranceRepository
{
    private ApplicationDbContext _db;
    public InsuranceRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Insurance obj)
    {
        var objFromDb = _db.Insurances.FirstOrDefault(u=>u.Id == obj.Id);
        if (objFromDb != null)
        {
            objFromDb.Title = obj.Title;
            objFromDb.Description = obj.Description;
            objFromDb.ISBN = obj.ISBN;
            objFromDb.ResponsibleUnit = obj.ResponsibleUnit;
            objFromDb.Price = obj.Price;
            objFromDb.Price50 = obj.Price50;
            objFromDb.Price100 = obj.Price100;
            objFromDb.ListPrice = obj.ListPrice;
            objFromDb.CategoryId = obj.CategoryId;
            if (obj.ImageUrl != null)
            {
                objFromDb.ImageUrl = obj.ImageUrl;
            }
        }
    }
}