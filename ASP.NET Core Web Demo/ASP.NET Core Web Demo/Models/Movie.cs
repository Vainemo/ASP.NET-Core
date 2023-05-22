using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Core_Web_Demo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        /// <summary>
        /// 通过DataType特性，用户无需在日期字段中输入时间信息，仅显示日期，而非时间信息
        ///  Display 特性指定要显示的字段名称的内容（本例中应为“Release Date”
        /// </summary>
        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal? Price { get; set; }
    }
}
