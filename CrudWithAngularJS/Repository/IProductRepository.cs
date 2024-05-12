using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudWithAngularJS.Models;

namespace CrudWithAngularJS.Repository
{
	public interface IProductRepository
	{
		bool SaveProduct(Product product);
		List<Product> GetProductList(int currentPage, int pageSize, string search);
		Response UpsertProduct(Product product);
		Product GetProductListById(int id);
		bool DeleteProduct(int id);
	}
}
