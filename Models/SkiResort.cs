using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class SkiResort
    {
        [Key]
        public int Id { get; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(50)]
        public string Terrain { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
        
        [NotMapped]
        public ICollection<Period> Forecasts { get; set; }
    }
}