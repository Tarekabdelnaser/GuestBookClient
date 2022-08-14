using System.Data;
using System.Data.SqlClient;

namespace GuestBookClient.Model
{
    public class DB
    {

        //Here Is the Functionalities Which we will Use In Our Controller

        //Establishing Connection With GuestBookDb
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Guestbook;Integrated Security=true");


        //Registeration of New User  
        public string GBUserRegisteringUser(GBUser GbUser)
        {
            string Msg = string.Empty;
            try
            {
                SqlCommand SqlC = new SqlCommand("RegisteringUser", con);

                SqlC.CommandType = System.Data.CommandType.StoredProcedure;
                SqlC.Parameters.AddWithValue("@UserName", GbUser.GBUName);
                SqlC.Parameters.AddWithValue("@UserPassword", GbUser.Password);
                SqlC.Parameters.AddWithValue("@UserEmail", GbUser.GBUEmail);
                con.Open();
                SqlC.ExecuteNonQuery();
                con.Close();
                Msg = "Success";

            }
            catch(Exception ex)
            {
                Msg = ex.Message;

            }
            finally{

                if (con.State==System.Data.ConnectionState.Open)
                {
                    con.Close();

                }
            }
            return Msg;




        }



        //Getting All Users in Db
        public DataSet GBUsersGetting()
        {
            GBUser GbUser = new GBUser();

            string Msg = string.Empty;
            DataSet ds = new DataSet();

            try
            {
                SqlCommand SqlC = new SqlCommand("GetAllUsers", con);

                SqlC.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter SQAD = new SqlDataAdapter(SqlC);
                SQAD.Fill(ds);
                return ds;

                Msg = "Success";


            }
            catch (Exception ex)
            {
                Msg = ex.Message;

            }
            finally
            {

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();

                }
            }
            return ds;




        }


        //Loging User
        public int Login(GBUser GbUser)
        {
              string Msg = string.Empty;

            int NumberOfRowsAffected = 0;

            try
            {

                SqlCommand SqlC = new SqlCommand("Login", con);

                SqlC.CommandType = System.Data.CommandType.StoredProcedure;

                SqlC.Parameters.AddWithValue("@UserEmail", GbUser.GBUEmail);

                SqlC.Parameters.AddWithValue("@UserPassword", GbUser.Password);
              

                con.Open();

                NumberOfRowsAffected =  SqlC.ExecuteNonQuery();

                con.Close();
                
                return NumberOfRowsAffected;
               
               

            }
            catch (Exception ex)
            {
                Msg = ex.Message;

            }
            finally
            {

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();

                }
            }
            return NumberOfRowsAffected;




        }




        
        //Sending Message
        public int SendMessage(string UserEmailFrom, string UserPassword, string Message, string UserIDTo)
        {
            string Msg = string.Empty;

            int NumberOfRowsAffected = 0;

            try
            {

                SqlCommand SqlC = new SqlCommand("SendingMessage", con);

                SqlC.CommandType = System.Data.CommandType.StoredProcedure;

                SqlC.Parameters.AddWithValue("@UserEmailFrom", UserEmailFrom);

                SqlC.Parameters.AddWithValue("@UserPassword", UserPassword);
                SqlC.Parameters.AddWithValue("@Message", Message);
                SqlC.Parameters.AddWithValue("@UserIDTo", UserIDTo);


                con.Open();

                NumberOfRowsAffected = SqlC.ExecuteNonQuery();

                con.Close();

                return NumberOfRowsAffected;



            }
            catch (Exception ex)
            {
                Msg = ex.Message;

            }
            finally
            {

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();

                }
            }
            return NumberOfRowsAffected;




        }



        //Replaying On Message
        public int ReplayOnMessage(string UserMessageID, string MessageForReplaying, string UserIDTo)
        {
            string Msg = string.Empty;

            int NumberOfRowsAffected = 0;

            try
            {

                SqlCommand SqlC = new SqlCommand("ReplayingOnMessage", con);

                SqlC.CommandType = System.Data.CommandType.StoredProcedure;

                SqlC.Parameters.AddWithValue("@UserMessageID", UserMessageID);

                SqlC.Parameters.AddWithValue("@MessageForReplaying", MessageForReplaying);

                SqlC.Parameters.AddWithValue("@UserIDTo", UserIDTo);



                con.Open();

                NumberOfRowsAffected = SqlC.ExecuteNonQuery();

                con.Close();

                return NumberOfRowsAffected;



            }
            catch (Exception ex)
            {
                Msg = ex.Message;

            }
            finally
            {

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();

                }
            }
            return NumberOfRowsAffected;




        }


        //Deleting Message
        public int DeleteMessage(string UserEmailFrom, string UserPassword, string MessageID)
        {
            string Msg = string.Empty;

            int NumberOfRowsAffected = 0;

            try
            {

                SqlCommand SqlC = new SqlCommand("DeleteMessage", con);

                SqlC.CommandType = System.Data.CommandType.StoredProcedure;

                SqlC.Parameters.AddWithValue("@UserEmailFrom", UserEmailFrom);

                SqlC.Parameters.AddWithValue("@UserPassword", UserPassword);

                SqlC.Parameters.AddWithValue("@MessageID", MessageID);



                con.Open();

                NumberOfRowsAffected = SqlC.ExecuteNonQuery();

                con.Close();

                return NumberOfRowsAffected;



            }
            catch (Exception ex)
            {
                Msg = ex.Message;

            }
            finally
            {

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();

                }
            }
            return NumberOfRowsAffected;




        }













    }
}
