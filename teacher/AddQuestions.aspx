<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMas.master" AutoEventWireup="true" CodeFile="AddQuestions.aspx.cs" Inherits="techer_AddQuestions" %>

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

		<script src="assets/js/ace-extra.min.js"></script>

		<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

		<!--[if lt IE 9]>
		<script src="assets/js/html5shiv.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
         <script type="text/javascript">
            function check() {
                var questionnname = document.getElementById("txt_ExamName").value;
                var Aanswer = document.getElementById("txtAanswer").value;
                var Banswer = document.getElementById("txtBanswer").value;
                var Canswer = document.getElementById("txtCanswer").value;
                var Danswer = document.getElementById("txtDanswer").value;
                var Explaination = document.getElementById("txtExplaination").value;

                var cbkA = document.getElementById("cbkAanswer");
                var cbkB = document.getElementById("cbkBanswer");
                var cbkC = document.getElementById("cbkCanswer");
                var cbkD = document.getElementById("cbkDanswer");

                if (questionnname == "") {
                    alert("question Title is null");
                    return false;
                }
                if (Aanswer == "") {
                    alert("A answer  is null");
                    return false;
                }
                if (Banswer == "") {
                    alert("B answer time is null");
                    return false;
                }
                if (Canswer == "") {
                    alert("C answer  is null");
                    return false;
                }
                if (Danswer == "") {
                    alert("D answer time is null");
                    return false;
                }
                if (Explaination == "") {
                    alert("Explaination time is null");
                    return false;
                }    
                if (!cbkA.checked && !cbkB.checked && !cbkC.checked && !cbkD.checked) {
                    
                    return false;
                }
            }
        </script>
  <div class="row">
     <div class="page-header">
         <h2>Add Questions        
         </h2> 
         <h3>
           NO. <%= Nomber %>
         </h3>
    </div>
    <div class="col-sm-6 col-sm-offset-3">
       <div class="well-sm">
            Question Title:<asp:TextBox runat="server" ID="txt_ExamName" TextMode="MultiLine" 
                CssClass="ace" Width="368px"></asp:TextBox>
            <asp:DropDownList runat="server" ID="ddl_Times">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
            </asp:DropDownList>
       </div>    
       <div class="space-10"></div>
       
        <br />
       <table width="60%">
         <tr>
            <td>
                <bold>A</bold>  &nbsp;&nbsp;
            </td>
             <td>
               <input type="text"  runat="server" id="txtAanswer"  class="col-sm-12" />             
            </td> 
            <td>
                <asp:CheckBox runat="server" ID="cbkAanswer"  Text="IsRight"/>
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="answer" Text="IsRight" />
            </td>           
        </tr>
        <tr>
            <td>
                <bold>B</bold>  &nbsp;&nbsp;
            </td>
             <td>
               <input type="text"  runat="server" id="txtBanswer"  class="col-sm-12" />             
            </td> 
            <td>
                <asp:CheckBox runat="server" ID="cbkBanswer"  Text="IsRight"/>
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="answer" Text="IsRight" />
            </td>           
        </tr>
         <tr>
            <td>
                <bold>C</bold>  &nbsp;&nbsp;
            </td>
             <td>
               <input type="text"  runat="server" id="txtCanswer"  class="col-sm-12" />             
            </td> 
            <td>
                <asp:CheckBox runat="server" ID="cbkCanswer"  Text="IsRight"/>
                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="answer" Text="IsRight"/>
            </td>           
        </tr>
        <tr>
            <td>
                <bold>D</bold>  &nbsp;&nbsp;
            </td>
             <td>
               <input type="text"  runat="server" id="txtDanswer"  class="col-sm-12" />             
            </td> 
            <td>
                <asp:CheckBox runat="server" ID="cbkDanswer"  Text="IsRight"/>
                <asp:RadioButton ID="RadioButton4" runat="server" GroupName="answer" Text="IsRight" />
            </td>           
        </tr>
        <tr>        
            <td>
                 Explaination
            </td>
             <td colspan="2">
              <asp:TextBox runat="server" ID="txtExplaination" TextMode="MultiLine" CssClass="col-sm-12" Width="200" Height="50"></asp:TextBox>
            </td>            
        </tr>
       </table>
        <div class="col-sm-12  center">
         <asp:Button runat="server" ID="btn_next" CssClass="btn btn-success" Text="Add Questions" OnClick="btn_next_Click" OnClientClick="return check();"></asp:Button>
         &nbsp;&nbsp;&nbsp;
          <asp:Button runat="server" ID="btn_Finish" CssClass="btn btn-success" Text="Finish" OnClick="btn_Finish_Click"></asp:Button>        
       </div>
       <div class="well-sm"></div>
    </div>
  </div>
</asp:Content>

