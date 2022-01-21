

using System.Collections.Generic;

namespace RestaurantTimBaig.Domain.Model.Common
{
    /// <summary>
    /// Модель данных "Ресторан"
    /// </summary>
    public class Restaurant : Entity
    {
        /// <summary>
        /// Название ресторана
        /// </summary>
        public string RestaurantName { get; set; }

        /// <summary>
        /// Адрес ресторана
        /// </summary>
        public string RestaurantAddress { get; set; }

        /// <summary>
        /// Номер телефона ресторана
        /// </summary>
        public string RestaurantPhone { get; set; }

        /// <summary>
        /// Описание ресторана
        /// </summary>
        public string RestaurantDescription{ get; set; }

        /// <summary>
        /// Эл. почта ресторана
        /// </summary>
        public string RestaurantEmail { get; set; }

        /// <summary>
        /// Коллекия комментариев
        /// </summary>
        public ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// Коллекция резервирования
        /// </summary>
        public ICollection<Reservation> Reservations { get; set; }

        /// <summary>
        /// Коллекция меню
        /// </summary>
        public ICollection<Dish> Dishes { get; set; }

        /// <summary>
        /// коллекция столов
        /// </summary>
        public ICollection<TableRestaurant> TableRestaurants { get; set; }
    }
}
