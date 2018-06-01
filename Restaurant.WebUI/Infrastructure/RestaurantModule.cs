using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Modules;
using Ninject.Web.Common;
using Restaurant.Domain.Abstract.Repository;
using Restaurant.Domain.Concrete;
using Restaurant.Domain.Concrete.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restaurant.WebUI.Infrastructure
{
    public class RestaurantModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<EFRestaurantDbContext>().InRequestScope();
            Bind<IEFDishRepository>().To<EFDishRepository>().InRequestScope();
            Bind<IEFMenuCategoryRepository>().To<EFMenuCategoryRepository>().InRequestScope();
            Bind<IEFGalleryRepository>().To<EFGalleryRepository>().InRequestScope();
            Bind<IEFReservationRepository>().To<EFReservationRepository>().InRequestScope();
        }
    }
}