using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper_Demo.Entities;
using Microsoft.Data.SqlClient;

namespace Dapper_Demo
{
    public class ProductManager : IManager<Product>
    {
        SqlConnection dbConnection = new SqlConnection("Server=.; Database=Northwind; Trusted_Connection=True; TrustServerCertificate=True");

        public bool Add(Product item)
        {
            try
            {
                return dbConnection.Execute("INSERT INTO Products" +
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
        => dbConnection.Execute("DeleteProductById", new { ProductId = id }, commandType: System.Data.CommandType.StoredProcedure) > 0;

        public List<Product> GetAll()
         => dbConnection.Query<Product>("SelectAllProducts", commandType: System.Data.CommandType.StoredProcedure)
                        .ToList();

        public Product? GetById(long id)
        => dbConnection.QueryFirstOrDefault<Product>("Select * From Products Where ProductId = @ProductId",
            new
            {
                ProductId = id
            });

        public bool Update(Product item)
        => dbConnection.Execute("ProductUpdateCommand", new
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
