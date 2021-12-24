using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using BlockChainAppMvc.Business_Layer.Abstract;
using BlockChainAppMvc.Business_Layer.Concrate;
using BlockChainAppMvc.DataAccessLayer.Abstract;
using BlockChainAppMvc.DataAccessLayer.Concrate.EntityFramework;
using Business.Abstract;
using Business.Concrate;
using Business.Concrete;
using BusinessLayer.Concrate;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.EntityFrameWork;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();

            builder.RegisterType<CoinManager>().As<ICoinService>().SingleInstance();
            builder.RegisterType<EfCoinDal>().As<ICoinDao>().SingleInstance();


            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDao>().SingleInstance();

            builder.RegisterType<WalletManager>().As<IWalletService>().SingleInstance();
            builder.RegisterType<EfWalletDal>().As<IWalletDao>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }


    }
}
