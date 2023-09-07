using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarServices>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<RentalManager>().As<IRentalServices>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();
            builder.RegisterType<UserManager>().As<IUserServices>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<CarImageManager>().As<ICarImageServices>();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
