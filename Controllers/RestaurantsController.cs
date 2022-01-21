using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantTimBaig.Domain.DB;
using RestaurantTimBaig.Domain.Model;
using RestaurantTimBaig.Domain.Model.Common;
using RestaurantTimBaig.Models;
using RestaurantTimBaig.Security.Extensions;
using RestaurantTimBaig.ViewModels.Restaurants;

namespace RestaurantTimBaig.Controllers
{
    [Route("{controller}")]
    public class RestaurantsController : Controller
    {

        private readonly RestaurantDBContext _restaurantDBContext;

        public RestaurantsController(RestaurantDBContext restaurantDBContext)
        {
            _restaurantDBContext = restaurantDBContext ?? throw new ArgumentNullException(nameof(restaurantDBContext));
        }

        /// <summary>
        /// Вывод списка ресторанов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListRestaurants()
        {
            var restaurants = _restaurantDBContext.Restaurants
                .Select(x => new RestaurantViewModel
                {
                    Id = x.Id,
                    Name = x.RestaurantName,
                    Address = x.RestaurantAddress
                }).OrderByDescending(x => x.Name);               
            return View(restaurants.ToList());
        }

        /// <summary>
        /// Вывод ресторана по id
        /// </summary>
        /// <param name="idRestaurant"></param>
        /// <returns></returns>
        [HttpGet("RestaurantPage/{idRestaurant}")]
        public IActionResult RestaurantPage(long idRestaurant)
        {
            var restaurants = _restaurantDBContext.Restaurants.Include(r => r.Dishes)
                .Include(x => x.TableRestaurants)
                .Include(r => r.Comments)
                .ThenInclude(x => x.Employee)
                .Where(r => r.Id == idRestaurant)
                .Select(r => new RestaurantViewModel
                {
                    Id = r.Id,
                    Name = r.RestaurantName,
                    Address = r.RestaurantAddress,
                    Phone = r.RestaurantPhone,
                    Description = r.RestaurantDescription,
                    Email = r.RestaurantEmail,
                    Dishes = r.Dishes,
                    TableRestaurants = r.TableRestaurants,  
                    Comments = r.Comments,
                }).FirstOrDefault();
            return View(restaurants);
        }

        /// <summary>
        /// Добавления оценки ресторана пользователем
        /// </summary>
        [HttpGet("AddComment")]
        public IActionResult AddComment(long RestaurantId)
        {
            ViewData["id"] = RestaurantId;
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(NewCommentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = this.GetAuthorizedUser();

            var comment = new Comment
            {
                Restaurant = _restaurantDBContext.Restaurants.Where(r => r.Id == model.IdRestaurant).FirstOrDefault(),
                Employee = user.Employee,
                DateComment = DateTime.Now,
                Point = model.Point,
                DataComment = model.DataComment,
            };

            _restaurantDBContext.Comments.Add(comment);
            _restaurantDBContext.SaveChanges();
            return View();
        }
    }
}
