namespace Sem3OnlineHealthInsuranceMgmt.Repository.IRepository;

public interface IUnitOfWork
{
    ICategoryRepository Category{ get; }
    IInsuranceRepository Insurance{ get; }
    ICompanyRepository Company{ get; }
    IShoppingCartRepository ShoppingCart{ get; }
    IOrderDetailRepository OrderDetail { get; }
    IOrderHeaderRepository OrderHeader { get; }
    
    IApplicationUserRepository ApplicationUser{ get; }

    void Save();
}