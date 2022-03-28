using University.Data.Models;

namespace University.BL.DTOs
{
    public enum Grade
    {
        A, B, C, D, E
    }
    public class EnrollmentDTO
    {
        public int EnrollmentId { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public Grade Grade { get; set; }

        public virtual CourseDTO Course { get; set; }

        public virtual StudentDTO Student { get; set; }
    }
}
