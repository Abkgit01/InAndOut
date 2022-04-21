
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InAndOut.Models
{
    public class MyExpenses 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Expenses { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Amount can only be +ve") ]
        public int Amount{ get; set; }

        [DisplayName("Expenses Type")]
        public int ExpensesTypeId { get; set; }
        [ForeignKey("ExpensesTypeId")]

        public virtual ExpensesType ExpensesType { get; set; }
    }
}
