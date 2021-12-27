using BlockChainAppMvc.Models;
using Core.Entities.BlockChain.Entities;
using Core.Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;

namespace BlockChainAppMvc.EntityFrameWorkConfig
{
    public class BlockChainAppContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SNC;Initial Catalog=BlockChainApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }



        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }


        public DbSet<Coin> Coins { get; set; }
<<<<<<< HEAD
		public DbSet<Wallet> Wallets { get; set; }
		public DbSet<Entities.DTOs.UserForLoginDto> UserForLoginDto { get; set; }
=======
        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<Blockchain> BlockChains { get; set; }
        public DbSet<Block> Blocks { get; set; }
>>>>>>> 27953fbcf963b8fe372397692ed6f9b8a216826a


    }
}

