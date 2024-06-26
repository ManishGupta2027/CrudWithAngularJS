﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web.Mvc;
using CrudWithAngularJS.Helper;
using CrudWithAngularJS.Models;
using CrudWithAngularJS.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CrudWithAngularJS.Controllers
{
	public class ProductController : Controller
    {
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		//public ActionResult GetProductList()
		//{
		//	var res = _productService.GetProductList();

		//	return View(res);
		//}


		public ActionResult GetProductList(int? page,string search)
		{
			var products = new List<Product>();
			int currentPage = (page ?? 1); // If no page number is specified, default to the first page
			int pageSize = 2; // Number of items per page

			// Retrieve the list of users from your repository
			 products = _productService.GetProductList(currentPage, pageSize, search);
			if (!products.Any())
			{
				return View(products);
			}
			// Get the total number of users
			int? totalProductsCount = products.FirstOrDefault()?.TotalRecords;

			// Calculate the total number of pages
			int totalPages = (int)Math.Ceiling((double)totalProductsCount / pageSize);

			// Pass necessary pagination information to the view
			ViewBag.TotalPages = totalPages;
			ViewBag.CurrentPage = currentPage;

			// Calculate the range of products displayed on the current page
			int startRecord = (currentPage - 1) * pageSize + 1;
			int endRecord = Math.Min(currentPage * pageSize, (int)totalProductsCount);

			ViewBag.StartRecord = startRecord;
			ViewBag.EndRecord = endRecord;

			ViewBag.TotalRecords = totalProductsCount;
			return View(products);
		}
		public JsonResult GetProductList1(int? page, string search)
		{
			var products = new List<Product>();
			int currentPage = (page ?? 1); // If no page number is specified, default to the first page
			int pageSize = 2; // Number of items per page

			// Retrieve the list of users from your repository
			products = _productService.GetProductList(currentPage, pageSize, search);
			if (!products.Any())
			{
				return  Json(products, JsonRequestBehavior.AllowGet);
			}
			// Get the total number of users
			int? totalProductsCount = products.FirstOrDefault()?.TotalRecords;

			// Calculate the total number of pages
			int totalPages = (int)Math.Ceiling((double)totalProductsCount / pageSize);

			// Pass necessary pagination information to the view
			ViewBag.TotalPages = totalPages;
			ViewBag.CurrentPage = currentPage;

			// Calculate the range of products displayed on the current page
			int startRecord = (currentPage - 1) * pageSize + 1;
			int endRecord = Math.Min(currentPage * pageSize, (int)totalProductsCount);

			ViewBag.StartRecord = startRecord;
			ViewBag.EndRecord = endRecord;

			ViewBag.TotalRecords = totalProductsCount;
			var res =Json(products, JsonRequestBehavior.AllowGet);
			var res11 = JsonConvert.SerializeObject(products);
			// Define custom JsonSerializerSettings if needed
			var settings = new JsonSerializerSettings
			{
				// Customize settings if needed, e.g., formatting, converters, etc.
				Formatting = Formatting.Indented
			};
			var settingws = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				Converters = new JsonConverter[]
				{
					new StringEnumConverter(),
				},
				StringEscapeHandling = StringEscapeHandling.EscapeHtml
			};
			var t6 = JsonConvert.SerializeObject(products, settingws);
			var res2 = JsonConvert.DeserializeObject<List<Product>>(res11, settings);

			return Json(t6, JsonRequestBehavior.AllowGet);
		}
		//public ActionResult GetProductsear(int? page, string search)
		//{
		//	int currentPage = (page ?? 1); // If no page number is specified, default to the first page
		//	int pageSize = 5; // Number of items per page

		//	// Retrieve the list of users from your repository
		//	var products = _productService.GetProductList(currentPage, pageSize, search);

		//	// Get the total number of users
		//	int totalProductsCount = products.FirstOrDefault().TotalRecords;

		//	// Calculate the total number of pages
		//	int totalPages = (int)Math.Ceiling((double)totalProductsCount / pageSize);

		//	// Pass necessary pagination information to the view
		//	ViewBag.TotalPages = totalPages;
		//	ViewBag.CurrentPage = currentPage;
		//	return View("GetProductList", products);
		//}

		public ActionResult NewProduct()
		{
			return View();
		}

		[HttpPost]
		public JsonResult NewProduct(Product product)
		{
			var result = _productService.UpsertProduct(product);
			return Json(result, JsonRequestBehavior.AllowGet);

		}

		[HttpPost]
		public JsonResult UpsertProduct(Product product)
		{

			var result = _productService.UpsertProduct(product);
			return Json(result, JsonRequestBehavior.AllowGet);

		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var product = _productService.GetProductListById(id);
			if (product == null)
			{
				return HttpNotFound(); // Or some other appropriate action
			}
			return View(product);
		}



		[HttpGet]
		public ActionResult Delete(int id)
		{
			var result = _productService.DeleteProduct(id);
			if (result)
			{
				// Optionally, you can redirect to a success page or refresh the user list
				return RedirectToAction("GetProductList");
			}
			// Optionally handle the case where delete fails
			return RedirectToAction("GetProductList");
		}
		public ActionResult NewProductSuccess()
		{
			return View();
		}
	}
}