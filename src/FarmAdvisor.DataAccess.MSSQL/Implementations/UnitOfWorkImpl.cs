
using FarmAdvisor.DataAccess.MSSQL.Abstractions;

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
            _context = context;
            FarmRepository =  new   FarmRepositoryImpl (context);
            UserRepository =  new   UserRepositoryImpl (context);
            SensorRepository =  new   SensorRepositoryImpl (context);
            FarmFeildRepository =  new   FarmFeildRepositoryImpl (context);
            NotificationRepository =  new   NotificationRepositoryImpl (context);
            SensorResetDateRepository =  new   SensorResetDateRepositoryImpl (context);
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