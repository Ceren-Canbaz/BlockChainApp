﻿using BlockChainAppMvc.Models;
using Core.Entities.Concrate;
using Microsoft.EntityFrameworkCore;

namespace BlockChainAppMvc.EntityFrameWorkConfig
{
    public class BockChainAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlockChainApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<Coin> Coins { get; set; }


    }
}

