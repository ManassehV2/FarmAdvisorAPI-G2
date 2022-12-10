using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmAdvisor.DataAccess.MSSQL.Abstractions
{
    public interface IUnitOfWork
    {
        IFarmRepository FarmRepository { get; }
        IUserRepository UserRepository { get; }
        ISensorRepository SensorRepository { get; }
        IFarmFeildRepository FarmFeildRepository { get; }
        INotificationRepository NotificationRepository { get; }
        ISensorResetDateRepository SensorResetDateRepository { get; }

        int SaveChanges();
        void DisposeContext();

        
        
    }
}
