using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using CrudWithAngularJS.Models;

namespace CrudWithAngularJS.Helper
{
	public static class JavaScriptHelper
	{
		public static IHtmlString Json(this HtmlHelper helper, object obj)
		{
			var settings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				Converters = new JsonConverter[]
				{
					new StringEnumConverter(),
				},
				StringEscapeHandling = StringEscapeHandling.EscapeHtml
			};

			return MvcHtmlString.Create(JsonConvert.SerializeObject(obj, settings));
		}
		// Method to convert a model to JSON string with camelCase property names
		public static string ConvertToJson(object model)
		{
			// Configure JsonSerializerSettings to use camelCase for property names
			var settings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};

			// Serialize the model object to JSON string with camelCase property names
			string json = JsonConvert.SerializeObject(model, settings);

			return json;
		}
		// Method to convert an object model and return an object with keys in camelCase
		public static JToken ConvertToCamelCaseObject(object model)
		{
			// Configure JsonSerializerSettings to use camelCase for property names
			var settings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};

			// Serialize the model object to JSON string with camelCase property names
			string json = JsonConvert.SerializeObject(model, settings);

			// Deserialize the JSON string back to a JToken
			JToken camelCaseToken = JsonConvert.DeserializeObject<JToken>(json);

			return camelCaseToken;
		}
		public static JsonResult ConvertAndReturnJson(string jsonString)
		{
			// Deserialize JSON string to List<Product>
			var products = JsonConvert.DeserializeObject<List<Product>>(jsonString);

			// Convert list to JSON with camelCase property names
			var camelCaseJson = ConvertToJson(products);

			return new JsonResult
			{
				Data = camelCaseJson,
				JsonRequestBehavior = JsonRequestBehavior.AllowGet
			};
		}

	}
	
}