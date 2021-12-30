using BlockChainAppMvc.BusinessLayer.Abstract;
using BlockChainAppMvc.DataAccessLayer.Abstract;
using Core.Entities.BlockChain.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BlockChainAppMvc.Models;
using DataAccess.Abstract;

namespace BlockChainAppMvc.BusinessLayer.Concrate
{
    public class BlockManager : IBlockService
    {
        private ICoinDao _coinDao;
        private IBlockDao _blockDao;
        private IBlockChainDao _blockChainDao;

        public BlockManager(IBlockDao blockDao, IBlockChainDao blockChainDao, ICoinDao coinDao)
        {
            _blockDao = blockDao;
            _blockChainDao = blockChainDao;
            _coinDao = coinDao;
        }


        public IResult Delete(Block block)
        {
            _blockDao.Delete(block);
            return new SuccessResult("Başarıyla Block Silindi");
        }

        public IDataResult<List<Block>> GetAll()
        {
            return new SuccessDataResult<List<Block>>(_blockDao.getWalletWithCoin());
        }

        public IDataResult<Block> GetById(int blockId)
        {
            return new SuccessDataResult<Block>(_blockDao.Get(b => b.id == blockId));
        }

        public IResult Update(Block block)
        {
            _blockDao.Update(block);
            return new SuccessResult("Başarıyla Güncellendi");
        }

        public string CalculateHash(Block block)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{block.TimeStamp}-{block.PreviousHash ?? ""}-{block.Data}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }

        public IResult FirstAddCoin(string data, decimal value)
        {
            Block genesis = new Block
            {
                TimeStamp = DateTime.Now, //blockun olusturulma zamanını tutar
                PreviousHash = null, //önceki chaindeki bloğun hashini içerir
                Data = data,
                Hash = "",//blockun özelliklerine göre hesaplanır ve olusturulur,

            };
            genesis.Hash = CalculateHash(genesis);
            Blockchain genesisChain = new Blockchain
            {

            };
            _blockChainDao.Add(genesisChain);
            genesis.blockChainId = genesisChain.id;
            _blockDao.Add(genesis);
            _coinDao.Add(new Coin()
            {
                blockChainId = genesis.blockChainId,
                blockId = genesis.id,
                coinName = genesis.Data,
                coinValue = value

            });
            return new SuccessResult("Başarıyla Block Oluştu");
        }

        public IResult AddCoin(int blockId)
        {
            var latestBlock = _blockDao.Get(b => b.id == blockId - 1);
            Block newBlock = new Block
            {
                PreviousHash = latestBlock.PreviousHash,
                TimeStamp = DateTime.Now,
                Data = latestBlock.Data,
                blockChainId = latestBlock.blockChainId
            };
            newBlock.Hash = CalculateHash(newBlock);
            _blockDao.Add(newBlock);
            return new SuccessResult("Başarıyla eklendi");

        }
    }
}
