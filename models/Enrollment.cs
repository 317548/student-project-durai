﻿using enrollment.models;

namespace enrollment.models
{
    public class Enrollment
    {
        public int Id{ get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Courses courses { get; set; }

    }
}

