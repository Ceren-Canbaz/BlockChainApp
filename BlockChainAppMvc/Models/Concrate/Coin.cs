﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.Models
{
    public class Coin : IEntity
    {
        public int id { get; set; }
        public string coinName { get; set; }
        public decimal coinValue { get; set; }
        public decimal changePerDay { get; set; }


    }
}
