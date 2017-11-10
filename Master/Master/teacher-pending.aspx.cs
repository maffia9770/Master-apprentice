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

    }

}
