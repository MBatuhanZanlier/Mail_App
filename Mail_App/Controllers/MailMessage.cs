using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mail_App.Controllers
{
    public class MailMessage : Controller
    { 
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;
        public MailMessage(UserManager<AppUser> userManager, IMessageService messageService)
        {
            _userManager = userManager;
            _messageService = messageService;
        }

        public async Task<IActionResult> InBox(string mail)
        {
            var users = await _userManager.FindByNameAsync(User.Identity.Name);
            mail = users.Email; 
            var messagelist=_messageService.TGetReciverListMessage(mail);
            return View(messagelist);
        }
        public async Task<IActionResult> SenderBox(string mail)
        {
            var users = await _userManager.FindByNameAsync(User.Identity.Name);
            mail = users.Email;
            var messagelist = _messageService.TGetSenderListMessage(mail);
            return View(messagelist);
        }
        public IActionResult InboxMessageDetails(int id)
        {
            var message = _messageService.TGetbyId(id);
            return View(message);

        } 
        [HttpGet] 
        public IActionResult SendMessage() { return View(); }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message) 
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            message.SenderNameSurname = user.Name + " " + user.Surname; 
            message.SenderMail = user.Email; 
            message.SendDate = DateTime.Now;
            message.IsRead = false; 
            _messageService.TInsert(message);
            return RedirectToAction("Inbox");
        }  
        public async Task<IActionResult> TrashBox(string mail)
        {
            var users = await _userManager.FindByNameAsync(User.Identity.Name);
            mail = users.Email;
            var trashboxlist = _messageService.TGetRecieverTrashMessage(mail);
            return View(trashboxlist);
        }
        //public async Task<IActionResult> SendTrashbox(string mail)
        //{
        //    var users = await _userManager.FindByNameAsync(User.Identity.Name);
        //    mail = users.Email;
        //    var trashboxlist = _messageService.TGetSenderTrashMessage(mail);
        //    return View(trashboxlist);
        //}
   
      public IActionResult TrashMessage(int id) 
        {

            var values = _messageService.TGetbyId(id);
            values.ReceiverTrashDelete = true; 
            _messageService.TUpdate(values);
            return RedirectToAction("TrashBox");
        
        } 
        public IActionResult TrashOutMessage(int id) 
        {
            var values = _messageService.TGetbyId(id);
            values.ReceiverTrashDelete = false;
            _messageService.TUpdate(values);
            return RedirectToAction("TrashBox");

        }
    } 
    
   
}
