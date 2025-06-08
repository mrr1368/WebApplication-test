using System.ComponentModel.DataAnnotations;

public class CreateProductViewModel
{
    [Display(Name = "عنوان محصول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    //[MinLength(2, ErrorMessage = "تعداد کاراکتر {0} باید حداقل {1} کاراکتر داشته باشد")]
    //[MaxLength(10, ErrorMessage = "تعداد کاراکتر {0} باید حداکثر {1} کاراکتر داشته باشد")]
    [StringLength(100, ErrorMessage = "طول {0} باید بین {2} تا {1} کاراکتر باشد", MinimumLength = 3)]
    [RegularExpression(@"^[\p{L}0-9\s]+$", ErrorMessage = "فقط حروف و اعداد مجاز است")]
    public string? Name { get; set; }

    [Display(Name = "توضیحات محصول")]
    [MaxLength(500, ErrorMessage = "تعداد کاراکتر {0} باید حداکثر {1} کاراکتر داشته باشد")]
    public string? Description { get; set; }

    [Display(Name = "قیمت (تومان)")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [Range(0.01, 1000000, ErrorMessage = "قیمت باید بین {1} و {2} باشد")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "قیمت باید یک عدد معتبر باشد")]
    public decimal? Price { get; set; }
}
