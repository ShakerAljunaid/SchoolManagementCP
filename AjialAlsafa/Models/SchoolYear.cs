using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjialAlsafa.Models
{
    public class SchoolYear
    {
        public int id { get; set; }
        public string yearTitle { get; set; }
        public string yearSlogan { get; set; }
        public int schoolId { get; set; }
        public string startsOn { get; set; }
        public string endsOn { get; set; }
        public int currentStatus { get; set; }
        [Computed]
        public string createdAt { get; set; }
        public int createdBy { get; set; }
        [Computed]
        public int softDeleteState { get; set; }
        [Computed]
        public string softDeleteDate { get; set; }
    }
}