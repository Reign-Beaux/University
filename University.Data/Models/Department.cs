﻿namespace University.Data.Models
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int InstructorId { get; set; }

        public virtual Instructor? Instructor { get; set; }
    }
}
