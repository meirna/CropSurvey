using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropSurvey.Model
{
    public class PhotoCategory
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Photo>? Photos { get; set; }
    }
}
