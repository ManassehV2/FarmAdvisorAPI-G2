
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace  FarmAdvisor.DataAccess.MSSQL.Implementations
{
     public class UnitOfWorkImpl  : IUnitOfWork
    {
        private   readonly  FarmAdvisorDbContext _context;

        public IFarmRepository FarmRepository { get; private set; } 

        public IUserRepository UserRepository { get; private set; } 

        public ISensorRepository SensorRepository { get; private set; } 

        public IFarmFeildRepository FarmFeildRepository { get; private set; } 

        public INotificationRepository NotificationRepository { get; private set; }

        public ISensorResetDateRepository SensorResetDateRepository { get; private set; }
        
         public   UnitOfWorkImpl (FarmAdvisorDbContext context)
        {
            // var  connectionString = "Data Source=LAPTOP-7S5M2IVT;Initial Catalog=FarmAdvisor1;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            //
            // var options = new  DbContextOptionsBuilder<FarmAdvisorDbContext>()
            //     .UseSqlServer( connectionString!, options => options.EnableRetryOnFailure())
            //     .Options;

            _context = context;
            FarmRepository =  new   FarmRepositoryImpl (_context);
            UserRepository =  new   UserRepositoryImpl (_context);
            SensorRepository =  new   SensorRepositoryImpl (_context);
            FarmFeildRepository =  new   FarmFeildRepositoryImpl (_context);
            NotificationRepository =  new   NotificationRepositoryImpl (_context);
            SensorResetDateRepository =  new   SensorResetDateRepositoryImpl (_context);
        }

        

        public void DisposeContext ()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}