using Restaurant.Domain.Concrete;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Restaurant.Domain.Concrete
{
    public class EFRestaurantSampleData : DropCreateDatabaseIfModelChanges<EFRestaurantDbContext>
    {
        protected override void Seed(EFRestaurantDbContext context)
        {
            IList<MenuCategory> categories = new List<MenuCategory>
            {
                new MenuCategory { Name="Breakfast", Position=1 },
                new MenuCategory { Name="Lunch", Position=2 },
                new MenuCategory { Name="Dinner", Position=3 }
            };

            context.MenuCategories.AddRange(categories);

            IList<Gallery> gallery = new List<Gallery>
            {
                new Gallery { Position=1, Image=File.ReadAllBytes(
                    HostingEnvironment.MapPath(@"/Content/ExampleImages/korean-cuisine-1280_853.jpg")), ImageMimeType="image/pjpeg" },
                new Gallery { Position=2, Image=File.ReadAllBytes(
                    HostingEnvironment.MapPath(@"/Content/ExampleImages/mozzarella1280_853.jpg")), ImageMimeType="image/pjpeg" },
                new Gallery { Position=3, Image=File.ReadAllBytes(
                    HostingEnvironment.MapPath(@"/Content/ExampleImages/red-wine-2443699_1920.jpg")), ImageMimeType="image/pjpeg" },
                new Gallery { Position=4, Image=File.ReadAllBytes(
                    HostingEnvironment.MapPath(@"/Content/ExampleImages/tomato1280_853.jpg")), ImageMimeType="image/pjpeg" },
                new Gallery { Position=5, Image=File.ReadAllBytes(
                    HostingEnvironment.MapPath(@"/Content/Images/eat-1920_1280.jpg")), ImageMimeType="image/pjpeg" },
                new Gallery { Position=6, Image=File.ReadAllBytes(
                    HostingEnvironment.MapPath(@"/Content/Images/mozzarella1280_853.jpg")), ImageMimeType="image/pjpeg" }
            };

            context.Gallery.AddRange(gallery);

            IList<Dish> dishes = new List<Dish>
            {
                new Dish { Position = 1, Name="Phasellus commodo ipsum in purus.", Price=12.50M, PhotoMimeType="image/pjpeg",
                           Photo=File.ReadAllBytes(HostingEnvironment.MapPath(@"/Content/Images/fries-1280_596.jpg")),
                           MenuCategory = categories[0], Description="Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos." },
                new Dish { Position = 2, Name="Nam pharetra odio arcu, ac.", Price=25.22M, PhotoMimeType="image/pjpeg",
                           Photo=File.ReadAllBytes(HostingEnvironment.MapPath(@"/Content/Images/korean-cuisine-1280_853.jpg")),
                           MenuCategory = categories[0], Description="Donec auctor ex erat. Aenean hendrerit arcu id faucibus maximus. Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                new Dish { Position = 3, Name="Ut condimentum mauris libero, et.", Price=12.50M, PhotoMimeType="image/pjpeg",
                           Photo=File.ReadAllBytes(HostingEnvironment.MapPath(@"/Content/Images/tomato1280_853.jpg")),
                           MenuCategory = categories[0], Description="Maecenas volutpat sapien lacus." },

                new Dish { Position = 4, Name="Duis rhoncus ipsum leo, non.", Price=9.00M, PhotoMimeType="image/pjpeg",
                           Photo=File.ReadAllBytes(HostingEnvironment.MapPath(@"/Content/Images/food-2373414_1920.jpg")),
                           MenuCategory =categories[1], Description="" },
                new Dish { Position = 5, Name="Nam sed ultricies tellus. Aenean.", Price=13.55M,PhotoMimeType="image/pjpeg",
                           Photo=File.ReadAllBytes(HostingEnvironment.MapPath(@"/Content/Images/tomato1280_853.jpg")),
                           MenuCategory =categories[1], Description="" },
                new Dish { Position = 6, Name="Duis dapibus luctus quam, quis.", Price=10.50M,PhotoMimeType="image/pjpeg",
                           Photo=File.ReadAllBytes(HostingEnvironment.MapPath(@"/Content/Images/tomato1280_853.jpg")), MenuCategory=categories[1], Description="" },

                new Dish { Position = 7, Name="Phasellus nec imperdiet purus. Maecenas. ", Price=32.20M,
                           Photo=null, MenuCategory=categories[2], Description="Suspendisse non dignissim ligula." },
                new Dish { Position = 8, Name="Morbi sit amet euismod ligula.", Price=50.00M,
                           Photo=null, MenuCategory=categories[2], Description="Cras ornare interdum pretium. Quisque lobortis tristique est, nec ultricies leo vestibulum id." },
                new Dish { Position = 9, Name="Fusce maximus sit amet tellus.", Price=120.20M,
                           Photo=null, MenuCategory=categories[2], Description="Donec laoreet velit elit, a fermentum metus ultrices ut. " }
            };

            context.Dishes.AddRange(dishes);

            IList<Reservation> reservations = new List<Reservation>
            {
                new Reservation { Name="Jan Nowak", PhoneNumber="543 233 155", Email="nowak@fake.com",
                                  NumberOfGuests = 2, Term=new DateTime(2017,8,1,10,0,0) },
                new Reservation { Name="Paweł Kowalski", PhoneNumber="513 033 305", Email="kowalski@fake.com",
                                  NumberOfGuests = 1, Term=new DateTime(2017,8,3,20,0,0) },
                new Reservation { Name="Tomasz Ziemkiewicz", PhoneNumber="743 403 990", Email="ziemk@fake.com",
                                  NumberOfGuests = 4, Term=new DateTime(2017,8,11,17,0,0) }
            };

            context.Reservations.AddRange(reservations);

            base.Seed(context);
        }
    }
}
