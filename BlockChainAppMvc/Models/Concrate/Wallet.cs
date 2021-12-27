using Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.BlockChain.Entities;
using Microsoft.EntityFrameworkCore;


namespace BlockChainAppMvc.Models
{
    public class Wallet : IEntity
    {
        public Wallet()
        {
            Blockchains = new List<Blockchain>();
        }
        public int walletId { get; set; }
        public decimal balance { get; set; }
        public int userId { get; set; }
        public bool toVerify { get; set; }
        public List<Blockchain> Blockchains { get; set; }
    }
}
