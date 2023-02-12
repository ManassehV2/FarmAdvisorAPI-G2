
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;
using Microsoft.EntityFrameworkCore;

namespace  FarmAdvisor.DataAccess.MSSQL.Implementations
{
     public   class   FarmRepositoryImpl  : GenericRepositoryImpl<FarmDto>, IFarmRepository
    {
        public  FarmAdvisorDbContext _context;
         public   FarmRepositoryImpl (FarmAdvisorDbContext context) :  base (context)
        {
            _context = context;
        }

        // get farm by userid
    
        public async ValueTask<FarmDto> GetFarmByUserId(Guid userId)
        {
            try{
                var farm = _context.Farms.Where(f => f.UserId == userId).Include("User").FirstOrDefault();
                return farm;
            }catch(Exception ex){
                throw ex;
            }
             
        }
        
    }
}