
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace  FarmAdvisor.DataAccess.MSSQL.Implementations
{
     public   class   NotificationRepositoryImpl  : GenericRepositoryImpl<NotificationDto>, INotificationRepository
    {
         public   NotificationRepositoryImpl (FarmAdvisorDbContext context) :  base (context)
        {
        }
    }
}