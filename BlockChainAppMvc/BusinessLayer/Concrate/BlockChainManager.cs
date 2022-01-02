using BlockChainAppMvc.BusinessLayer.Abstract;
using BlockChainAppMvc.DataAccessLayer.Abstract;
using BlockChainAppMvc.Models;
using Core.Entities.BlockChain.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAppMvc.BusinessLayer.Concrate
{
    public class BlockChainManager : IBlockChainService
    {
        private IBlockChainDao _blockChainDao;
        private IBlockDao _blockDao;

        public BlockChainManager(IBlockChainDao blockChainDao, IBlockDao blockDao)
        {
            _blockChainDao = blockChainDao;
            _blockDao = blockDao;
        }

        public IResult Add(Blockchain blockchain)
        {

            _blockChainDao.Add(blockchain);
            return new SuccessResult("başarıyla eklendi");
        }

        public IResult AddBlock(int blockId, decimal amount)
        {
            
            var latestBlock = _blockDao.Get(b => b.id == blockId);
            Block newBlock = new Block
            {
                PreviousHash = latestBlock.Hash,
                TimeStamp = DateTime.Now,
                Data = latestBlock.Data,
                blockChainId = latestBlock.blockChainId,
                coinAmount = amount,
            };
            newBlock.Hash = CalculateHash(newBlock);
            _blockDao.Add(newBlock);
            latestBlock.coinAmount -= amount;
            _blockDao.Update(latestBlock);
            return new SuccessDataResult<Block>(newBlock, "Başarıyla eklendi");

        }

        public string CalculateHash(Block block)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{block.TimeStamp}-{block.PreviousHash ?? ""}-{block.Data}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }

        public IResult Delete(Blockchain blockchain)
        {
            _blockChainDao.Delete(blockchain);
            return new SuccessResult("başarıyla silindi");
        }

        public IDataResult<List<Blockchain>> GetAll()
        {
            return new SuccessDataResult<List<Blockchain>>(_blockChainDao.getBlockchainsAll());
        }

        public IDataResult<Blockchain> GetById(int id)
        {
            return new SuccessDataResult<Blockchain>(_blockChainDao.Get(c => c.id == id));
        }

        public IDataResult<Blockchain> GetByWalletId(int walletId)
        {
            return new SuccessDataResult<Blockchain>(_blockChainDao.Get(c => c.walletId == walletId));
        }

        public IResult Update(Blockchain blockchain)
        {
            _blockChainDao.Update(blockchain);
            return new SuccessResult("başarıyla güncellendi");
        }
    }
}
