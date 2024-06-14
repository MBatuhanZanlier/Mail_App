using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TDelete(int id)
        {
            _messageDal.Delete(id);
        }

        public Message TGetbyId(int id)
        {
            return _messageDal.GetbyId(id);
        }

        public List<Message> TGetlistAll()
        {
            return _messageDal.GetlistAll();
        }

        public List<Message> TGetRecieverTrashMessage(string mail)
        {
            return _messageDal.GetRecieverTrashMessage(mail);
        }

        public List<Message> TGetReciverListMessage(string mail)
        {
            return _messageDal.GetReciverListMessage(mail);
        }

        public List<Message> TGetSenderListMessage(string mail)
        {
            return _messageDal.GetSenderListMessage(mail);
        }

        public List<Message> TGetSenderTrashMessage(string mail)
        {
            return _messageDal.GetSenderTrashMessage(mail);
        }

        public void TInsert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
