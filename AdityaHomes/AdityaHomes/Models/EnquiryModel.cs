using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace AdityaHomes.Models
{
    public class EnquiryModel
    {
        [Key]
        public int enquiryID { get; set; }
        [Required]
        [Display(Name="Name")]
        public string name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Enquiry Message")]
        [StringLength(400)]
        public string message { get; set; }        
        public string status { get; set; }        
        public DateTime enquiryDate { get; set; }                
        public string reply { get; set; }        
        public DateTime replyDate { get; set; }
    }
    public class AHdbContext : DbContext
    {
                    
            public DbSet<EnquiryModel> Enquiries { get; set; }



            
    }
}