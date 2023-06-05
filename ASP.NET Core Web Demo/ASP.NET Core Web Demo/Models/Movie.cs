using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Core_Web_Demo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [StringLength(60,MinimumLength =3)]
        [Required]
        public string? Title { get; set; }
        /// <summary>
        ///     DataType特性:
        ///        用户无需在日期字段中输入时间信息，仅显示日期，而非时间信息
        ///     Display特性:
        ///        指定要显示的字段名称的内容（本例中应为“Release Date”)
        ///     Required 和 MinimumLength特性:
        ///         表示属性必须有值；但用户可输入空格来满足此验证
        ///     RegularExpression特性:
        ///          用于限制可输入的字符
        ///          
        /// </summary>
        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; }
        [Range(1,300)]
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(18,2)")]
        public decimal? Price { get; set; }
        [RegularExpression(@"^^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string? Rating { get; set; }
    }
}
