using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Dapper;
using DapperVsEfCore.Context;
using Microsoft.EntityFrameworkCore;

namespace DapperVsEfCore
{
    public class BenchmarkDapperVsEfcore
    {
        NorthWindDbContext dbContext = new NorthWindDbContext();
        DbConnection dbconnection;

        public BenchmarkDapperVsEfcore()
        {
            dbconnection = dbContext.Database.GetDbConnection();
        }

        [Benchmark]
        public void DapperExample()
        {
            var products = dbconnection.Query("SelectAllProducts", commandType: System.Data.CommandType.StoredProcedure)
                                       .ToList();
            Console.WriteLine(products.Count);
        }

        [Benchmark]
        public void EFCoreExample()
        {
            dbContext.Products.Load();

            Console.WriteLine(dbContext.Products.Local.Count);
        }
    }
}
