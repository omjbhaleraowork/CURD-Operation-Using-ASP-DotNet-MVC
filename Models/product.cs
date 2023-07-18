using System.ComponentModel.DataAnnotations;

public class Product
{
    public int ProductId { get; set; }

    [Display(Name = "Product Name")]
    [Required(ErrorMessage = "Product Name is required.")]
    public string ProductName { get; set; }

    [Required(ErrorMessage = "Rate is required.")]
    public decimal Rate { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    [Display(Name = "Category")]
    [Required(ErrorMessage = "Category is required.")]
    public string CategoryName { get; set; }
}