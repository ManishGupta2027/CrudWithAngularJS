using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace CrudWithAngularJS.Models
{
	public class Product
	{
		[JsonPropertyName("id")]
		public int? Id { get; set; }

		[JsonPropertyName("title")]
		public string Title { get; set; }

		[JsonPropertyName("stockCode")]
		public string StockCode { get; set; }

		[JsonPropertyName("price")]
		public decimal Price { get; set; }

		[JsonPropertyName("category")]
		public string Category { get; set; }

		[JsonPropertyName("gender")]
		public string Gender { get; set; }

		[JsonPropertyName("isActive")]
		public bool IsActive { get; set; }

		[JsonPropertyName("currentPage")]
		public int CurrentPage { get; set; }

		[JsonPropertyName("pageSize")]
		public int PageSize { get; set; }

		[JsonPropertyName("totalRecords")]
		public int TotalRecords { get; set; }

		[JsonPropertyName("created")]
		public DateTime? Created { get; set; }
	}
}