using Sem3OnlineHealthInsuranceMgmt.Data;

namespace Sem3OnlineHealthInsuranceMgmt.Repository.IRepository;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext _db;
    public ICategoryRepository Category { get; private set; }
    public IInsuranceRepository Insurance { get; private set; }
    public ICompanyRepository Company { get; private set; }
    public IShoppingCartRepository ShoppingCart { get; private set; }
    public IOrderHeaderRepository OrderHeader { get; private set; }
    public IOrderDetailRepository OrderDetail { get; private set; }
    public IApplicationUserRepository ApplicationUser { get; private set; }

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Category = new CategoryRepository(_db);
        Insurance = new InsuranceRepository(_db);
        Company = new CompanyRepository(_db);
        ShoppingCart = new ShoppingCartRepository(_db);
        OrderHeader = new OrderHeaderRepository(_db);
        OrderDetail = new OrderDetailRepository(_db);   
        ApplicationUser = new ApplicationUserRepository(_db);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}