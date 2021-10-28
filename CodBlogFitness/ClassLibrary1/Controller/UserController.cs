using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Controller
{
   
    public class UserController
    {
        /// <summary>
        /// Пользователь преложения
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Создания нового интерфейса
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            // TODO:P  Проверка

            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);

           /* if(user == null)
            {
                throw new ArgumentNullException("Пользователь не можеть бить равен null.", nameof(user));
            }
            User = user;*/
        }
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                 if(formatter.Deserialize(fs) is User)
                {
                    User = User;
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
                formatter.Serialize(fs, User);
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
