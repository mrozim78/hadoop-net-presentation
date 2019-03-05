using Hadoop.Net.Hbase.WebApp.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hadoop.Net.Hbase.WebApp.Pages
{
    public class HtmlColors : PageModel
    {
        private int numberOfColors = 0;
        private readonly IColorService _colorService;
        public string Message { get; private set; }
        public HtmlColors(IColorService colorService)
        {
            _colorService = colorService;
        }
            
        public void OnGet()
        {
        }

        public void OnPost(int numberOfColors)
        {
            _colorService.AddRandomColors(numberOfColors);
            Message = $"{numberOfColors} generated";
        }
    }
}