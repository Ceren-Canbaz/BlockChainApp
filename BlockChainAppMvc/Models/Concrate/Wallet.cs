using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.Models
{
    public class Wallet : IEntity
    {

        //Coinler listesini oluştur.

        //Coin işlemleri eklenecek.

        //Chaine dahil edilecek.

        public Wallet()
        {
            Coins = new List<Coin>();
        }

        public int id { get; set; }
        public decimal balance { get; set; }
        public int userId { get; set; }

        public List<Coin> Coins { get; set; }
        public bool toVerify { get; set; }
    }
}
