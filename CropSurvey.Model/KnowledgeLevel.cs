﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropSurvey.Model
{
    public class KnowledgeLevel
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<AppUser>? Users { get; set; }
    }
}
