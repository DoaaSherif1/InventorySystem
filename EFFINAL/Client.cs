namespace EFFINAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Client_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Client_Name { get; set; }

        public int Telephone { get; set; }

        public int Mobile { get; set; }

        [Required]
        [StringLength(50)]
        public string Fax { get; set; }

        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        [Required]
        [StringLength(50)]
        public string Website { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
