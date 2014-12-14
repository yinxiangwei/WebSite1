<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMas.master" AutoEventWireup="true" CodeFile="AddSessions.aspx.cs" Inherits="techer_AddSessions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <meta name="keywords" content="Teal Com, www.865171.cn, Web Design" />
<meta name="description" content="Teal Com - www.865171.cn, HTML CSS, Web Design Layout" />
<link href="../templatemo_style.css" rel="stylesheet" type="text/css" />
<link href="../fullsize/fullsize.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../fullsize/jquery.js"></script>
<script type="text/javascript" src="../fullsize/jquery.fullsize.minified.js"></script>
<script language="javascript" type="text/javascript">
    $(function () {
        $("div.templatemo_gallery img").fullsize();
    });   
</script>
<link href="../templatemo_style.css" rel="stylesheet" type="text/css" />
<link href="../fullsize/fullsize.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../fullsize/jquery.js"></script>
<script type="text/javascript" src="../fullsize/jquery.fullsize.minified.js"></script>

<!-- basic styles -->
         <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
        <script type="text/javascript">
            if ("ontouchend" in document) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
		</script>
		<script src="../assets/js/bootstrap.min.js"></script>
		<script src="../assets/js/typeahead-bs2.min.js"></script>

		<!-- page specific plugin scripts -->

		<script src="../assets/js/jquery-ui-1.10.3.full.min.js"></script>
		<script src="../assets/js/jquery.ui.touch-punch.min.js"></script>

		<!-- ace scripts -->

		<script src="../assets/js/ace-elements.min.js"></script>
		<script src="../assets/js/ace.min.js"></script>

		<!-- inline scripts related to this page -->

	
		<link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
		<link rel="stylesheet" href="../assets/css/font-awesome.min.css" />

		<!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

		<!-- page specific plugin styles -->

		<!-- fonts -->

		<link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />

		<!-- ace styles -->

		<link rel="stylesheet" href="../assets/css/ace.min.css" />
		<link rel="stylesheet" href="../assets/css/ace-rtl.min.css" />
		<link rel="stylesheet" href="../assets/css/ace-skins.min.css" />

		<!--[if lte IE 8]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

		<!-- inline styles related to this page -->

		<!-- ace settings handler -->

		<script src="../assets/js/ace-extra.min.js"></script>

		<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

		<!--[if lt IE 9]>
		<script src="assets/js/html5shiv.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
        <script type="text/javascript">
            function check() {
                var sesstionname = document.getElementById("txt_ExamName").value;
                var sesstiondetail = document.getElementById("txt_Detail").value;
                var begintime = document.getElementById("datepicker").value;
                var finishtime = document.getElementById("txt_FinishTime").value;
                if (sesstionname == "") {
                    alert("sesstionname is null");
                    return false;
                }
                if (sesstiondetail == "") {
                    alert("sesstion detail is null");
                    return false;
                }
                if (begintime == "") {
                    alert("begin time is null");
                    return false;
                }
                if (finishtime == "") {
                    alert("finish time detail is null");
                    return false;
                }
            }
        </script>
  <div class="row">
     <div class="page-header">
         <h2>Add Session</h2> 
    </div>
    <div class="col-sm-6 col-sm-offset-3">
       <div class="well-sm">
            Session Name:<asp:TextBox runat="server" ID="txt_ExamName" TextMode="MultiLine" 
                CssClass="ace" Width="451px"></asp:TextBox>
       </div>     
      <div class="well-sm">
            Session Detail:<asp:TextBox runat="server" ID="txt_Detail" TextMode="MultiLine" 
                CssClass="ace" Width="451px"></asp:TextBox>
       </div>  
        <br />
       <table width="60%">
         <tr>
            <td>
                <bold>Begin time：</bold>  &nbsp;&nbsp;
            </td>
             <td>
               <input type="text" runat="server" id="datepicker"  onFocus="WdatePicker({startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd HH:mm:ss',alwaysUseStartDate:true})"/>
            </td>            
        </tr>
         <tr>
            <td>
                <bold>Duration (mins)：</bold>  &nbsp;&nbsp;
            </td>
             <td>
               <input  type="text" runat="server" id="txt_FinishTime"/>              
            </td>            
        </tr> 
       </table>
        <div class="col-sm-12  center">
  
         <asp:Button runat="server" ID="btn_next" CssClass="btn btn-success" Text="Add Session" OnClick="btn_next_Click" OnClientClick="return check()"></asp:Button>
       </div>
       <div class="well-sm"></div>
    </div>
  </div>
    </div>
</asp:Content>

