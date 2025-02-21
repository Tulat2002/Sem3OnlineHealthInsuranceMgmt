using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Sem3OnlineHealthInsuranceMgmt.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    
    public int InsuranceId { get; set; }
    
    [ForeignKey("InsuranceId")]
    [ValidateNever]
    public Insurance Insurance { get; set; }
    
    [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
    public int Count { get; set; }
    
    public string ApplicationUserId { get; set; }
    
    [ForeignKey("ApplicationUserId")]
    [ValidateNever]
    public ApplicationUser ApplicationUser { get; set; }
    
    [NotMapped]
    public double Price { get; set; }
}