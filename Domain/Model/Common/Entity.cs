using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Domain.Model.Common
{
    public abstract class Entity
    {
        /// <summary>
        /// Создание экземпляра модели сущности
        /// </summary>
        protected Entity()
        { }

        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        [Key]
        public virtual long Id { get; set; }
    }
}
