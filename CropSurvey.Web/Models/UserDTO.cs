namespace CropSurvey.Web.Models
{
    public class UserDTO
    {
        public string UserID { get; set; }

        public string UserName { get; set; }

        public bool? WantResults { get; set; }

        public int RatingCount { get; set; }
    }
}
