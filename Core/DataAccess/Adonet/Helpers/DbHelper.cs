using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Core.Entities;

namespace Core.DataAccess.Adonet.Helpers
{
    public class DbHelper
    {
        public static List<T> CreateReadConnection<T>(string query) //generic hale getirdik
            where T : class, // Referans tip
            IEntity,
            new()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=localhost;Initial Catalog=Northwind;User=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return DataReaderMapToList<T>(reader);
        }

        //Reflection ile Generic
        public static List<T> DataReaderMapToList<T>(IDataReader dataReader)
            where T : class, // Referans tip
            IEntity,
            new()
        {
            List<T> list = new List<T>(); //ürün listesi
            T objectToMap = default(T); // ürün objesi
            while (dataReader.Read())
            {
                objectToMap = Activator.CreateInstance<T>(); // ürün ekleme
                foreach (PropertyInfo propertyInfo in objectToMap.GetType().GetProperties()) //type göre property ulaşmayı sağlar
                {
                    //veritabanındaki her şeyi maplememesi için
                    if (!Equals(dataReader[propertyInfo.Name], DBNull.Value)) //db ye göre null olma durumuna karşı, db de null mı değil mi ona göre karşılığını alıyoruz
                    {
                        propertyInfo.SetValue(objectToMap, dataReader[propertyInfo.Name], null); //datareader property info name alanında
                    }
                }

                list.Add(objectToMap);
            }

            return list;
        }

        public static int CreateWriteConnection<T>(string query, T entity)
            where T : class, // Referans tip
            IEntity,
            new()
        {
            SqlConnection connection =
                new SqlConnection(
                    connectionString:
                    @"Data Source=localhost;Initial Catalog=Northwind;User=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
            {
                string parameterName = $"@{propertyInfo.Name}";
                if (!query.Contains(parameterName)) continue;

                command.Parameters.AddWithValue(parameterName, value: propertyInfo.GetValue(entity));
            }

            int affectedRowCount = command.ExecuteNonQuery();
            connection.Close();
            return affectedRowCount;
        }
    }
}
