using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebWellsMVC.WellDb.DbModels
{
    [Table("Wells")]
    public class Wells
    {
        [Key]
        public int UWI { get; set; }
        public string Name { get; set; }
        public string Bush { get; set; }
        public string Type { get; set; }
        public string OpMethod { get; set; }
        public string Stage { get; set; }
        public DateTime Date { get; set; }

    }
}

