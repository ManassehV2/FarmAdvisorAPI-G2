using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public class SensorResetDateDto
    {

        public SensorResetDateDto(Guid sensorId,DateTime timeStamp)
        {
            ResetDateId = Guid.NewGuid();
            TimeStamp = timeStamp;
            SensorId = sensorId;
        }
        [Key]
        public Guid ResetDateId { get; set; }
        public DateTime TimeStamp { get; set;}


        [ForeignKey("SensorDto")]
        public Guid SensorId { get; set; }
        public SensorDto? Sensor { get; set; }


        
        
    }
}