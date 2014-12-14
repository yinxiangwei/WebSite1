<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMas.master" AutoEventWireup="true" CodeFile="PersonalRecord.aspx.cs" Inherits="student_PersonalRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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

		<script src="../assets/js/ace-extra.min.js"></script>

		<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

		<!--[if lt IE 9]>
		<script src="assets/js/html5shiv.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
        <div class="col-sm-12">  
        <div class="col-sm-8 col-sm-offset-2">
            <table>
                <tr>
                    <td>
                        Sessions:
                    </td>
                     <td>
                        <asp:DropDownList runat="server" ID="ddlSession" CssClass="form-control" 
                             AutoPostBack="True" onselectedindexchanged="ddlSession_SelectedIndexChanged"></asp:DropDownList>
                     </td>                    
                     <td>
                        <asp:Button runat="server" ID="btn_Query"  Text="Query" 
                             CssClass="btn btn-success" onclick="btn_Query_Click"/>
                     </td>
                     <td>Score:</td>
                    <td>
                        <%= Score %>
                    </td>
                </tr>
            </table>    
        </div>  
        <asp:GridView runat="server" CssClass="table table-striped table-bordered table-hover" ID="grvSession" AutoGenerateColumns="False">            
            <Columns>           
              <asp:TemplateField meta:resourcekey="Number" HeaderText="NO">
                                     <HeaderStyle Width="40px" />
                                        <ItemTemplate>                                        
                                            <%# Container.DataItemIndex + 1 %></ItemTemplate>
                                         <%--HeaderText="序号"--%>
               </asp:TemplateField>     
                <asp:BoundField DataField="problemsTitle" HeaderText="problemsTitle" />
                <asp:TemplateField HeaderText="IsRight">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# (Eval("isright").ToString()=="1")?"Yes":"No" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>            
                <asp:BoundField DataField="explaination" HeaderText="explaination" />  
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />            
        </asp:GridView>
        <div class="well-sm"></div>              
    </div>
</asp:Content>

