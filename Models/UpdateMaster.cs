using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace coretask2.Models
{
        [Table("master_Task2")]
    public class UpdateMaster
    {

        
            public int Id { get; set; }
            [Display(Name = "Master Id")]
            public int Maste_ID { get; set; }
            [Display(Name = "Name")]
            public string Name { get; set; }
            [Display(Name = "Email")]
            public string email { get; set; }
            [Display(Name = "Password")]
            public string password { get; set; }
            [Display(Name = "Mobile Number")]
            public string mobile { get; set; }
            [Display(Name = "Gender")]
            public string gender { get; set; }
            [Display(Name = "Age")]
            public Byte age { get; set; }
            [Display(Name = "Department")]
            public string department { get; set; }
            [Display(Name = "Nationality")]
            public string nationality { get; set; }
            [Display(Name = "Status")]
            public Boolean status { get; set; }
        }
    
}
