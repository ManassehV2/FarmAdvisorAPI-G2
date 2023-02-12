
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FarmAdvisor.DataAccess.MSSQL.Implementations
{
    public class FarmFeildRepositoryImpl : GenericRepositoryImpl<FarmFieldDto>, IFarmFeildRepository
    {
        public  FarmAdvisorDbContext _context;
        public FarmFeildRepositoryImpl(FarmAdvisorDbContext context) : base(context)
        {
            _context = context;
        }

        // get farmField by farmId
        
        

        public async ValueTask<IEnumerable<FarmFieldDto>> GetFarmFieldsByFarmId(Guid farmId)
        {
            try{
                var farmFields = _context.FarmFeilds.Where(f => f.FarmId == farmId).Include("Farm").ToList();
                return farmFields;
            }catch(Exception ex){
                throw ex;
            }
        }
    }
}