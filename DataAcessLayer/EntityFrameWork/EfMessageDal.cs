using DataAcessLayer.Abstract;
using DataAcessLayer.Context;
using DataAcessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.EntityFrameWork
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    { 
        MailAppContext _context=new MailAppContext();

        public List<Message> GetRecieverTrashMessage(string mail)
        {
            var values = _context.Messages.Where(x => (x.ReceiverMail == mail && x.ReceiverDelete == false && x.ReceiverTrashDelete == true) || (x.SenderMail == mail && x.SenderDelete == false && x.SenderTrashDelete == true)).ToList();
            return values;
        }

        public List<Message> GetReciverListMessage(string mail)
        {
            var values= _context.Messages.Where(x=>x.ReceiverMail== mail && x.ReceiverDelete == false && x.ReceiverTrashDelete ==false).ToList(); 
            return values;
        }

        public List<Message> GetSenderListMessage(string mail)
        {
         var values= _context.Messages.Where(x=>x.SenderMail== mail && x.SenderDelete==false && x.SenderTrashDelete==false).ToList(); return values;
        }

        public List<Message> GetSenderTrashMessage(string mail)
        {
            var values = _context.Messages.Where(x => x.SenderMail == mail && x.SenderDelete == false && x.SenderTrashDelete == true).ToList(); return values;
        }
    }
}
