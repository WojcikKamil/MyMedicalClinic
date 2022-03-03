using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicAPIv1.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public ClinicUser ClinicUser { get; set; }
        public int ClinicUserId { get; set; }
    }
}