using RestaurantTimBaig.Domain.Model.Common;
using System;

namespace RestaurantTimBaig.Domain.Model
{
    /// <summary>
    /// Модель данных "Бронирование"
    /// </summary>
    public class Reservation : Entity
    {
        /// <summary>
        /// Номер бронирования
        /// </summary>
        public long NumberReservation { get; set; }

        /// <summary>
        /// Id ресторана
        /// </summary>
        public Restaurant Restaurant { get; set; }

        /// <summary>
        /// Id посетителя
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Номер заказанного стола
        /// </summary>
        public TableRestaurant TableRestaurant { get; set; }

        /// <summary>
        /// Время бронирования
        /// </summary>
        public DateTime TimeReservation { get; set; }

        /// <summary>
        /// Дата создания брони
        /// </summary>
        public DateTime DateReservation { get; set; }
    }
}
