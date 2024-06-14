using DataAcessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mail_App.ViewComponents._MessageLayout
{
    public class _MessageLayoutSidebar:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly MailAppContext _appContext;

        public _MessageLayoutSidebar(MailAppContext appContext, UserManager<AppUser> userManager)
        {
            _appContext = appContext;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.messagecount =_appContext.Messages.Where(x=>x.SenderMail == users.Email && x.SenderDelete == false && x.SenderTrashDelete== false).Count();
            ViewBag.sendermessagecount =_appContext.Messages.Where(x=>x.ReceiverMail == users.Email && x.ReceiverDelete == false && x.ReceiverTrashDelete == false).Count();
            ViewBag.trashmessagecount =_appContext.Messages.Where(x=>x.ReceiverMail == users.Email && x.ReceiverDelete == false && x.ReceiverTrashDelete == true).Count();
            return View();
        }

    }
}
