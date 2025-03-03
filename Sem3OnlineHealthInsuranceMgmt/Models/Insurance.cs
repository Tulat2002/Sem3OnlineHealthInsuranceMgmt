using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Sem3OnlineHealthInsuranceMgmt.Models;

public class Insurance
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    public string PolicyNumber { get; set; }
    [Required]
    public string ResponsibleUnit { get; set; }
    
    [Required]
    [Display(Name = "List Price")]
    [Range(1, 1000)]
    public double ListPrice { get; set; }
    
    [Required]
    [Display(Name = "Price for 1-50")]
    [Range(1, 1000)]
    public double Price { get; set; }
    
    [Required]
    [Display(Name = "Price 50+")]
    [Range(1, 1000)]
    public double Price50 { get; set; }
    
    [Required]
    [Display(Name = "Price 100+")]
    [Range(1, 1000)]
    public double Price100 { get; set; }
    
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    [ValidateNever]
    public Category Category { get; set; }
    [ValidateNever]
    public string ImageUrl { get; set; }
    
    // [Key]
    // public int Id { get; set; }
    // [Required]
    // public string Name { get; set; }
    // public string Description { get; set; }
    // [Column(TypeName = "decimal(18, 2)")]
    // public decimal Premium { get; set; } //Số tiền bảo hiểm
    // public int DurationInMonths { get; set; } //Thời hạn bảo hiểm
    // public DateTime StartDate { get; set; }
    // public DateTime EndDate { get; set; }
    // public bool IsActive { get; set; }
    // // public int CategoryId { get; set; }
    // // [ForeignKey("CategoryId")]
    // // public Category Category { get; set; }
}