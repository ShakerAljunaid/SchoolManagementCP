using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjialAlsafa.Models
{
    public class ExamTable
    {
        public int id { get; set; }
        public int roundId { get; set; }
        public int termId { get; set; }
        public int yearId { get; set; }
        public int classId { get; set; }
        public int gradeId { get; set; }
        public int branchId { get; set; }
        public int schoolId { get; set; }
        public int subjectId { get; set; }
        [Computed]
        public string subjectName { get; set; }
        public string dueDate { get; set; }
        public string requirements { get; set; }
        [Computed]
        public string createdAt { get; set; }
        public int createdBy { get; set; }
        [Computed]
        public int softDeleteState { get; set; }
        [Computed]
        public string softDeleteDate { get; set; }
    }
}