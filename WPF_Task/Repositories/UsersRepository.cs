using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Task.Models;

namespace WPF_Task.Repositories
{
    internal class UsersRepository
    {
        public List<User> GetAllUsers()
        {
            return Connect.DbConnection.Users.ToList();
        }
        public void AddNewUser(string name,  string surname, string phoneNumber, string email, string password, int role)
        {
            var user = new User()
            {
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber,
                Email = email,
                Password = password,
                RoleId = role
            };
            
            Connect.DbConnection.Users.Add(user);
            Connect.DbConnection.SaveChanges();
        }

        public void DeleteUserFromDb(long id)
        {
            var user = Connect.DbConnection.Users.Find(id);

            Connect.DbConnection.Users.Remove(user);
            Connect.DbConnection.SaveChanges();
        }

        public void UpdateUserInDb(long id, string newName, string newSurname, string newPhoneNumber, string newEmail, string newPassword, int newRole)
        {
            var user = Connect.DbConnection.Users.FirstOrDefault(item => item.Id == id);

            user.Name = newName;
            user.Surname = newSurname;
            user.PhoneNumber = newPhoneNumber;
            user.Email = newEmail;
            user.Password = newPassword;
            user.RoleId = newRole;

            Connect.DbConnection.SaveChanges();
        }
    }
}
