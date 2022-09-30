using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Adonet.Helpers
{
    public class DbHelper
    {
        public static List<T> CreateReadConnection<T>(string query) //generic hale getirdik
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return DataReaderMapToList<T>(reader);
        }

        //Reflection ile Generic
        public static List<T> DataReaderMapToList<T>(IDataReader dataReader)
        {
            List<T> list = new List<T>(); //ürün listesi
            T objectToMap = default(T); // ürün objesi
            while (dataReader.Read())
            {
                objectToMap = Activator.CreateInstance<T>(); // ürün ekleme
                foreach (PropertyInfo propertyInfo in objectToMap.GetType().GetProperties()) //type göre property ulaşmayı sağlar
                {
                    //veritabanındaki her şeyi maplememesi için
                    if (!object.Equals(dataReader[propertyInfo.Name], DBNull.Value)) //db ye göre null olma durumuna karşı, db de null mı değil mi ona göre karşılığını alıyoruz
                    {
                        propertyInfo.SetValue(objectToMap, dataReader[propertyInfo.Name], null); //datareader property info name alanında
                    }
                }

                list.Add(objectToMap);
            }

            return list;
        }
    }
}
