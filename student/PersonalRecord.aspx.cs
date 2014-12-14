using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_PersonalRecord : System.Web.UI.Page
{
    public int Score = 0;
    DataBase data = new DataBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ddlSession.DataSource = data.RunProcReturn("select * from sessions where sessionid in (select sessionid from usersession where userid='" + Common.GetMes.GetSession("UserID") + "');", "problems").Tables["problems"];
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
        this.grvSession.DataSource = data.RunProcReturn("select ps.problemsTitle,ub.isright,ps.explaination from userproblem ub join problems "+
                                                                            " ps on ps.proid = ub.proid where ps.sessionid='" +
                                                                            ddlSession.SelectedValue + "' and ub.userid='" + 
                                                                            Common.GetMes.GetSession("UserID") + "'", "problems").Tables["problems"];
        this.grvSession.DataBind();
        Score =int.Parse(data.RunProcReturn("select userscore from usersession where userid='pb' and sessionid=" + ddlSession.SelectedValue, "userscore").Tables["userscore"].Rows[0]["userscore"].ToString());
    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind();
    }
}