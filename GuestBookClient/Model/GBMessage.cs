using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestBookClient.Model
{
    public class GBMessage
    {
        [Key]
        public int MessageID { get; set; }
        public string MessageText { get; set; }

        [ForeignKey("GBUser")]
        public int GBUSERIDFrom { get; set; }

        public string ReplayOnMessage { get; set; }


        [ForeignKey("GBUser")]
        public int GBUSERIdTo { get; set; }


        public GBUser GBUser  { set ; get;}
        




    }
}
