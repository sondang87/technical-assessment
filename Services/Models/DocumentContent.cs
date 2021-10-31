using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Models
{
    public class DocumentContent: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DocumentContentId { get; set; }
        public string Location { get; set; }
        public string FileName { get; set; }
        public string Ext { get; set; }
        public decimal FileSize { get; set; }
    }
}
