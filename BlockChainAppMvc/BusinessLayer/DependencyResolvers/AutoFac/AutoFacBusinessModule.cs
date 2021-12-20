using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;

using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

//using Core.Utilities.Interceptors;
//using Core.Utilities.Security.Jwt;
//using DataAccess.Abstract;
//using DataAccess.Concrate.EntityFramework;
//using DataAccess.Concrate.EntityFrameWork;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            //builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();




            //builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();
            //builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();

            //builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            //builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();




            //builder.RegisterType<AuthManager>().As<IAuthService>();
            //builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }


    }
}
