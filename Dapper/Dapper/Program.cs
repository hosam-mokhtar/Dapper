using Dapper_Demo;
using Dapper_Demo.Entities;
using Microsoft.Data.SqlClient;

namespace Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dapper => ORM => Micro ORM => Light Weight ORM 
            // DbConnection => Extension 
            // Dapper Syntax =>  SqlQuery
            // Query => Reterive Data  , Execute => Add , Update , Delete 
            // SqlConnection 
            
            //Connection to Database
            //SqlConnection connection = new SqlConnection("Server =.;Database=Northwind;Trusted_Connection=True; TrustServerCertificate=True");

            #region Query
            //var result = connection.Query<Product>("Select * From Products");

            //foreach (var product in result)
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            //Stored Procedure
            //var products = connection.Query<Product>("SelectAllProducts", commandType: System.Data.CommandType.StoredProcedure);

            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}
            #endregion

            #region Execute
            //Actions (Add , Update , Delete)

            //Update
            //if (connection.Execute("Update Products set ProductName = @ProductName where ProductId = @ProductId",
            //new
            //{
            //    ProductId = 1,
            //    ProductName = "Ice Tea"
            //}) > 0)
            //    Console.WriteLine("Done");
            //else
            //    Console.WriteLine("Failed");

            //Stored Procedure
            //int x = connection.Execute("UpdateProductNameByProductID", new
            //{
            //    ProductId = 1,
            //    ProductName = "Tea"
            //}, commandType: System.Data.CommandType.StoredProcedure);

            //if (x > 0)
            //    Console.WriteLine("Done");
            //else
            //    Console.WriteLine("Failed");
            #endregion

            #region CRUD
            ProductManager manager = new ProductManager();

            #region Add
            //Product product = new Product()
            //{
            //    ProductName = "IceMocha",
            //    SupplierId = 1,
            //    CategoryId = 1,
            //    QuantityPerUnit = "20 g",
            //    UnitPrice = 10,
            //    UnitsInStock = 15,
            //    UnitsOnOrder = 10,
            //    ReorderLevel = 20
            //};

            //Console.WriteLine(manager.Add(product));
            #endregion

            #region Get All
            //var products = manager.GetAll().Count;
            //Console.WriteLine(products);

            //var products = manager.GetAll();
            //foreach (var item in products)
            //{
            //    Console.WriteLine(item.ProductName);
            //}
            #endregion

            #region Get Product By Id
            //var product = manager.GetById(90);
            //Console.WriteLine(product?.ProductName);
            #endregion

            #region Update Product 
            //var product = manager.GetById(90);
            //Console.WriteLine(product?.ProductName);

            //if (product is not null)
            //{
            //    product.ProductName = "Ice Latte";
            //    manager.Update(product);
            //    Console.WriteLine(product.ProductName);
            //}
            #endregion

            #region Delete Product
            //manager.Delete(88);
            //Console.WriteLine(manager.Delete(88));
            #endregion

            #endregion
        }
    }
}
