using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    public class SubdivisionFact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int subdivisionFactId { get; set; }
        public DateTime subdivisionFactDate { get; set; }
        public int subdivisionFactIndex { get; set; }
        public int subdivisionId { get; set; }
        public Subdivision subdivision { get; set; }
    }
}
