using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Sem3OnlineHealthInsuranceMgmt.Models;

public class OrderDetail
{
    public int Id { get; set; }
    [Required]
    public int OrderHeaderId { get; set; }
    [ForeignKey("OrderHeaderId")]
    [ValidateNever]
    public OrderHeader OrderHeader { get; set; }


    [Required]
    public int InsuranceId { get; set; }
    [ForeignKey("InsuranceId")]
    [ValidateNever]
    public Insurance Insurance { get; set; }

    public int Count { get; set; }
    public double Price { get; set; }
}