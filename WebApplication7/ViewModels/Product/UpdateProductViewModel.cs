using System.ComponentModel.DataAnnotations;

public class UpdateProductViewModel
{
    [Display(Name = "شناسه محصول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [Range(1, int.MaxValue, ErrorMessage = "شناسه محصول باید یک عدد مثبت باشد")]
    public int Id { get; set; }

    [Display(Name = "نام محصول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [StringLength(100, ErrorMessage = "طول {0} باید بین {2} تا {1} کاراکتر باشد", MinimumLength = 3)]
    [RegularExpression(@"^[\p{L}0-9\s]+$", ErrorMessage = "فقط حروف و اعداد مجاز است")]
    public required string Name { get; set; }

    [Display(Name = "توضیحات محصول")]
    [MaxLength(500, ErrorMessage = "تعداد کاراکتر {0} باید حداکثر {1} کاراکتر داشته باشد")]
    public string? Description { get; set; }

    [Display(Name = "قیمت محصول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [Range(0.01, 1000000, ErrorMessage = "قیمت باید بین {1} و {2} باشد")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "قیمت باید یک عدد معتبر باشد")]
    public decimal? Price { get; set; }

    //[EmailAddress(ErrorMessage ="")]
    //public string Email { get; set; }

    //[Url(ErrorMessage ="")]
    //public string Url { get; set; }             https://toplearn.com
}
