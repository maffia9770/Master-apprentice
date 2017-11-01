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
            /*if (!IsPostBack)
            {
                BindGrid();
            }*/
        }
        /*private void BindGrid()
            {
                using (SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))

                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select Id, Name from tblFiles";
                        cmd.Connection = con;
                        con.Open();
                        GridView1.DataSource = cmd.ExecuteReader();
                        GridView1.DataBind();
                        con.Close();
                    }
                }
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
    
    }

}
