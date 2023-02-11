// using FarmAdvisor.DataAccess.MSSQL.Abstractions;
// using FarmAdvisor.DataAccess.MSSQL.Dtos;



// namespace FarmAdvisor.DataAccess.MSSQL.Test
// {
//     public class UnitTestNotificationdRepository
//     {

//         private readonly IUnitOfWork UnitOfWork;
//         public UnitTestNotificationdRepository()
//         {
//             UnitOfWork = UnitOfWorkGenerator.Generate();
//         }

        

//         [Fact]
//         public async void AddNotification_Success_Test()
//         {
//             Utils.clearDatabase(UnitOfWork);
//             var notification = DtoGenerator.GenerateNotificationDto();
//             var farm = DtoGenerator.GenerateFarmDto();
            
//             farm.Notifications!.Add(notification);
//             await UnitOfWork.FarmRepository.AddAsync(farm);

//             var farmResult = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
//             var notificationResult = await UnitOfWork.NotificationRepository.GetByIdAsync(notification.NotificationId);
//             UnitOfWork.DisposeContext();

//             Assert.NotNull(farmResult);
//             Assert.NotNull(notificationResult);
//             Assert.Single(farmResult.Notifications!);
//             Assert.Equal(notificationResult, farmResult.Notifications![0]);


//         }

//         [Fact]
//         public async void GetNotificationById_Success_Test()
//         {

//             Utils.clearDatabase(UnitOfWork);
//             var farm = DtoGenerator.GenerateFarmDto();
//             var notification = DtoGenerator.GenerateNotificationDto();

//             farm.Notifications!.Add(notification);
//             await UnitOfWork.FarmRepository.AddAsync(farm);
//             var result = await UnitOfWork.NotificationRepository.GetByIdAsync(notification.NotificationId);
//             UnitOfWork.DisposeContext();
            
//             Assert.Equal(notification.Farm, farm);
//             Assert.Equal(notification.FarmId, farm.FarmId);
//         }


//         [Fact]
//         public async void GetAllNotifications_Success_Test()
//         {
//             Utils.clearDatabase(UnitOfWork);

//             // populate database
//             int numberOfNotifications = 10;

//             var farm = DtoGenerator.GenerateFarmDto();
//             foreach(int i in Enumerable.Range(0, numberOfNotifications))
//             {
//                 var notification = DtoGenerator.GenerateNotificationDto();
//                 farm.Notifications!.Add(notification);
                
//             }
//             await UnitOfWork.FarmRepository.AddAsync(farm);

//             // test GetAll
//             var result = await UnitOfWork.NotificationRepository.GetAllAsync();

//             // clean database
//             Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
//             var notificationsAfterDelete = await UnitOfWork.NotificationRepository.GetAllAsync();
//             UnitOfWork.DisposeContext();
//             Assert.Empty(notificationsAfterDelete);
//             Assert.Equal(numberOfNotifications, result.Count);
            
//         }


//         [Fact]
//         public async void UpdateNotification_Success_Test()
//         {
//             Utils.clearDatabase(UnitOfWork);

//             var farm = DtoGenerator.GenerateFarmDto();
//             var notification = DtoGenerator.GenerateNotificationDto();
//             farm.Notifications!.Add(notification);
//             await UnitOfWork.FarmRepository.AddAsync(farm);

//             notification.Farm = farm;
//             notification.FarmId = farm.FarmId;
//             notification.Message = "new message";

            
//             await UnitOfWork.NotificationRepository.UpdateAsync(notification);
//             var resultAfterUpdate = await UnitOfWork.NotificationRepository.GetByIdAsync(notification.NotificationId);
//             Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);

//             UnitOfWork.DisposeContext();
//             Assert.Equal(notification.Message, resultAfterUpdate!.Message);
              
//         }


//         [Fact]
//         public async void DeleteFarmFeild_Success_Test()
//         {
//             Utils.clearDatabase(UnitOfWork);

//             var farm = DtoGenerator.GenerateFarmDto();
//             var notification = DtoGenerator.GenerateNotificationDto();
//             farm.Notifications!.Add(notification);
//             await UnitOfWork.FarmRepository.AddAsync(farm);

            

//             var resultBeforeDelete = await UnitOfWork.NotificationRepository.GetByIdAsync(notification.NotificationId);

//             await UnitOfWork.NotificationRepository.DeleteAsync(resultBeforeDelete!);
//             var resultAfterDelete = await UnitOfWork.FarmRepository.GetByIdAsync(farm.UserId);
//             var farmAfterDelete = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
//             Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
//             UnitOfWork.DisposeContext();

//             Assert.NotNull(resultBeforeDelete);
//             Assert.Null(resultAfterDelete);
//             Assert.Empty(farmAfterDelete!.Notifications!);
            
//         }

//         [Fact]
//         public async void Relation_Success_Test()
//         {
//             Utils.clearDatabase(UnitOfWork);
//             var farm = DtoGenerator.GenerateFarmDto();
//             var notification = DtoGenerator.GenerateNotificationDto();
//             farm.Notifications!.Add(notification);
//             await UnitOfWork.FarmRepository.AddAsync(farm);
            

//             var farmResult = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
//             var notificationResult = await UnitOfWork.NotificationRepository.GetByIdAsync(notification.NotificationId);
//             Assert.NotNull(farmResult);
//             Assert.Single(farmResult.Notifications!);
//             Assert.Equal(notificationResult, farmResult.Notifications![0]);

//             await UnitOfWork.FarmRepository.DeleteAsync(farmResult!);
//             var notificationResultAfterDelete = await UnitOfWork.NotificationRepository.GetByIdAsync(notification.NotificationId);
//             UnitOfWork.DisposeContext();

//             Assert.Null(notificationResultAfterDelete);


//         }

        

        
//     }
// }