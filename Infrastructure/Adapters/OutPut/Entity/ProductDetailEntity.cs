using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Infrastructure.Adapters.Out.Entity
{
    [Table("ProductDetails")]
    public class ProductDetailEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [StringLength(60)]
        public string Type { get; set; } = string.Empty;

        [StringLength(255)]
        public string Info { get; set; } = string.Empty;

        [Required]
        public long ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual ProductEntity? Product { get; set; }
    }
}
