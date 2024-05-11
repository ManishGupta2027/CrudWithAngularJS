using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudWithAngularJS.Data;
using CrudWithAngularJS.Models;

namespace CrudWithAngularJS.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly IDataFactory _dataFactory;
		private readonly DataFactoryDBDataContext _dataFactoryDBDataContext;
		public ProductRepository(IDataFactory dataFactory, DataFactoryDBDataContext dataFactoryDBDataContext)
		{
			_dataFactory = dataFactory;
			_dataFactoryDBDataContext = _dataFactory.DataFactoryDBDataContext();
		}



		public List<Product> GetProductList(int currentPage, int pageSize,string search)
		{
			var dbResp = _dataFactoryDBDataContext.procGetProductList_20240511(currentPage, pageSize, search);
			var Product = (from o in dbResp
						   select new Product
						   {
							   Title = o.Title,
							   StockCode = o.StockCode,
							   Price = (decimal)o.Price,
							   Category = o.Category,
							   Id = o.id,
							   Gender = o.Gender,
							   IsActive = o.IsActive.HasValue ? o.IsActive.Value : false, // Convert bit to bool
							   TotalRecords = (int)o.TotalRecords,
							   CurrentPage = currentPage,
							   PageSize = pageSize,
							   Created = o.Created
						   }).ToList();
			return Product;

		}
		public Product GetProductListById(int id)
		{
			var dbResp = _dataFactoryDBDataContext.procGetProductDetail_20240420(id);
			var product = (from o in dbResp
						   select new Product
						   {
							   Title = o.Title,
							   StockCode = o.StockCode,
							   Price = (decimal)o.Price,
							   Category = o.Category,
							   Id = o.id,
							   Gender = o.Gender,
							   IsActive = (bool)(o.IsActive ?? false), // Handling null value for IsActive field
						   }).FirstOrDefault();
			return product;
		}

		public Response UpsertProduct(Product product)
		{
			var a = new Response();
			if (product.Id != null)
			{
				// Check if the new StockCode is the same as the existing StockCode
				var existingProduct = GetProductListById((int)product.Id);
				if (existingProduct == null)
				{
					return a;
				}

				if (existingProduct.StockCode != product.StockCode)
				{
					return a;
				}
			}




			var res = _dataFactoryDBDataContext.procUpsertProduct_20240504(product.Id, product.Title, product.StockCode, product.Price, product.Category, product.Gender, product.IsActive);
			a = (from o in res
				 select new Response
				 {
					 isValid = o.isValid,
					 Message = o.Message,
				 }).FirstOrDefault();

			//var isValid = res.FirstOrDefault()?.isValid;
			return a;
		}
		public bool DeleteProduct(int id)
		{
			// Implement logic to delete user from the database
			var dbResp = _dataFactoryDBDataContext.procDeleteProduct_15042024(id);
			var isValid = dbResp.FirstOrDefault()?.isValid;
			return isValid ?? false;
		}
		public bool SaveProduct(Product product)
		{
			var res = _dataFactoryDBDataContext.procSaveProduct_19042024(product.Title, product.StockCode, product.Price, product.Category, product.Gender, product.IsActive);
			var isValid = res.FirstOrDefault().isValid;
			return (bool)isValid;
		}
	}
}