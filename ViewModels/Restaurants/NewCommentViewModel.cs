using RestaurantTimBaig.Domain.Model;
using System;
using RestaurantTimBaig.Domain.Model.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestaurantTimBaig.ViewModels.Restaurants
{
    public class NewCommentViewModel
    {
        /// <summary>
        /// Id ресторана
        /// </summary>
        [Required]
        [Display(Name = "Ресторан")]
        public long IdRestaurant { get; set; }

        /// <summary>
        /// Оценка посетителя
        /// </summary>
        [Required]
        [Display(Name = "Оценка")]
        public long Point { get; set; }

        /// <summary>
        /// Содержиме комментария
        /// </summary>
        [Required]
        [Display(Name = "Текст комментария")]
        public string DataComment { get; set; }
    }
}
