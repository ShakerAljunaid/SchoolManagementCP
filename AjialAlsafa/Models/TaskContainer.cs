using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjialAlsafa.Models
{
    public class TaskContainer
    {
        public string id { get; set; }
        public string classId { get; set; }
        public string gradeId { get; set; }
        public string teacherId { get; set; }
        public string subjectId { get; set; }
        public string taskName { get; set; }
        public string taskTypeId { get; set; }
        [Computed]
        public string createdAt { get; set; }
        public string createdBy { get; set; }
        [Computed]
        public string softDeleteState { get; set; }
        [Computed]
        public string softDeleteDate { get; set; }
    }
}