using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ForUserRegistration.Models
{
    public class PropertyMortgage
    {
        [Key]
        public int PropertyId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LandOwnerName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string PropertyType { get; set; }
        [Required]
        public int PercentageMortgaged { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string BankMortgaging { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string NatureOfDeeds { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Registered { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Volume { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Number { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public int Page { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string PlanNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(16)")]
        public string ReceiptNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FileReference { get; set; }
        [Required]
        [Column(TypeName = "varchar(16)")]
        public string SerialNumber { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string FilePath { get; set; }


    }
}
