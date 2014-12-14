using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class questions : System.Web.UI.Page
{
    DataBase data = new DataBase();
    public static string sessionID = string.Empty;   

    public string Acontent = string.Empty;
    public string Bcontent = string.Empty;
    public string Ccontent = string.Empty;
    public string Dcontent = string.Empty;

    DataSet dataset = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        txtExplaination.Visible = false;
      //  if (Common.GetMes.GetSession("Role") != "2")
        {
            Button4.Visible = false;
            Button5.Visible = false;
        }
        sessionID = Common.GetMes.GetSession("sSessionID");

        dataset = data.RunProcReturn("select * from problems where proid not in (select proid from userproblem where userid='" + 
                                                      Common.GetMes.GetSession("UserID") + "' and sessionid=" +
                                                      sessionID + ") and sessionid=" + sessionID + ";", "table");

        if (dataset == null || dataset.Tables["table"] == null || dataset.Tables["table"].Rows.Count == 0)
        {
            FinishExam(Common.GetMes.GetSession("UserID"), Common.GetMes.GetSession("sSessionID"), Common.GetMes.GetSession("uScore"));
            AddScore(-1);
            Common.ShowMessage.Show(Page, "Finished the Examnation", "Finish the Examnation");
            Response.Redirect("sessionlist.aspx");
        }
        if (!IsPostBack)
        {
            if (Common.GetMes.GetSession("Role") == "2")
            {
                if (CheckFinished())
                {
                    Common.ShowMessage.Show(Page, "Confirm", "The individual test is not done!");
                    Response.Redirect("sessionlist.aspx");                  
                }
            }
            dataset = data.RunProcReturn("select * from sessions where sessionid=" + sessionID + " ;", "session");
            if (dataset.Tables["session"].Rows.Count == 0)
            {
                Common.ShowMessage.Show(Page, "Examnation", "Haved Finished the Examnation");
                Response.Redirect("sessionlist.aspx");
            }
            DateTime datatime = DateTime.Parse(dataset.Tables["session"].Rows[0]["dateandtime"].ToString());        
            Label la = (Label)Master.FindControl("label_showName");
            la.Text = dataset.Tables["session"].Rows[0]["sessionname"].ToString();
            dataset = data.RunProcReturn("select * from problems where proid not in (select proid from userproblem where upflag=0 and userid='" 
                                                            + Common.GetMes.GetSession("UserID") + "' and sessionid=" +
                                                            sessionID + ") and sessionid=" + sessionID + ";", "table");
            if (dataset == null && dataset.Tables["table"] == null && dataset.Tables["table"].Rows.Count == 0)
            {
                FinishExam(Common.GetMes.GetSession("UserID"), Common.GetMes.GetSession("sSessionID"), Common.GetMes.GetSession("uScore"));
                Common.ShowMessage.Show(Page, "Finished the Examnation", "Finish the Examnation", "sessionlist.aspx");
                Response.Redirect("sessionlist.aspx");
            }
            //Load Problems
            LoadProblem(dataset);
        }        
    }
    public void AddScore(int addscore) 
    {
        if (addscore == -1)
        {
            Common.SetMes.SetSession("uScore","0");
            return;
        }
        string uscore = Common.GetMes.GetSession("uScore");
        Common.SetMes.SetSession("uScore", int.Parse(uscore) + addscore + "");
    }
    //Check everyone finished the exam
    private bool CheckFinished()
    {
        string studentcount = data.RunProcReturn("select count(*)  as countstudent  from userinfo where teamer='" + Common.GetMes.GetSession("UserID") + "' and  userid<>'" + Common.GetMes.GetSession("UserID") + "';", "count").Tables["count"].Rows[0]["countstudent"].ToString();
        string examcount = data.RunProcReturn("select count(*) as examcount from usersession where userid in (select userid  from userinfo where teamer='" + Common.GetMes.GetSession("UserID") + "' and userid<>'" + Common.GetMes.GetSession("UserID") + "');", "count").Tables["count"].Rows[0]["examcount"].ToString();
        if (studentcount  != "0" && studentcount.Equals(examcount))
            return false;
        return true;
    }

    private void FinishExam(string userID, string sessionID,string usercore)
    {
        string count = data.RunProcReturn("select count(*) as countsum from usersession where userid='"+userID+"' and sessionid="+sessionID+";", "pro").Tables["pro"].Rows[0]["countsum"].ToString();
        if (int.Parse(count) < 1)
            data.RunProc("insert into usersession (userid,sessionid,sessionflag,userscore)" +
                    " values('" + userID + "'," + sessionID + ",1," + usercore + ");");
        else
            data.RunProc("update usersession set userscore=" + usercore + ",sessionflag=1 where userid='" + userID + "' and sessionid=" + sessionID);

    }
    public void LoadProblem(DataSet dataset)
    {
        if(dataset==null || dataset.Tables.Count==0 || dataset.Tables["table"].Rows.Count==0)
        {
            Common.ShowMessage.Show(this.Page, "Finish", "Finish the Exam!", "questions.aspx");
            Response.Redirect("questions.aspx");
            return;
        }
        DataTable datatable =DtHun(DtHun(dataset.Tables["table"]));
        HiddenField1.Value = datatable.Rows[0]["proid"].ToString();
        label_ProblemTitle.Text = datatable.Rows[0]["problemsTitle"].ToString();
        A.Text = datatable.Rows[0]["Acontent"].ToString();
        B.Text = datatable.Rows[0]["Bcontent"].ToString();
        C.Text = datatable.Rows[0]["Ccontent"].ToString();
        D.Text = datatable.Rows[0]["Dcontent"].ToString();       
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string answer = string.Empty;
        if (A.Checked)
            answer= answer+ "A";
         if (B.Checked)
            answer= answer+"B";
         if (C.Checked)
             answer= answer+ "C";
         if (D.Checked)
             answer = answer + "D";
        string userid = Common.GetMes.GetSession("UserID");
        string proid = HiddenField1.Value;
        int isRight = CheckTheRight(proid,answer);
        if (isRight > 0)
            AddScore(25);
        string sql = "select * from userproblem where userid='"+userid+"' and proid="+proid+" and sessionid="+sessionID;
        if (data.RunProcReturn(sql, "problems").Tables["problems"].Rows.Count >= 1)
        {
            sql = "update userproblem set useranswer='" + answer + "',userexplaination='" + txtExplaination.Text + "',isright=" +
                                isRight + ",upflag=0 where userid='" + userid + "' and proid=" + proid + " and sessionid=" + sessionID;
            data.RunProc(sql);
        }
        else
        {
            data.RunProc("insert into userproblem(userid,proid,useranswer," +
                                  "userexplaination,isright,sessionid,upflag) values('" +
                                  userid + "'," + proid + ",'" + answer + "','" +
                                  txtExplaination.Text + "'," + isRight + "," + sessionID + ",0);");
        }
        if (Common.GetMes.GetSession("Role") == "2")
        {
            DataSet ds = data.RunProcReturn("select * from problems where proid=" + proid, "problems");
            txtExplaination.Text = ds.Tables["problems"].Rows[0]["explaination"].ToString();
            string rightChoice = ds.Tables["problems"].Rows[0]["rightAnswer"].ToString();
            if (rightChoice == "A")
            {
                A.Checked = true;
                B.Checked = false;
                C.Checked = false;
                D.Checked = false;
            }
            if (rightChoice == "B")
            {
                B.Checked = true;
                A.Checked = false;
                C.Checked = false;
                D.Checked = false;
            }
            if (rightChoice == "C")
            {
                C.Checked = true;
                A.Checked = false;
                B.Checked = false;
                D.Checked = false;
            }
            if (rightChoice == "D")
            {
                D.Checked = true;
                A.Checked = false;
                B.Checked = false;
                C.Checked = false;
            }
        }
        else
        {
            Response.Redirect("questions.aspx");
        }
    }
    public DataTable DtHun(DataTable dt)
    {      
        DataTable newdt = dt.Clone();
        foreach (DataRow row in dt.Rows)
        {
            DataRow dr = newdt.NewRow();
            dr.ItemArray = row.ItemArray;
            Random random = new Random();
            newdt.Rows.InsertAt(dr, random.Next(newdt.Rows.Count));
        }
        return newdt;
    }
    private int CheckTheRight(string proid, string answer)
    {
        DataSet result = data.RunProcReturn("select * from problems where proid="+proid+" and rightAnswer='"+answer+"'", "table");
        int count = result.Tables["table"].Rows.Count;
        if (count == 1)
            return count;
        return 0;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("questions.aspx");
    }
    protected void A_CheckedChanged(object sender, EventArgs e)
    {
        B.Checked = false;
        C.Checked = false;
        D.Checked = false;
    }
    protected void B_CheckedChanged(object sender, EventArgs e)
    {
        A.Checked = false;
        C.Checked = false;
        D.Checked = false;
    }
    protected void C_CheckedChanged(object sender, EventArgs e)
    {
        A.Checked = false;
        B.Checked = false;
        D.Checked = false;
    }
    protected void D_CheckedChanged(object sender, EventArgs e)
    {
        B.Checked = false;
        C.Checked = false;
        A.Checked = false;
    }   
    protected void Button5_Click(object sender, EventArgs e)
    {
        string answer = string.Empty;
        if (A.Checked)
            answer = answer + "A";
        if (B.Checked)
            answer = answer + "B";
        if (C.Checked)
            answer = answer + "C";
        if (D.Checked)
            answer = answer + "D";
        string userid = Common.GetMes.GetSession("UserID");
        string proid = HiddenField1.Value;
        int isRight = CheckTheRight(proid, answer);

        string sql = "select * from userproblem where userid='" + userid + "' and proid=" + proid + " and sessionid=" + sessionID;
        if (data.RunProcReturn(sql, "problems").Tables["problems"].Rows.Count >= 1)
        {
            sql = "update userproblem set useranswer='" + answer + "',userexplaination='" + txtExplaination.Text + "',isright=" +
                                isRight + " ,upflag=1 where userid='" + userid + "' and proid=" + proid + " and sessionid=" + sessionID + ";";
            data.RunProc(sql);
        }
        else
        {
            data.RunProc("insert into userproblem(userid,proid,useranswer," +
                                  "userexplaination,isright,sessionid,upflag) values('" +
                                  userid + "'," + proid + ",'" + answer + "','" +
                                  txtExplaination.Text + "'," + isRight + "," + sessionID + ",1);");
        }
        Response.Redirect("questions.aspx");
    }
}