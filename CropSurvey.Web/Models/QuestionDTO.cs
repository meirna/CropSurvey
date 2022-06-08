using System.ComponentModel.DataAnnotations;
using CropSurvey.Model;

namespace CropSurvey.Web.Models
{
    public class QuestionDTO
    {
        public int QuestionID { get; set; }

        public string Original { get; set; }

        public string CropA { get; set; }

        public string CropB { get; set; }

        [Range(1, 5, ErrorMessage = "Obavezno odabrati")]
        public int ValueA { get; set; }

        [Range(1, 5, ErrorMessage = "Obavezno odabrati")]
        public int ValueB { get; set; }
    }
}
