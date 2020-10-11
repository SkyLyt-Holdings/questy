using System;
using System.ComponentModel.DataAnnotations;

namespace Questy.Domain.Entities
{
    public class UserBuild : Entity
    {
        public int UserID { get; set; }

        public int ArchetypeID { get; set; }

        [Required]
        public int WeightPercentage { get; set; }

        public int Experience { get; set; }

        public Archetype Archetype { get; set; }      
        
        public Weight Weight { get; set; }

        public double CalculateLevel()
        {
            return Math.Truncate(((Math.Sqrt(625 + (100 * Experience)) - 25) / 50) + 1);
        }
    }
}
