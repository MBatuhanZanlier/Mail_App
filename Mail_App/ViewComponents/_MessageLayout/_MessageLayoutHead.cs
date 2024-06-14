using Microsoft.AspNetCore.Mvc;

namespace Mail_App.ViewComponents._MessageLayout
{
    public class _MessageLayoutHead:ViewComponent
    { 
        public IViewComponentResult Invoke() { return View(); }
    }
}
