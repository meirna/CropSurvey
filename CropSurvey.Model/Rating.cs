using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropSurvey.Model
{
    public class Rating
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(AppUser))]
        public string UserID { get; set; }
        public AppUser? User { get; set; }

        [ForeignKey(nameof(Crop))]
        public string CropID { get; set; }
        public Crop? Crop { get; set; }

        public int Value { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}
