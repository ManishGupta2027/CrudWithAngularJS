﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace CrudWithAngularJS.Data
{
	public class DataFactory : IDataFactory
	{
		static MappingSource _sharedMappingSource = new AttributeMappingSource();
		string _connectionString;
		public DataFactoryDBDataContext DataFactoryDBDataContext()
		{
			_connectionString = ConfigurationManager.ConnectionStrings["CRUDConnectionString"].ConnectionString;
			return new DataFactoryDBDataContext(_connectionString, _sharedMappingSource);
		}
	}
}