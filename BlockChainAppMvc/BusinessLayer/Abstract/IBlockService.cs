using Core.Entities.BlockChain.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.BusinessLayer.Abstract
{
    public interface IBlockService
    {
        IDataResult<List<Block>> GetAll();
        IDataResult<Block> GetById(int blockId);
        IResult FirstAddCoin(string data, decimal value);
        IResult Delete(Block block);
        IResult Update(Block block);
    }
}
