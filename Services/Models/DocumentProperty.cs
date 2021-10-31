using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Models
{
    public class DocumentProperty: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("DocumentId")]
        public Document Document { get; set; }
        public string Product { get; set; }
        public string Supplier { get; set; }
    }
}