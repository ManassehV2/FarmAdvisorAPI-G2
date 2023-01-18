
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FarmAdvisor.DataAccess.MSSQL.Test
{
     public  static class   UnitOfWorkGenerator 
    {
         public   static  IUnitOfWork Generate()
        {
            var options = new  DbContextOptionsBuilder<FarmAdvisorDbContext>()
                .UseInMemoryDatabase(databaseName:  "FarmAdvisor" )
                .Options;

             return new UnitOfWorkImpl (new FarmAdvisorDbContext(options));
        }
    }
}