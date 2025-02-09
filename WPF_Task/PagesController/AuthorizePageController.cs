using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Task.Models;

namespace WPF_Task.PagesController
{
    public class AuthorizePageController
    {
        public User FindUserByLoginAndPassword(string name, string password)
        {
            if (name == "")
            {
                throw new Exception("Ошибка. Имя не заполнено.");
            }

            if (password == "")
            {
                throw new Exception("Ошибка. Пароль не заполнен.");
            }

            User user;
            try
            {
                user = Connect.DbConnection.Users.FirstOrDefault(u => u.Name == name && u.Password == password);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка соединения с БД");
            }

            if (user == null)
            {
                throw new Exception("Ошибка. Пользователь с такой парой логин и пароль не найден.");
            }

            return user;
            }
        }
    }
