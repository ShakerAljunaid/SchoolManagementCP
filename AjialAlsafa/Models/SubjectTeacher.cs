using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjialAlsafa.Models
{
    public class SubjectTeacher
    {
        public int id { get; set; }
    
        public int accountId { get; set; }
        [Computed]
        public string teacherName { get; set; }
        public int classId { get; set; }
        public int gradeId { get; set; }
        public int schoolId { get; set; } = 1;
        public int subjectId { get; set; }
        [Computed]
        public string subjectName { get; set; }
        public int yearId { get; set; }
        public int termId { get; set; }
        public int status { get; set; } = 1;
        public string notes { get; set; } = "";
        [Computed]
        public int createdAt { get; set; }
        public int createdBy { get; set; }
        [Computed]
        public int softDeleteState { get; set; }
        [Computed]
        public int softDeleteDate { get; set; }
    }
}