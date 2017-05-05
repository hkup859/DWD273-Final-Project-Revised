using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWD273_Final_Project_Revised.Models
{
    public class Comment
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Comment")]
        public string message { get; set; }
        public String time { get; set; }
        [Display(Name = "Topic")]
        public string relatedTopic { get; set; }
        public int TicketID { get; set; }


        //Lazy Loading

        [ForeignKey("TicketID")]
        public virtual Ticket Ticket { get; set; }
    }
}