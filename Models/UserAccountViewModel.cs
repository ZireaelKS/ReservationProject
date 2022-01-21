using RestaurantTimBaig.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Models
{
    public class UserAccountViewModel
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Адрес пользователя
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Эл. почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Полное имя пользователя
        /// </summary>
        public string FullName
        {
            get => FirstName + " " + Surname;
        }

        /// <summary>
        /// Коллекция бронирования
        /// </summary>
        public ICollection<Reservation> Reservations { get; set; }

        /// <summary>
        /// Коллекция комментариев
        /// </summary>
        public ICollection<Comment> Comments { get; set; }
    }
}
