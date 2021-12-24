using BlockChainAppMvc.Models;
using BlockChainAppMvc.Models.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.Business_Layer.Abstract
{
    public interface IWalletService
    {
        IDataResult<List<Wallet>> GetAll();
        IDataResult<Wallet> GetById(int walletId);
        IResult Add(Wallet wallet);
        IResult Delete(Wallet wallet);
        IResult Update(Wallet wallet);

        IDataResult<List<WalletDto>> GetAllDetails();
        IDataResult<List<WalletDto>> GetAllDetailsByUserId(int userId);
        IDataResult<List<WalletDto>> GetVerifiedDetailsByUserId(int userId);

        IResult VerifyWallet(Wallet wallet);

        IResult AddCoinToWallet();
        IDataResult<Wallet> GetByUserId(int userId);

    }
}
