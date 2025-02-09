using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Task.Models;

namespace WPF_Task.Repositories
{
    internal class RequestsRepositories
    {
        public List<User> GetAllUsers()
        {
            return Connect.DbConnection.Users.ToList();
        }
        public List<Good> GetAllGoods()
        {
            return Connect.DbConnection.Goods.ToList();
        }
        public void AddNewRequest(long clientId, long goodsId)
        {
            var request = new Request()
            {
                ClientId = clientId,
                GoodsId = goodsId,
                StartDate = DateTime.Now,
                StatusId = 1,
                CompletionDate = null,
                MasterId = 0,

            };
            Connect.DbConnection.Requests.Add(request);
            Connect.DbConnection.SaveChanges();
        }
        public void DeleteRequestFromDb(long id)
        {
            var request = Connect.DbConnection.Requests.Find(id);
            
            Connect.DbConnection.Requests.Remove(request);
            Connect.DbConnection.SaveChanges();
        }
        public void UpdateRequestInDb(long id, long newMasterId, int newStatusId, DateTime completionDate)
        {

        }
    }
}

