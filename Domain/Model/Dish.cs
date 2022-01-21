using RestaurantTimBaig.Domain.Model.Common;

namespace RestaurantTimBaig.Domain.Model
{
    /// <summary>
    /// Модель данных "Блюда"
    /// </summary>
    public class Dish : Entity
    {
        /// <summary>
        /// Тип блюда
        /// </summary>
        public TypeDish Type { get; set; }

        /// <summary>
        /// Ресторан
        /// </summary>
        public Restaurant Restaurant { get; set; }

        /// <summary>
        /// Название блюда
        /// </summary>
        public string NameDish { get; set; }

        /// <summary>
        /// Время приготовления
        /// </summary>
        public long CookingTime { get; set; }

        /// <summary>
        /// Состав блюда
        /// </summary>
        public string Composition { get; set; }
    }
}
