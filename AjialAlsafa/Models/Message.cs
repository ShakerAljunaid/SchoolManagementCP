using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjialAlsafa.Models
{
    public class Message
    {
        public int id { get; set; }
        [Computed]
        public object guid { get; set; }
        public int gradeId { get; set; }
        public int classId { get; set; }
        public int branchId { get; set; }
        public int yearId { get; set; }
        public int schoolId { get; set; }
        public int termId { get; set; }
        public int typeId { get; set; }
        public string title { get; set; }
        public string content { get; set; }

        [Computed]
        public string sendingDate { get; set; }

        public string senderName { get; set; }
        public int senderId { get; set; }
        public int receiverId { get; set; }
        [Computed]
        public string CreatedAt { get; set; }
       
        public int CreatedBy { get; set; }
        [Computed]
        public int softDeleteState { get; set; }
    }
}