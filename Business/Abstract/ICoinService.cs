using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using BlockChainAppMvc.Models;
using Core.Utilities.Results;

namespace Business.Abstract
{
	interface ICoinService
	{
		IDataResult<List<Coin>> getAll();
		IDataResult<Category> GetById(int categoryId);
		IResult Add(Category category);
		IResult Delete(Category category);
		IResult Update(Category category);
	}
}
