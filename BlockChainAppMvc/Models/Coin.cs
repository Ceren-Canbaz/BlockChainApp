using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.Models
{
    public class Coin
    {
        public int id { get; set; }
        public string coinName { get; set; }
        public double coinValue { get; set; }
    }
}
