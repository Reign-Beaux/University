using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        [Required]
        [StringLength(50)]
        public DateTime EnrollmentDate { get; set; }

        public string FullName
        {
            get { return string.Format($"{LastName} {FirstMidName}"); }
        }
    }
}
