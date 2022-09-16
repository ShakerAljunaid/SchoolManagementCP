using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjialAlsafa.Models
{
    public class Student
    {
        public int id { get; set; }
        public int accountId { get; set; }
        public string code { get; set; }
        public int schoolId { get; set; }
        public int termId { get; set; }
        public int yearId { get; set; }
        public int branchId { get; set; }
        public int classId { get; set; }
        public int gradeId { get; set; }
        public int parentAccountId { get; set; }
        public int status { get; set; }=1;
        public string notes { get; set; }
        [Computed]
        public string createAt { get; set; }

        [Computed]
        public string name { get; set; }
        [Computed]
        public string className { get; set; }
        [Computed]
        public string gradeName { get; set; }
        [Computed]
        public string branchName { get; set; }
        [Computed]
        public string yearName { get; set; } = "";
        [Computed]
        public string termName { get; set; } = "";
        [Computed]
        public string schoolName { get; set; } = "";




        public int createdBy { get; set; }

    }
}