using BlockChainAppMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.ViewModels
{
    public class CoinWalletModel
    {
        public List<Coin> Coins { get; set; }
        public Wallet Wallets { get; set; }
        
    }
}
