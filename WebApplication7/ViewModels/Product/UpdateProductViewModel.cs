using System.ComponentModel.DataAnnotations;

public class UpdateProductViewModel
{
    public int Id { get; set; }

    [Display(Name = "عنوان محصول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MinLength(5, ErrorMessage = "تعداد کاراکتر {0} باید حداقل {1} کاراکتر داشته باشد")]
    [MaxLength(10, ErrorMessage = "تعداد کاراکتر {0} باید حداکثر {1} کاراکتر داشته باشد")]
    public string? Name { get; set; }

    [Display(Name = "توضیحات محصول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string? Description { get; set; }

    [Display(Name = "قیمت (تومان)")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [RegularExpression(@"^\d+(,\d{3})*$", ErrorMessage = "لطفاً یک قیمت معتبر وارد کنید.")]
    public string? Price { get; set; }

    //[EmailAddress(ErrorMessage ="")]
    //public string Email { get; set; }

    //[Url(ErrorMessage ="")]
    //public string Url { get; set; }             https://toplearn.com
}
