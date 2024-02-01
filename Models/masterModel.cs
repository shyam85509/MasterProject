using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace coretask2.Models
{
    public class masterModel
    {
    }
    [Table("master_Task2")]
    public class Register
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Master Id Missing")]
        [Display(Name = "Master Id")]
        public int Maste_ID { get; set; }
        [Required(ErrorMessage = "Name Missing")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "email Missing")]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Missing")]
        public string password { get; set; }
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile Missing")]
        public string mobile { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender Missing")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Age Missing")]
        [Display(Name = "Age")]
        public Byte age { get; set; }
        [Required(ErrorMessage = "Department Missing")]
        [Display(Name = "Department")]
        public string department { get; set; }
        [Required(ErrorMessage = "Nationality Missing")]
        [Display(Name = "Nationality")]
        public string nationality { get; set; }
        [Required(ErrorMessage = "Status Missing")]
        [Display(Name = "Status")]
        public Boolean status { get; set; }

    }

    public class Login
    {
        [Required(ErrorMessage = "email Missing")]
        [Display(Name = "Enter Email")]
        public string? email { get; set; }
        [Display(Name = "Enter Password")]
        [Required(ErrorMessage = "Password Missing")]
        public string? password { get; set; }
    }
}
