
using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFit.Controller
{

    public class UserController
    {

        /// <summary>
        /// Пользователь преложения
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        /// <summary>
        /// Создания нового интерфейса
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            // TODO:P  Проверка
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя не может быть пустим.", nameof(userName));
            }
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                Save();
            }
        }
        /// <summary>
        /// палучить 
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }

            }
        }

        /// <summary>
        /// Сохранить даные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
        /// <summary>
        /// Загрузить даные пользователя
        /// </summary>
        /// <returns></returns>
        public User Load()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fs) as User;
            }
        }
    }
}


