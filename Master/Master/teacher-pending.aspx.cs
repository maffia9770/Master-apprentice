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
    public partial class teacher_pending : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt16(Session["UserType"]) == 0)
            {
                Response.Redirect("Home.aspx");
            }
            if (!IsPostBack)
            {
                //BindGrid();
                //BindDummyGrid();
            }
        }
        protected void SubmitGrade_Click(object sender, EventArgs e)
        {
            string Skill1 = Request.Form["Skill0"];
            string Skill2 = Request.Form["Skill1"];
            string Skill3 = Request.Form["Skill2"];
            string Skill4 = Request.Form["Skill3"];
            string Skill5 = Request.Form["Skill4"];
            string Skill6 = Request.Form["Skill5"];
            string UserID = (string)Session["revUser"];
            string QuestID = (string)Session["ActQuest"];
            int status = 2;//success
            if (Skill1 == null && Skill2 == null && Skill3 == null && Skill4 == null && Skill5 == null && Skill6 == null)
                status = 3;//fail
            using (SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                try
                {
                    if(status == 3)
                    {
                        con.Open();
                        const string SQL = "UPDATE [BinaryTable] SET status=3 WHERE QuestID=@QuestID AND UserID=@UserID";
                        SqlCommand cmd = new SqlCommand(SQL, con);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@QuestID", QuestID);
                        cmd.ExecuteNonQuery();

                        const string SQL2 = "UPDATE UsersQuests SET QuestStatus = 3 WHERE QuestName=@QuestID AND UserID=@UserID";
                        SqlCommand cmd2 = new SqlCommand(SQL2, con);
                        cmd2.Parameters.AddWithValue("@UserID", UserID);
                        cmd2.Parameters.AddWithValue("@QuestID", QuestID);
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        return;
                    }
                    else
                    {
                        con.Open();
                        SqlCommand AddSkills = new SqlCommand("AddSkills", con);

                        AddSkills.CommandType = CommandType.StoredProcedure;
                        SqlParameter parSkill1 = new SqlParameter();
                        parSkill1.ParameterName = "@Skill1";
                        parSkill1.Value = Skill1;

                        AddSkills.CommandType = CommandType.StoredProcedure;
                        SqlParameter parSkill2 = new SqlParameter();
                        parSkill2.ParameterName = "@Skill2";
                        parSkill2.Value = Skill2;

                        AddSkills.CommandType = CommandType.StoredProcedure;
                        SqlParameter parSkill3 = new SqlParameter();
                        parSkill3.ParameterName = "@Skill3";
                        parSkill3.Value = Skill3;

                        AddSkills.CommandType = CommandType.StoredProcedure;
                        SqlParameter parSkill4 = new SqlParameter();
                        parSkill4.ParameterName = "@Skill4";
                        parSkill4.Value = Skill4;

                        AddSkills.CommandType = CommandType.StoredProcedure;
                        SqlParameter parSkill5 = new SqlParameter();
                        parSkill5.ParameterName = "@Skill5";
                        parSkill5.Value = Skill5;

                        AddSkills.CommandType = CommandType.StoredProcedure;
                        SqlParameter parSkill6 = new SqlParameter();
                        parSkill6.ParameterName = "@Skill6";
                        parSkill6.Value = Skill6;

                        AddSkills.CommandType = CommandType.StoredProcedure;
                        SqlParameter parUser = new SqlParameter();
                        parUser.ParameterName = "@UserID";
                        parUser.Value = UserID;

                        //CheckQuests.Parameters.Add(parUser);
                        AddSkills.Parameters.Add(parSkill1);
                        AddSkills.Parameters.Add(parSkill2);
                        AddSkills.Parameters.Add(parSkill3);
                        AddSkills.Parameters.Add(parSkill4);
                        AddSkills.Parameters.Add(parSkill5);
                        AddSkills.Parameters.Add(parSkill6);
                        AddSkills.Parameters.Add(parUser);
                        AddSkills.ExecuteScalar();

                        const string SQL2 = "UPDATE UsersQuests SET QuestStatus = 2 WHERE QuestName=@QuestID AND UserID=@UserID";
                        SqlCommand cmd2 = new SqlCommand(SQL2, con);
                        cmd2.Parameters.AddWithValue("@UserID", UserID);
                        cmd2.Parameters.AddWithValue("@QuestID", QuestID);
                        cmd2.ExecuteNonQuery();

                        const string SQL = "UPDATE [BinaryTable] SET status=2 WHERE QuestID=@QuestID AND UserID=@UserID";
                        SqlCommand cmd = new SqlCommand(SQL, con);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@QuestID", QuestID);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        return;
                    }
                    
                }
                catch (HttpUnhandledException)
                {
                    con.Close();
                    return;
                }
            }
        }
        /*private void BindDummyGrid()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("File name");
            dummy.Rows.Add();
            Download.DataSource = dummy;
            Download.DataBind();
        }
        private void BindGrid()
        {
            string User = (string)Session["RevUser"];
            string Quest = (string)Session["ActQuest"];
            using (SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))

            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select UserID, FileName from BinaryTable ";
                   // cmd.Parameters.AddWithValue("@UserID", );
                    //cmd.Parameters.AddWithValue("@QuestID", Quest);
                    cmd.Connection = con;
                    con.Open();
                    Download.DataSource = cmd.ExecuteReader();
                    Download.DataBind();
                    con.Close();
                }
            }
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            //int id = int.Parse((sender as LinkButton).CommandArgument);
            string id = (sender as LinkButton).CommandArgument;
            byte[] bytes;
            string fileName, contentType;
            string User = (string)HttpContext.Current.Session["RevUser"];
            string Quest = (string)HttpContext.Current.Session["ActQuest"];
            using (SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select id, FileName, BinaryData, MIME from BinaryTable where FileName=@Id AND UserID=@UserID";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@UserID", User);
                    //cmd.Parameters.AddWithValue("@QuestID", Quest);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["BinaryData"];
                        contentType = sdr["MIME"].ToString();
                        fileName = sdr["FileName"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }*/
        [WebMethod(EnableSession = true)]
        public static string CheckPending(string CourseID)
        {
            using (SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                try
                {
                    con.Open();
                    SqlCommand CheckPending = new SqlCommand("ShowPendingQuests", con);

                    CheckPending.CommandType = CommandType.StoredProcedure;
                    SqlParameter parCourseID = new SqlParameter();
                    parCourseID.ParameterName = "@CourseID";
                    parCourseID.Value = CourseID;

                    //CheckQuests.Parameters.Add(parUser);
                    CheckPending.Parameters.Add(parCourseID);
                    Object obj = CheckPending.ExecuteScalar();
                    if (obj == null)
                    {
                        throw new HttpUnhandledException();
                    }
                    CourseID = obj.ToString();
                    con.Close();
                    CourseID.Trim();
                    CourseID.Replace("[", string.Empty);
                    CourseID.Replace("]", string.Empty);
                    CourseID.Remove(0);
                    System.Diagnostics.Debug.WriteLine(obj.ToString());
                    return CourseID;
                }
                catch (HttpUnhandledException)
                {
                    con.Close();
                    return null;
                }
            }

        }
        [WebMethod(EnableSession = true)]
        public static string CheckSkills(string CourseID)
        {
            using (SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                try
                {
                    con.Open();
                    SqlCommand CheckPending = new SqlCommand("GetAllSkills", con);

                    CheckPending.CommandType = CommandType.StoredProcedure;
                    SqlParameter parCourseID = new SqlParameter();
                    parCourseID.ParameterName = "@CourseID";
                    parCourseID.Value = CourseID;

                    //CheckQuests.Parameters.Add(parUser);
                    CheckPending.Parameters.Add(parCourseID);
                    Object obj = CheckPending.ExecuteScalar();
                    if (obj == null)
                    {
                        throw new HttpUnhandledException();
                    }
                    CourseID = obj.ToString();
                    con.Close();
                    CourseID.Trim();
                    CourseID.Replace("[", string.Empty);
                    CourseID.Replace("]", string.Empty);
                    CourseID.Remove(0);
                    System.Diagnostics.Debug.WriteLine(obj.ToString());
                    return CourseID;
                }
                catch (HttpUnhandledException)
                {
                    con.Close();
                    return null;
                }
            }
        }
        [WebMethod(EnableSession = true)]
        public static string Save(string User)
        {
            HttpContext.Current.Session["RevUser"] = User;
            System.Diagnostics.Debug.WriteLine(HttpContext.Current.Session["RevUser"] + "sug mig");
            return null;
        }
        [WebMethod(EnableSession = true)]
        public static string Skills(string CourseID)
        {

            using (SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                try
                {
                    con.Open();
                    SqlCommand CheckPending = new SqlCommand("GetAllSkills", con);

                    CheckPending.CommandType = CommandType.StoredProcedure;
                    SqlParameter parCourseID = new SqlParameter();
                    parCourseID.ParameterName = "@CourseID";
                    parCourseID.Value = CourseID;

                    //CheckQuests.Parameters.Add(parUser);
                    CheckPending.Parameters.Add(parCourseID);
                    Object obj = CheckPending.ExecuteScalar();
                    if (obj == null)
                    {
                        throw new HttpUnhandledException();
                    }
                    CourseID = obj.ToString();
                    con.Close();
                    CourseID.Trim();
                    CourseID.Replace("[", string.Empty);
                    CourseID.Replace("]", string.Empty);
                    CourseID.Remove(0);
                    System.Diagnostics.Debug.WriteLine(obj.ToString());
                    return CourseID;
                }
                catch (HttpUnhandledException)
                {
                    con.Close();
                    return null;
                }
            }
        }

    }

}
