using System.Linq.Expressions;
using Sem3OnlineHealthInsuranceMgmt.Data;
using Sem3OnlineHealthInsuranceMgmt.Models;

namespace Sem3OnlineHealthInsuranceMgmt.Repository.IRepository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Category obj)
    {
        _db.Categories.Update(obj);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}