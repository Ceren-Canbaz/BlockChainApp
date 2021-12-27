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

namespace BlockChainAppMvc.BusinessLayer.Concrate
{
    public class BlockManager : IBlockService
    {

        private IBlockDao _blockDao;
        private IBlockChainDao _blockChainDao;

        public BlockManager(IBlockDao blockDao, IBlockChainDao blockChainDao)
        {
            _blockDao = blockDao;
            _blockChainDao = blockChainDao;
        }


        public IResult Delete(Block block)
        {
            _blockDao.Delete(block);
            return new SuccessResult("Başarıyla Block Silindi");
        }

        public IDataResult<List<Block>> GetAll()
        {
            return new SuccessDataResult<List<Block>>(_blockDao.GetAll());
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

        public IResult FirstAdd(Block block)
        {
            Block genesis = new Block
            {
                TimeStamp = DateTime.Now, //blockun olusturulma zamanını tutar
                PreviousHash = null, //önceki chaindeki bloğun hashini içerir
                Data = block.Data,
                Hash = "",//blockun özelliklerine göre hesaplanır ve olusturulur
            };
            genesis.Hash = CalculateHash(genesis);
            Blockchain genesisChain = new Blockchain();
            _blockChainDao.Add(genesisChain);
            genesis.blockChainId = genesisChain.id;
            _blockDao.Add(genesis);
            return new SuccessResult("Başarıyla Block Oluştu");
        }


    }
}
