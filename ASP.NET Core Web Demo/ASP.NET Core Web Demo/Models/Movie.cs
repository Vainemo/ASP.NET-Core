using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Web_Demo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        /// <summary>
        /// 通过DataType特性，用户无需在日期字段中输入时间信息，仅显示日期，而非时间信息
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal? Price { get; set; }
    }
}
