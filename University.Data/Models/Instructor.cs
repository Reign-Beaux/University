namespace University.Data.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            CourseInstructors = new HashSet<CourseInstructor>();
            Departments = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime? HireDate { get; set; }

        public virtual OfficeAssignment OfficeAssignment { get; set; } = null!;
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
