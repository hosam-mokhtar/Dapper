using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperVsEfCore.Entities;
using Microsoft.Data.SqlClient;

namespace DapperVsEfCore.DapperManager
{
    public class ProductManager : IManager<Product>
    {
        private SqlConnection DbConnection = new SqlConnection("Server=.;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True");

        public bool Add(Product item)
        {
            try
            {
                return DbConnection.Execute("INSERT INTO Products" +
                      "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock," +
                      " UnitsOnOrder, ReorderLevel, Discontinued) VALUES (@ProductName,@SupplierID,@CategoryID, " +
                      "@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)"
                      , item) > 0;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(long id)
            => DbConnection.Execute("DeleteProductById",
                                    new { ProductId = id }, commandType: System.Data.CommandType.StoredProcedure
                                   ) > 0;


        public List<Product> GetAll()
            => DbConnection.Query<Product>("SelectAllProducts", commandType: System.Data.CommandType.StoredProcedure)
                           .ToList();

        public Product? GetById(long id)
                 => DbConnection.QueryFirstOrDefault<Product>("Select * From Products Where ProductId = @ProductId",
                     new
                     {
                         ProductId = id
                     });

        public bool Update(Product item)
         => DbConnection.Execute("ProductUpdateCommand", new
         {
             ProductName = item.ProductName,
             SupplierID = item.SupplierId,
             CategoryID = item.CategoryId,
             QuantityPerUnit = item.QuantityPerUnit,
             UnitPrice = item.UnitPrice,
             UnitsInStock = item.UnitsInStock,
             UnitsOnOrder = item.UnitsOnOrder,
             ReorderLevel = item.ReorderLevel,
             ProductID = item.ProductId,
             Discontinued = item.Discontinued
         }, commandType: System.Data.CommandType.StoredProcedure) > 0;
    }
}
