using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWD273_Final_Project_Revised.Models
{
    //Ticket Components
    public class Ticket
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Message")]
        public string message { get; set; }
        [Display(Name = "Time")]
        public DateTime submitTime { get; set; }
        [Display(Name = "Resolved")]
        public Boolean resolved { get; set; }
        [Display(Name = "Topic")]
        public int TopicID { get; set; }


        //Lazy Loading
        [ForeignKey("TopicID")]
        public virtual Topic Topic { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}