using Core.DataAccess.Adonet.Helpers;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Concretes.Adonet
{
    public class AdoProductDal : IProductDal
    {
        public List<Product> GetAll()
        {
            List<Product> _products = DbHelper.CreateReadConnection<Product>("Select * from products");

            return _products;
        }
    }
}
