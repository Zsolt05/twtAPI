using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TWT.Data.Models
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        [Column("LincensePlate")]
        [RegularExpression("^[A-Z a-z]{3}-[0-9]{3}$")]//abc-123
        public string LincensePlate { get; set; }

        [Column("OwnerName")]
        [RegularExpression("^[a-z A-Z]{3,20} [a-z A-Z]{3,20}$")]
        public string OwnerName { get; set; }

        [Range(1,double.MaxValue)]
        [Column("Power")]
        public int Power { get; set; }
    }
}
