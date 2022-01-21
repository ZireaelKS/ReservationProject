using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantTimBaig.Domain.Model;
using RestaurantTimBaig.Domain.Model.Common;

namespace RestaurantTimBaig.Domain.DB
{
    public class RestaurantDBContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="options"></param>
        public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Пользователи
        /// </summary>
        public override DbSet<User> Users { get; set; }

        /// <summary>
        /// Посетители
        /// </summary>
        public DbSet<Employee> Employees { get; private set; }

        /// <summary>
        /// Комментарий посетителя
        /// </summary>
        public DbSet<Comment> Comments { get; private set; }

        /// <summary>
        /// Ресторан
        /// </summary>
        public DbSet<Restaurant> Restaurants { get; private set; }

        /// <summary>
        /// Меню
        /// </summary>
        public DbSet<Dish> Dishes { get; private set; }

        /// <summary>
        /// Бронирование
        /// </summary>
        public DbSet<Reservation> Reservations { get; private set; }

        /// <summary>
        /// Столики ресторана
        /// </summary>
        public DbSet<TableRestaurant> TablesRestaurant { get; private set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region User

            modelBuilder.Entity<User>(x =>
            {
                x.HasOne(y => y.Employee)
                .WithOne()
                .HasForeignKey<User>("EmployeeId")
                .IsRequired(true);
                x.HasIndex("EmployeeId").IsUnique(true);
            });

            #endregion 

            #region Restaurant

            modelBuilder.Entity<Restaurant>(rest =>
            {
                rest.ToTable("Restaurants");
                rest.HasMany<Comment>(rest => rest.Comments).WithOne(com => com.Restaurant);
            });

            #endregion

            #region Employee

            modelBuilder.Entity<Employee>(emp =>
            {
                emp.ToTable("Employees");
                emp.Ignore(emp => emp.FullName);
            });

            #endregion

            #region Comment
            modelBuilder.Entity<Comment>(com =>
            {
                com.ToTable("Comments");
                com.HasOne(com => com.Restaurant).WithMany(rest => rest.Comments).OnDelete(DeleteBehavior.Cascade);
                com.HasOne(com => com.Employee);
            });
            
            #endregion

            #region Dish
            modelBuilder.Entity<Dish>(dish =>
            {
                dish.ToTable("Dishes");
                dish.HasOne(dish => dish.Restaurant).WithMany(rest => rest.Dishes).OnDelete(DeleteBehavior.Cascade);
            });

            #endregion

            #region Reservation
            modelBuilder.Entity<Reservation>(reserv =>
            {
                reserv.ToTable("Reservations");
                reserv.HasOne(reserv => reserv.Restaurant).WithMany(rest => rest.Reservations).OnDelete(DeleteBehavior.Cascade);
                reserv.HasOne(reserv => reserv.Employee).WithMany(emp => emp.Reservations).OnDelete(DeleteBehavior.Cascade);
            });

            #endregion

            #region TableRestaurant
            modelBuilder.Entity<TableRestaurant>(table =>
            {
                table.ToTable("TablesRestaurant");
                table.HasOne(table => table.Restaurant).WithMany(rest => rest.TableRestaurants).OnDelete(DeleteBehavior.Cascade);                
            });

            #endregion
        }
    }
}
