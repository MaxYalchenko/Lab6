using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    public class SubdivisionPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int subdivisionPlanId { get; set; }
        public DateTime subdivisionPlanDate { get; set; }
        public int subdivisionPlanIndex { get; set; }
        public int subdivisionId { get; set; }
        public Subdivision subdivision { get; set; }
    }
}
