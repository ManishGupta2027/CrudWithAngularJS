using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWithAngularJS.Data
{
	public interface IDataFactory
	{
		DataFactoryDBDataContext DataFactoryDBDataContext();

	}
}