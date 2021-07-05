using System.Web.Mvc;
using BusinessLayer.Interface;
using BusinessLayer.Services;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using Unity;
using Unity.Mvc5;

namespace BookStore
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
            container.RegisterType<IUserRL, UserRL>();
            container.RegisterType<IBooksBL, BooksBL>();
            container.RegisterType<IBooksRL, BooksRL>();
            container.RegisterType<ICartBL, CartBL>();
            container.RegisterType<ICartRL, CartRL>();
            container.RegisterType<IWishListBL, WishListBL>();
            container.RegisterType<IWishListRL, WishListRL>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}