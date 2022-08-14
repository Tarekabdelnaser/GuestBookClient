using System.ComponentModel.DataAnnotations;

namespace GuestBookClient.Model
{
    public class GBUser
    {



        public string GBUName { get; set; } 

        [DataType(DataType.EmailAddress)]
        [Required]
        public string GBUEmail { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } 



    }
}
