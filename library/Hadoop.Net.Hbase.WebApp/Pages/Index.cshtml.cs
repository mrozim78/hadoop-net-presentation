using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadoop.Net.Hbase.WebApp.Model;
using Hadoop.Net.Hbase.WebApp.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hadoop.Net.Hbase.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private IColorService _colorService;
        private IUserColorService _userColorService;

        public string ErrorMessage;
        public UserColorForm UserColorForm;
        
        public IndexModel(IColorService colorService , IUserColorService userColorService)
        {
            _colorService = colorService;
            _userColorService = userColorService;
        }
        
        public HtmlColor Color;
        public void OnGet()
        {
            Color = _colorService.GetRandomColor();
        }

        public void OnPost(UserColorForm userColorForm)
        {
            var request = this.Request;
                
                
            UserColorForm = userColorForm;
            if (ModelState.IsValid)
            {

                if (_colorService.IsColorExists(userColorForm.Color))
                {
                    UserHtmlColor userHtmlColor = UserHtmlColor.Create(userColorForm.Color,
                        userColorForm.UserColor =="red",
                        userColorForm.UserColor =="green",
                        userColorForm.UserColor =="blue",
                         request.HttpContext.Connection.RemoteIpAddress.ToString(),
                        request.Headers["User-Agent"].ToString()
                        );
                    if (!userHtmlColor.IsRed && !userHtmlColor.IsBlue && !userHtmlColor.IsGreen)
                    {
                        ErrorMessage = "Choose color red , green or blue";
                    }
                    else
                    {
                        _userColorService.AddUserColor(userHtmlColor);
                    }
                   
                 }
                else
                {
                    ErrorMessage = "Color not exists";
                }
                    
                Color = _colorService.GetRandomColor();                   
            } 
            
        }
    }
}