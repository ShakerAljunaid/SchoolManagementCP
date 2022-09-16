using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjialAlsafa.Models
{
    public class GeneralComponent
    {
        public int id { get; set; }
       public string arbicTitle { get; set; }
        public string englishTitle { get; set; } = "";
        public int componentTypeId { get; set; }
        public int parentId { get; set; } = 0;
        public int schoolId { get; set; } = 1;
        [Computed]
        public string createdAt { get; set; }
        public string createdBy { get; set; }
        [Computed]
        public string softDeleteState { get; set; }
        [Computed]
        public string softDeleteDate { get; set; }
    }
}