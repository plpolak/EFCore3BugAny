using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorNotMappedEF3
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Column("Description", Order = 2, TypeName = "nvarchar(80)")]
        [StringLength(80)]
        public string Description { get; set; }

        [Column("Description")]
        [NotMapped]
        public string TestDescription { get => Description; set { Description = value; } }

    }
}
