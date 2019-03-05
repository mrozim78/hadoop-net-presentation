using System.ComponentModel.DataAnnotations;

namespace Hadoop.Net.Hbase.WebApp.Pages.Model
{
    public class UserColorForm
    {
        [Required]
        public string Color { get; set; }
        [Required]
        public string UserColor { get; set; }
    }
}