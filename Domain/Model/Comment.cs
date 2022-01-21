using RestaurantTimBaig.Domain.Model.Common;
using System;

namespace RestaurantTimBaig.Domain.Model
{
    /// <summary>
    /// Модель данных "Комментарий"
    /// </summary>
    public class Comment : Entity
    {
        /// <summary>
        /// Id ресторана
        /// </summary>
        public Restaurant Restaurant { get; set; }

        /// <summary>
        /// Посетитель
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Дата создания комментария
        /// </summary>
        public DateTime DateComment { get; set; }

        /// <summary>
        /// Оценка посетителя
        /// </summary>
        public long Point { get; set; }

        /// <summary>
        /// Содержиме комментария
        /// </summary>
        public string DataComment { get; set; }
    }
}
