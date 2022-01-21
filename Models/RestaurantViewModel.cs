using RestaurantTimBaig.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Models
{
    public class RestaurantViewModel
    {
        /// <summary>
        /// ID ресторана
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название ресторана
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Местонахождение ресторана
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Номер телефона ресторана
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Описание ресторана
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Эл. почта ресторана
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Блюда
        /// </summary>
        public ICollection<Dish> Dishes { get; set; }

        /// <summary>
        /// Столы
        /// </summary>
        public ICollection<TableRestaurant> TableRestaurants { get; set; }

        /// <summary>
        /// Столы
        /// </summary>
        public ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// Пользователи
        /// </summary>
        public ICollection<Employee> Employees { get; set; }
    }
}
