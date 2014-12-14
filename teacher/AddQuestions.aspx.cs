using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class techer_AddQuestions : System.Web.UI.Page
{
    public static string sessionid = string.Empty;
    DataBase data = new DataBase();
    public string Nomber;
    protected void Page_Load(object sender, EventArgs e)
    {
        cbkAanswer.Visible = false;
        cbkBanswer.Visible = false;
        cbkCanswer.Visible = false;
        cbkDanswer.Visible = false;
        if (!IsPostBack)
        {
            Nomber = data.RunProcReturn("select count(*) as counts  from problems where sessionid=" + Common.GetMes.GetSession("sessionid") + "; ", "counts").Tables["counts"].Rows[0]["counts"].ToString();
            Nomber = int.Parse(Nomber) + 1 + "";
            txt_ExamName.Text = string.Empty;
            txtAanswer.Value = string.Empty;
            txtBanswer.Value = string.Empty;
            txtCanswer.Value = string.Empty;
            txtDanswer.Value = string.Empty;
            txtExplaination.Text = string.Empty;
        }
        ddl_Times.Visible = false;
       
    }
    protected void btn_next_Click(object sender, EventArgs e)
    {

        string rightanswer = string.Empty;
        if (RadioButton1.Checked)
        {
            rightanswer = "A";
        }
        if (RadioButton2.Checked)
        {
            rightanswer = "B";
        } 
        if (RadioButton3.Checked)
        {
            rightanswer = "C";
        } 
        if (RadioButton4.Checked)
        {
            rightanswer = "D";
        }
        //if (cbkAanswer.Checked)
        //    rightanswer = "A";
        //if (cbkBanswer.Checked)
        //    rightanswer = "B";
        //if (cbkCanswer.Checked)
        //    rightanswer = "C";
        //if (cbkDanswer.Checked)
        //    rightanswer = "D";

        if (string.IsNullOrEmpty(txt_ExamName.Text))
        {
            Common.ShowMessage.Show(Page, "Question Title", "Question Title is NULL!");
            return;
        }
        if (string.IsNullOrEmpty(txtAanswer.Value) || string.IsNullOrEmpty(txtBanswer.Value) || string.IsNullOrEmpty(txtCanswer.Value) || string.IsNullOrEmpty(txtDanswer.Value))
        {
            Common.ShowMessage.Show(Page, "Answer", "Answers is NULL!");
            return;
        }
        if (string.IsNullOrEmpty(rightanswer))
        {
            Common.ShowMessage.Show(Page, "Right answer", "Right answer is NULL!");
            return;
        }
        if (string.IsNullOrEmpty(txtExplaination.Text))
        {
            Common.ShowMessage.Show(Page, "Explaination Name", "Explaination  is NULL!");
            return;
        }

        string sql = "insert into problems(sessionid,problemsTitle,Acontent,Bcontent,Ccontent,Dcontent,rightAnswer,explaination,times)"+
            " values(" + Common.GetMes.GetSession("sessionid") + ",'" + txt_ExamName.Text + "','" + txtAanswer.Value + "','" +
            txtBanswer.Value + "','" + txtCanswer.Value + "','" + txtDanswer.Value + "','"+rightanswer+"','" + txtExplaination.Text + "',"+ddl_Times.SelectedValue+");";
        data.RunProc(sql);
        Common.ShowMessage.Show(Page, "Add question", "Add question success!");
        Response.Redirect("AddQuestions.aspx");
    }
    protected void btn_Finish_Click(object sender, EventArgs e)
    {
        Response.Redirect("SessionManager.aspx");
    }
}