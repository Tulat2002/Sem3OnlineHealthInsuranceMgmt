using Sem3OnlineHealthInsuranceMgmt.Models;

namespace Sem3OnlineHealthInsuranceMgmt.ViewModels;

public class ShoppingCartVM
{
    public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
    
    public OrderHeader OrderHeader { get; set; }
    //public double OrderTotal { get; set; }
}