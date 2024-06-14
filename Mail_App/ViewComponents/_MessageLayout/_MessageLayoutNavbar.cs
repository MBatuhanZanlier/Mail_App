using DataAcessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mail_App.ViewComponents._MessageLayout
{
    public class _MessageLayoutNavbar:ViewComponent
    {  
      

        public IViewComponentResult Invoke() 
        {
         
            return View(); 
        }
    } 
}
