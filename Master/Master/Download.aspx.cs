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
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Byte[] bytes;
            string contentType, fileName;
            string User = (string)Session["RevUser"];
            string Quest = (string)Session["ActQuest"];
            using (SqlConnection con = new SqlConnection("Server=tcp:master-apprentice.database.windows.net,1433;Initial Catalog=Masterbase;Persist Security Info=False;User ID=master;Password=Apprentice1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select id, FileName, BinaryData, MIME from BinaryTable where QuestID=@Quest AND UserID=@User";
                    cmd.Parameters.AddWithValue("@User", User);
                    cmd.Parameters.AddWithValue("@Quest", Quest);
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
        }
    }
}