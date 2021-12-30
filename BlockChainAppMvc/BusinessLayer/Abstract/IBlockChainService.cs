using Core.Entities.BlockChain.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.BusinessLayer.Abstract
{
    public interface IBlockChainService
    {
        IDataResult<List<Blockchain>> GetAll();
        IDataResult<Blockchain> GetById(int blockChainId);
        IResult Add(Blockchain blockchain);
        IResult AddBlock(int blockId , decimal amount);
        IResult Delete(Blockchain blockchain);
        IResult Update(Blockchain blockchain);
    }
}
