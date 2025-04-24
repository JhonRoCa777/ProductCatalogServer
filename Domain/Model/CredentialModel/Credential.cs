using ProductCatalog.Domain.Model.EnumsModel;

namespace ProductCatalog.Domain.Model.CredentialModel
{
    public sealed class Credential
    {
        public long ID { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public RolesDTO Role { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
