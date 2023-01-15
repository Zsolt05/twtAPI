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
        [RegularExpression("^.{3}-[0-9]{3}$")]//abc-123
        public string LincensePlate { get; set; }

        [Column("OwnerName")]
        [RegularExpression("^[a-z]{3,20} [a-z]{3,20}$")]
        public string OwnerName { get; set; }

        [Column("Power")]
        [MinLength(0)]
        [Description("Horse Power")]
        public int Power { get; set; }
    }
}
