using BlockChainAppMvc.DataAccessLayer.Abstract;
using BlockChainAppMvc.Models;
using Business.Abstract;
using Core.Entities;
using Core.Entities.Concrate;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrate
{
    class CoinManager : ICoinService
    {
        //ALT KATMANIN İNTERFACE İ !!!
        private ICoinDao _coinDao;

        public CoinManager(ICoinDao coinDao)
        {
            _coinDao = coinDao;
        }

        public IResult Add(Coin coin)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Coin coin)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Coin>> GetAll()
        {
            return new SuccessDataResult<List<Coin>>(_coinDao.GetAll(), "Coins Listed !");
        }

        public IDataResult<Coin> GetById(int coinId)
        {
            return new SuccessDataResult<Coin>(_coinDao.Get(c => c.coinId == coinId));
        }

        public IResult Update(Coin coin)
        {
            throw new NotImplementedException();
        }
    }
}
