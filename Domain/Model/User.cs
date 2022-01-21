using Microsoft.AspNetCore.Identity;
using RestaurantTimBaig.Domain.Model.Common;

namespace RestaurantTimBaig.Domain.Model
{
    /// <summary>
    /// User
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// Посетитель
        /// </summary>
        public Employee Employee { get; set; }
    }
}
