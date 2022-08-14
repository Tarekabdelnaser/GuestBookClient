using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestBookClient.Model
{
    public class LogTime
    {

        [ForeignKey("GBUser")]
        public int GBUSERID { get; set; }


        [DataType(DataType.Date)]
        public DateOnly LoginTime { set; get; }






    }
}
