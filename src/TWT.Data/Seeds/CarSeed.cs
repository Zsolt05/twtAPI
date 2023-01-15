using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TWT.Data.Models;

namespace TWT.Data.Seeds
{
    public class CarSeed : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData
            (
                new Car
                {
                    LincensePlate = "ABC-123",
                    OwnerName = "Erős Pista",
                    Power = 100
                },
                new Car
                {
                    LincensePlate = "KIS-111",
                    OwnerName = "Kis Jani",
                    Power = 60
                },
                new Car
                {
                    LincensePlate = "BIG-999",
                    OwnerName = "Nagy Karcsi",
                    Power = 300
                },
                new Car
                {
                    LincensePlate = "BZS-150",
                    OwnerName = "Bali Zsolt",
                    Power = 155
                },
                new Car
                {
                    LincensePlate = "BZS-300",
                    OwnerName = "Bali Zsolt",
                    Power = 300
                }
            );
        }
    }
}
