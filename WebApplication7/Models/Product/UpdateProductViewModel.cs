using System.ComponentModel.DataAnnotations;

public class UpdateProductViewModel
{
    public int Id { get; set; }

    [Display(Name = "عنوان محصول")]
    [Required(ErrorMessage = "عنوان محصول الزامی است.")]
    [MinLength(2, ErrorMessage = "عنوان باید حداقل ۲ کاراکتر داشته باشد.")]
    public string? Name { get; set; }

    [Display(Name = "توضیحات محصول")]
    public string? Description { get; set; }

    [Display(Name = "قیمت (تومان)")]
    [Required(ErrorMessage = "وارد کردن قیمت الزامی است.")]
    [RegularExpression(@"^\d+(,\d{3})*$", ErrorMessage = "لطفاً یک قیمت معتبر وارد کنید.")]
    public string? Price { get; set; }
}
