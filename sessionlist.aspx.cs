using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Recmendaton : System.Web.UI.Page
{
    public static string username = string.Empty;
    public static string userid = string.Empty;
    DataBase data = new DataBase();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        username = Common.GetMes.GetSession("UserName");
        if (Session["UserName"] != null && !Session["UserName"].ToString().Equals(string.Empty))
        {
            username = Session["UserName"].ToString();
        }
        Label la = (Label)Master.FindControl("label_showName");
        la.Text = username;
        Label label_ShowTime = (Label)Master.FindControl("label_ShowTime");
        label_ShowTime.Text = DateTime.Now.ToShortDateString();
        string role = Common.GetMes.GetSession("Role");
        Button1.Visible = false;
        Button3.Visible = false;
        if (role == "1" || role == "2") //manager
        {
            btn_Mnager.Visible = false;
            Button2.Visible = false;
        }
        if (!IsPostBack)
        {
            this.grvSession.DataSource = data.RunProcReturn("select us.sessionid,ss.sessionname,us.userscore,ss.dateandtime from sessions "+
                                                                                        "ss join usersession us on us.sessionid=ss.sessionid where userid='"+
                                                                                         Common.GetMes.GetSession("UserID")+"';", "0").Tables["0"];
            this.grvSession.DataBind();
            this.grvSession.Columns[4].Visible = true;
            //foreach (GridViewRow dgv in grvSession.Rows)
            //{
            //    dgv.Cells[3].Text = string.Empty;
            //}           
        }
    }
   
    protected void btn_PostSession_Click(object sender, EventArgs e)
    {
        this.grvSession.DataSource = data.RunProcReturn("select s.sessionid,sessionname,dateandtime,ui.name,us.userscore from sessions s join "+
                                                                                " usersession us on us.sessionid=s.sessionid join userinfo ui on ui.userid=us.userid where sessionflag=1 and name='" 
                                                                                + username + "' ;", "0").Tables["0"];
        this.grvSession.DataBind();
        this.grvSession.Columns[3].Visible = true;
        this.grvSession.Columns[4].Visible = true;
        //foreach (GridViewRow dgv in grvSession.Rows)
        //{
        //    dgv.Cells[3].Text = string.Empty;
        //}
    }
    protected void btn_Upcoming_Click(object sender, EventArgs e)
    {
        this.grvSession.DataSource = data.RunProcReturn("select *,passflag as userscore  from sessions "+
                                                         "where sessions.passflag=2 and sessionid not in (select sessionid from usersession where userid='" + 
                                                         Common.GetMes.GetSession("UserID") + "' and sessionflag=1) ", "0").Tables["0"];
        this.grvSession.Columns[3].Visible = false;
        this.grvSession.DataBind();       
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("student/PersonalRecord.aspx");
    }
    protected void grvSession_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Common.SetMes.SetSession("sSessionID", grvSession.DataKeys[e.NewEditIndex].Value.ToString());
        Common.SetMes.SetSession("uScore","0");
        Response.Redirect("questions.aspx");
    }
}