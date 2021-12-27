using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;

namespace Core.Entities.BlockChain.Entities
{
    public class Block : IEntity
    {

        public int id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public string Data { get; set; }
        public int blockChainId { get; set; }

    }
}

