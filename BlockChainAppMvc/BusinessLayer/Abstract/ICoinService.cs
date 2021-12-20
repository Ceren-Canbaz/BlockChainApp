using System;
using System.Collections.Generic;
using System.Text;
using BlockChainAppMvc.Models;
using Core.Utilities.Results;

namespace Business.Abstract
{
	public interface ICoinService
	{
        IDataResult<List<Coin>> GetAll();
        IDataResult<Coin> GetById(int coinId);
        IResult Add(Coin coin);
        IResult Delete(Coin coin);
        IResult Update(Coin coin);
    }
}
