using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class techer_Invigilate : System.Web.UI.Page
{
    DataBase data = new DataBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ddlSession.DataSource = data.RunProcReturn("select * from sessions;", "sessions").Tables["sessions"];
            this.ddlSession.DataValueField = "sessionid";
            this.ddlSession.DataTextField = "sessionname";
            this.ddlSession.DataBind();
            
        }
    }
    protected void btn_Query_Click(object sender, EventArgs e)
    {
        bind();
    }
    public void bind()
    {
        string sessionid = ddlSession.SelectedValue;
        string questionid = ddlQuestions.SelectedValue;        
        string sql = "select s.sessionname,p.problemsTitle, sum(isRight) as rightnum,count(userid)-sum(isRight) as wrongnum from userproblem up "+
                     "join sessions s on s.sessionid=up.sessionid join problems p on up.proid=p.proid "+
                     "where 1=1";
        if (!string.IsNullOrEmpty(sessionid))
        {
            sql += " and s.sessionid=" + sessionid;
        }
         if (!string.IsNullOrEmpty(questionid))
        {
            sql += " and p.proid="+questionid;
        }
        this.grvSession.DataSource = data.RunProcReturn(sql+" group by s.sessionid,p.proid;", "problems").Tables["problems"];
        this.grvSession.DataBind();
    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sessionid = ddlSession.SelectedValue;
        string sql = "select * from problems where sessionid="+sessionid+";";
        this.ddlQuestions.DataSource = data.RunProcReturn(sql, "problems").Tables["problems"];
        this.ddlQuestions.DataValueField = "proid";
        this.ddlQuestions.DataTextField = "problemsTitle";
        this.ddlQuestions.DataBind();
        bind();
    }
    protected void ddlQuestions_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind();
    }
}