using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Master
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
                Response.Redirect("Login.aspx");
        }
        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            if (FileToUpload.PostedFile == null || String.IsNullOrEmpty(FileToUpload.PostedFile.FileName) || FileToUpload.PostedFile.InputStream == null)
            {
                lit_Status.Text = "<br />Error - unable to upload file. Please try again.<br />";
            }
            else
            {
                using (SqlConnection Con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    try//placeholder
                    {
                        const string SQL = "INSERT INTO [BinaryTable] ([UserID], [FileName], [DateTimeUploaded], [MIME], [BinaryData], [QuestID]) VALUES (@UserID, @FileName, @DateTimeUploaded, @MIME, @BinaryData, @QuestID)";
                        SqlCommand cmd = new SqlCommand(SQL, Con);
                        cmd.Parameters.AddWithValue("@FileName", FileName.Text.Trim());
                        cmd.Parameters.AddWithValue("@MIME", FileToUpload.PostedFile.ContentType);

                        byte[] imageBytes = new byte[FileToUpload.PostedFile.InputStream.Length + 1];
                        FileToUpload.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length);
                        cmd.Parameters.AddWithValue("@BinaryData", imageBytes);
                        cmd.Parameters.AddWithValue("@DateTimeUploaded", DateTime.Now);

                        cmd.Parameters.AddWithValue("@QuestID", Session["QuestID"]);
                        cmd.Parameters.AddWithValue("@UserID", Session["User"]);
                        System.Diagnostics.Debug.WriteLine(Session["QuestID"]);
                        Con.Open();
                        cmd.ExecuteNonQuery();
                        lit_Status.Text = "<br />File successfully uploaded - thank you.<br />";
                        Con.Close();
                    }
                    catch
                    {
                        lit_Status.Text = "<br />Error - unable to upload file. Please try again.<br />";
                        Con.Close();
                    }
                }
            }
        }
        [WebMethod(EnableSession = true)]
        public static string DisplayQuest(string Quest)
        {
            System.Diagnostics.Debug.WriteLine(Quest);
            //Quest = "Search for the Golden Pineapple";//detta ska inte vara här sen :p
            using (SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                try
                {
                    con.Open();
                    SqlCommand CheckQuests = new SqlCommand("DisplayQuest", con);
                    CheckQuests.CommandType = CommandType.StoredProcedure;
                    SqlParameter parCourse = new SqlParameter();
                    parCourse.ParameterName = "@Quest";
                    parCourse.Value = Quest;

                    CheckQuests.Parameters.Add(parCourse);
                    Object obj = CheckQuests.ExecuteScalar();
                    Quest = obj.ToString();
                    con.Close();
                    Quest.Trim();
                    Quest.Replace("[", string.Empty);
                    Quest.Replace("]", string.Empty);
                    Quest.Remove(0);
                    System.Diagnostics.Debug.WriteLine(Quest + "sug mig");
                    return Quest;
                }
                catch
                {
                    con.Close();
                    return null;
                }
            }
        }
        [WebMethod(EnableSession = true)]
        public static string CheckQuests(string Status)
        {
            using (SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                try
                {
                    con.Open();
                    SqlCommand CheckQuests = new SqlCommand("ShowAvailableQuests", con);

                    if (Status == "1")
                    {
                        CheckQuests.CommandText = "ShowActiveQuests";
                    }
                    if (Status == "2")
                    {
                        CheckQuests.CommandText = "ShowCompletedQuests";
                    }
                    if (Status == "3")
                    {
                        CheckQuests.CommandText = "ShowFailedQuests";
                    }

                    CheckQuests.CommandType = CommandType.StoredProcedure;
                    /* tills vi har user att skicka in
                    SqlParameter parLogINID = new SqlParameter();
                    parLogINID.ParameterName = "@Username";
                    parLogINID.Value = User.Text;
                    */
                    var UserID = (string)HttpContext.Current.Session["User"];
                    SqlParameter parLogINID = new SqlParameter();
                    parLogINID.ParameterName = "@UserID";
                    parLogINID.Value = UserID;

                    //CheckQuests.Parameters.Add(parUser);
                    CheckQuests.Parameters.Add(parLogINID);
                    Object obj = CheckQuests.ExecuteScalar();
                    if (obj == null)
                    {
                        con.Close();
                        return null;
                    } 
                    UserID = obj.ToString();
                    con.Close();
                    UserID.Trim();
                    UserID.Replace("[", string.Empty);
                    UserID.Replace("]", string.Empty);
                    UserID.Remove(0);
                    System.Diagnostics.Debug.WriteLine(obj.ToString());
                    return UserID;
                }
                catch
                {
                    con.Close();
                    return null;
                }
            }

        }
        [WebMethod(EnableSession = true)]
        public static string SessionData(string QuestID)
        {
            HttpContext.Current.Session["QuestID"] = QuestID;
            return "1";
        }
    }
}