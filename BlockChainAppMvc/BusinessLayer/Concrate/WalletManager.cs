using BlockChainAppMvc.Business_Layer.Abstract;
using BlockChainAppMvc.Business_Layer.ValidationRules.FluentValidation;
using BlockChainAppMvc.DataAccessLayer.Abstract;
using BlockChainAppMvc.Models;
using BlockChainAppMvc.Models.DTOs;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.Business_Layer.Concrate
{

    public class WalletManager : IWalletService
    {
        private IWalletDao _walletDal;

        public WalletManager(IWalletDao walletDal)
        {
            _walletDal = walletDal;
        }

        [ValidationAspect(typeof(WalletValidator))]
        [CacheRemoveAspect("IWalletService.Get")]
        public IResult Add(Wallet wallet)
        {
            _walletDal.Add(wallet);
            return new SuccessResult(message: "Wallet Created");
        }

        [CacheRemoveAspect("IWalletService.Get")]
        public IResult Delete(Wallet wallet)
        {
            _walletDal.Delete(wallet);
            return new SuccessResult(message: "Wallet Deleted");
        }

        [CacheAspect(10)]
        public IDataResult<List<Wallet>> GetAll()
        {
            return new SuccessDataResult<List<Wallet>>(_walletDal.geTWalletsCoin());
        }

        [CacheAspect(10)]
        public IDataResult<List<WalletDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<WalletDto>>(_walletDal.getAllWalletDtos());
        }


        [CacheAspect(10)]
        public IDataResult<List<WalletDto>> GetAllDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<WalletDto>>(_walletDal.getAllWalletDtos(w => w.UserId == userId));
        }


        [CacheAspect(10)]
        public IDataResult<Wallet> GetById(int walletId)
        {
            return new SuccessDataResult<Wallet>(_walletDal.Get(w => w.id == walletId));
        }


        public IResult AddCoinToWallet()
        {
            return new SuccessResult();
        }

        [CacheAspect(10)]
        public IDataResult<Wallet> GetByUserId(int userId)
        {
            return new SuccessDataResult<Wallet>(_walletDal.Get(w => w.userId == userId));
        }

        public IDataResult<List<WalletDto>> GetVerifiedDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<WalletDto>>(_walletDal.getAllWalletDtos(w => w.ToVerify == true && w.UserId == userId));
        }

        public IResult Update(Wallet wallet)
        {
            _walletDal.Update(wallet);
            return new SuccessResult(message: "Wallet Updated");
        }

        [ValidationAspect(typeof(WalletValidator))]
        [CacheRemoveAspect("IWalletService.Get")]
        public IResult VerifyWallet(Wallet wallet)
        {

            _walletDal.Update(wallet);
            return new SuccessResult("Wallet Verified");
        }
    }
}
