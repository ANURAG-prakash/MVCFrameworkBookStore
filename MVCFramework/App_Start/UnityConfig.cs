using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MVCFramework
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUserBL, UserBL>();
            container.RegisterType<IBookBL, BookBL>();
            container.RegisterType<IUserRL, UserRL>();
            container.RegisterType<IBookRL, BookRL>();
            container.RegisterType<ICartRL, CartRL>();
            container.RegisterType<ICartBL, CartBL>();
            container.RegisterType<IWishlistRL, WishlistRL>();
            container.RegisterType<IWishlistBL, WishlistBL>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}