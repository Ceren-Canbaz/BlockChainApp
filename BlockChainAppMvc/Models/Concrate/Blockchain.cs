using System;
using System.Collections.Generic;
using System.Text;
using BlockChainAppMvc.Models;

namespace Core.Entities.BlockChain.Entities
{
    public class Blockchain : IEntity
    {


        public Blockchain()
        {
            Blocks = new List<Block>();
        }

        public int id { get; set; }

        public List<Block> Blocks { get; set; }
        public int walletId { get; set; }

    }
}
