using GuestBookClient.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuestBookClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GBUserController : ControllerBase
    {
        //Using The Factory of Functions

        DB db = new DB();
     

        [HttpGet]
        public List<GBUser> GetAllUsers()
        {
            DataSet ds = db.GBUsersGetting();
            List<GBUser> Gbu = new List<GBUser>();
            foreach (DataRow Dr in ds.Tables[0].Rows)
            {
                Gbu.Add(new GBUser
                {
                    GBUName = Dr["GBUName"].ToString(),
                    GBUEmail= Dr["GBUEmail"].ToString(),
                    Password = Dr["Password"].ToString()
                });
                

            }


            return Gbu;
        }

        [HttpPost]
        public string RegisterNewUser([FromQuery]GBUser usr)
        {
           string msg= db.GBUserRegisteringUser(usr);
            if (msg == "Success") { return "Ok"; }
            else return "Failed";

        }

        [HttpGet]
        [Route("Login")]
        public string LoginUser([FromQuery] GBUser usr)
        {
            int msg = db.Login(usr);
            if (msg == 1) return "LoggedIn";

            else return "Failed";


        }





        [HttpGet]
        [Route("SendMessage")]
        public string SendMessage([FromQuery] string UserEmailFrom, string UserPassword, string Message, string UserIDTo)
        {
            int msg = db.SendMessage( UserEmailFrom,  UserPassword,  Message,  UserIDTo);
            if (msg == 1) return  "Message :" + Message;


            else return "Cannot Send Message ";


        }




        [HttpGet]
        [Route("ReplayOnMessage")]
        public string ReplayOnMessage([FromQuery] string UserMessageID, string MessageForReplaying, string UserIDTo)
        {
            int msg = db.ReplayOnMessage( UserMessageID,  MessageForReplaying,  UserIDTo);
            if (msg == 1) return "Message Replay :" + MessageForReplaying;


            else return "Cannot Send Replay ";


        }







        [HttpGet]
        [Route("DeleteMessage")]
        public string DeleteMessage([FromQuery] string UserEmailFrom, string UserPassword, string MessageID)
        {
            int msg = db.DeleteMessage( UserEmailFrom,  UserPassword,  MessageID);

            if (msg == 1) return "Message Deleted .." ;


            else return "Cannot Delete Message ";


        }












    }
}
