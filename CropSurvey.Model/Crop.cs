using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropSurvey.Model
{
    public class Crop
    {
        [Key]
        public string ID { get; set; }

        [ForeignKey(nameof(Photo))]
        public string PhotoID { get; set; }
        public Photo Photo { get; set; }

        public string AspectRatio { get; set; }

        public string Algorithm { get; set; }

        public double Timer { get; set; }
    }
}
