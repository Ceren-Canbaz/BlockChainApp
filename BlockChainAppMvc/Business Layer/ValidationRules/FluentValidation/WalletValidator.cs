using BlockChainAppMvc.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.Business_Layer.ValidationRules.FluentValidation
{
    public class WalletValidator : AbstractValidator<Wallet>
    {
        public WalletValidator()
        {
            RuleFor(w => w.id).NotEmpty();
        }
    }
}
