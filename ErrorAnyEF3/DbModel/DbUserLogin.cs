// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by a tool.
//      Semanta Modeler (version 6.5.2.5281)
//      Copyrights © 1995-2019 by COAS Software Systems B.V.
// 
//      Class DbUserLogin
//      Entity implementation for object UserLogin.
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable 1591

namespace ErrorAnyEF3.DbModel
{

    /// <summary>
    /// Specifies users which login to the application
    /// </summary>
    [Table("UserLogin", Schema = "security")]
    public partial class DbUserLogin
    {

        public DbUserLogin()
        {
        }

        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column("Id", Order = 1, TypeName = "int")]
        public int Id { get; set; }

        /// <summary>
        /// Specifies the UPN of the (Azure) Active Directory user.
        /// </summary>
        [Required]
        [Column("UserPrincipalName", Order = 2, TypeName = "nvarchar(80)")]
        [StringLength(80)]
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// The display name of the user
        /// </summary>
        [Required]
        [Column("DisplayName", Order = 3, TypeName = "nvarchar(80)")]
        [StringLength(80)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Specifies whether the user account is still active (can 
        /// login).
        /// </summary>
        [Required]
        [Column("IsActive", Order = 4, TypeName = "bit")]
        public bool IsActive { get; set; }

        /// <summary>
        /// A free field to add remarks on the record
        /// </summary>
        [Column("Remarks", Order = 5, TypeName = "nvarchar(500)")]
        [StringLength(500)]
        public string Remarks { get; set; }

        /// <summary>
        /// For use in Avatar
        /// </summary>
        [Required]
        [Column("Initials", Order = 6, TypeName = "nvarchar(3)")]
        [StringLength(3)]
        public string Initials { get; set; }

        [InverseProperty(nameof(DbCIR.CreatedByUserLogin))]
        public virtual ICollection<DbCIR> CreatedCIRs { get; set; }

        [InverseProperty(nameof(DbCIR.ModifiedByUserLogin))]
        public virtual ICollection<DbCIR> ModifiedCIRs { get; set; }

        [InverseProperty(nameof(DbEntityType.CreatedByUserLogin))]
        public virtual ICollection<DbEntityType> CreatedEntityTypes { get; set; }

        [InverseProperty(nameof(DbEntityType.ModifiedByUserLogin))]
        public virtual ICollection<DbEntityType> ModifiedEntityTypes { get; set; }

        [InverseProperty(nameof(DbEntity.CreatedByUserLogin))]
        public virtual ICollection<DbEntity> CreatedEntities { get; set; }

        [InverseProperty(nameof(DbEntity.ModifiedByUserLogin))]
        public virtual ICollection<DbEntity> ModifiedEntities { get; set; }

    }

}
