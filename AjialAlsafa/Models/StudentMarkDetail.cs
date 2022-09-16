using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjialAlsafa.Models
{
    public class StudentMarkDetail
    {
        public int id { get; set; }
      
        public int studentId { get; set; }
        public int determinerId { get; set; }
        public float mark { get; set; }

        public int studentMarkId { get; set; }
        public int yearId { get; set; }
        public int termId { get; set; }
        [Computed]
        public int createdAt { get; set; }
        public int createdBy { get; set; }
        [Computed]
        public int softDeleteState { get; set; }
        [Computed]
        public int softDeleteDate { get; set; }
    }
}