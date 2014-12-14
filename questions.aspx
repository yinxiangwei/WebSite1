<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMas.master" AutoEventWireup="true" CodeFile="questions.aspx.cs" Inherits="questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-sm-12">
         <div class="col-sm-4">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" ID="btn_Mnager" CssClass="btn btn-info" Text="Previous" Width="100px" />
            &nbsp;&nbsp;
        </div>
         <div class="col-sm-4" >
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" ID="Button1" CssClass="btn btn-info" Text="Individual Assurance Test" />
            &nbsp;&nbsp;
         </div>
          <div class="col-sm-4">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" ID="Button2" CssClass="btn btn-info" Text="Next " Width="100px"/>
            &nbsp;&nbsp;
          </div>
          <div class="space-16"></div> 
          <div class="cleaner"></div>
          <div class="well-sm"></div>
          <div class="col-sm-8 col-sm-offset-2">
                     <h4><asp:Label runat="server" ID="label_ProblemTitle"></asp:Label></h4> 
                    </div>
                     <div class="col-sm-8 col-sm-offset-2 well-sm">
                        <asp:RadioButton runat="server" ID="A"   Text="<%# Acontent %>" 
                             AutoPostBack="True" oncheckedchanged="A_CheckedChanged"/>
                    </div>
                     <div class="col-sm-8 col-sm-offset-2 well-sm">
                        <asp:RadioButton runat="server" ID="B"  Text="<%# Bcontent %>" 
                             AutoPostBack="True" oncheckedchanged="B_CheckedChanged"/>
                    </div>
                     <div class="col-sm-8 col-sm-offset-2 well-sm">
                        <asp:RadioButton runat="server" ID="C"  Text="<%# Bcontent %>" 
                             AutoPostBack="True" oncheckedchanged="C_CheckedChanged"/>
                    </div>
                     <div class="col-sm-8 col-sm-offset-2">
                        <asp:RadioButton runat="server" ID="D"  Text="<%# Bcontent %>" 
                             AutoPostBack="True" oncheckedchanged="D_CheckedChanged"/>
                    </div>
                     <div class="col-sm-8 col-sm-offset-2 well-sm">
                      <asp:Button runat="server" ID="Button5" CssClass="btn btn-info" Text="PREVIOUS" onclick="Button5_Click" /> 
                        &nbsp; &nbsp;
                        <asp:Button runat="server" ID="Button3" CssClass="btn btn-info" Text="Submit" 
                             onclick="Button3_Click"/> 
                        &nbsp; &nbsp;
                        <asp:Button runat="server" ID="Button4" CssClass="btn btn-info" Text="Next" 
                             onclick="Button4_Click"/>
                         <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                    <div class="col-sm-8 col-sm-offset-2">
                        <asp:TextBox  runat="server" TextMode="MultiLine" ID="txtExplaination"
                            Text="Answer and explaination upon submition" Height="49px" Width="318px"></asp:TextBox>
                    </div>
    </div>
</asp:Content>

