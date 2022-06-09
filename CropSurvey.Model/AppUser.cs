using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CropSurvey.Model
{
    public class AppUser : IdentityUser
    {
        [Range(1, 100)]
        public int? Age { get; set; }

        public bool? WantResults { get; set; }

        [ForeignKey(nameof(Gender))]
        public int? GenderID { get; set; }
        public Gender? Gender { get; set; }

        [ForeignKey(nameof(KnowledgeLevel))]
        public int? KnowledgeLevelID { get; set; }
        public KnowledgeLevel? KnowledgeLevel { get; set; }

        public virtual ICollection<Rating>? Ratings { get; set; }
    }
}
