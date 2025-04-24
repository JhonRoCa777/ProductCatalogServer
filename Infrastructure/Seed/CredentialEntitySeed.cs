using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Model.EnumsModel;
using ProductCatalog.Infrastructure.Adapters.Entity;

namespace ProductCatalog.Infrastructure.Seed
{
    public class CredentialEntitySeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CredentialEntity>().HasData(
                new CredentialEntity { ID = 1, Email = "admin@gmail.com", Password = "admin123", Role = RolesDTO.ADMIN },
                new CredentialEntity { ID = 2, Email = "client@gmail.com", Password = "client123", Role = RolesDTO.CLIENT }
            );
        }
    }
}
