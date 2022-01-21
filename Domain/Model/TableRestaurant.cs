using RestaurantTimBaig.Domain.Model.Common;

namespace RestaurantTimBaig.Domain.Model
{
    /// <summary>
    /// Модель данных "Столы в ресторане"
    /// </summary>
    public class TableRestaurant : Entity
    {
        /// <summary>
        /// ID ресторана
        /// </summary>
        public Restaurant Restaurant { get; set; }

        /// <summary>
        /// Номер стола
        /// </summary>
        public long NumberTable { get; set; }

        /// <summary>
        /// Статус стола
        /// </summary>
        public TableStatus Status { get; set; }
    }
}
