using RestaurantTimBaig.Domain.Model.Common;
using System;
using System.Collections.Generic;

namespace RestaurantTimBaig.Domain.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class Employee: Entity
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
