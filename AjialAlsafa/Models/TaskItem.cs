using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjialAlsafa.Models
{
    public class TaskItem
    {
        public string id { get; set; }
        public string guid { get; set; }
        public string taskContainerId { get; set; }
        public string taskItem { get; set; }
        public string sortNo { get; set; }
        [Computed]
        public string createdAt { get; set; }
        public string createdBy { get; set; }
        [Computed]
        public string softDeleteState { get; set; }
        [Computed]
        public string softDeleteDate { get; set; }
    }
}