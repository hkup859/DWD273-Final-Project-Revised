using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWD273_Final_Project_Revised.Models
{
    //Topic Components
    public class Topic
    {
        public int ID { get; set; }
        [Display(Name = "Topic")]
        public string TopicDesc { get; set; }
    }
}