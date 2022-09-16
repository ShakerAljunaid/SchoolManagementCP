using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjialAlsafa.Models
{
    public class StudentMark
    {
        public int id { get; set; }
        public int markTypeId { get; set; }
        [Computed]
        public string markTypeName { get; set; }
        [Computed]
        public string subjectName { get; set; }
        public float markValue { get; set; }
        public int studentId { get; set; }
        public int subjectId { get; set; }
        public int classId { get; set; }
        public int gradeId { get; set; }
        public int schoolId { get; set; }
        public int roundId { get; set; }
        public int termId { get; set; }
        public int yearId { get; set; }
        public string notes { get; set; }
        [Computed]
        public string createdAt { get; set; }
        public int createdBy { get; set; }
        [Computed]
        public int softDeleteState { get; set; }
        [Computed]
        public string softDeleteDate { get; set; }
    }
}