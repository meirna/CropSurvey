using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropSurvey.Model
{
    public class Photo
    {
        [Key]
        public string ID { get; set; }

        [ForeignKey(nameof(PhotoCategory))]
        public int CategoryID { get; set; }
        public PhotoCategory Category { get; set; }

        public virtual ICollection<Crop>? Crops { get; set; }
    }
}
