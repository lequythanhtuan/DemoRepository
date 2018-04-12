<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeFile="IdeaManagement.aspx.cs" Inherits="IdeaManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h4><small>IDEA MANAGEMENT</small></h4>
    
    <table class="table table-responsive ">
        <tr>
            <td>Title</td>
            <td><asp:TextBox class="form-control" runat="server" ID="txtTitle" /></td>
            <td>
                <asp:RequiredFieldValidator CssClass="alert alert-danger" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title cannot be blank" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Categories</td>
            <td><asp:DropDownList class="form-control" runat="server" ID="ddlCategories" /></td>
        </tr>
        <tr>
            <td>Content</td>
            <td><asp:TextBox class="form-control" rows="5" TextMode="MultiLine" runat="server" ID="txtContent" /></td>
        <td>
                <asp:RequiredFieldValidator CssClass="alert alert-danger" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContent" ErrorMessage="Content cannot be blank" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
            </tr>
        <tr>
            <td>Anonymous</td>
            <td><asp:CheckBox class="checkbox-inline" runat="server" ID="chkAnony" Text="Do you want to be anonymous" /></td>
        </tr>
        <tr>
            <td>Attach File</td>
            <td><asp:FileUpload runat="server" ID="fileUpload" AllowMultiple="true"/></td>
        </tr>
        <tr>
            <td>Term of Reference</td>
            <td>
                <asp:TextBox  class="form-control" rows="5" runat="server" TextMode="MultiLine"
                 Text="This template is designed to help you develop terms of reference for a group such as a project advisory group or panel. The suggested headings and questions are not intended to be prescriptive but will give you some ideas based on what other people have included in their terms of reference. The ‘See also’ boxes on this page contain a Word version of this template which can be edited or adapted to suit your needs (for non-commerical purposes), together with some real-life examples of terms of reference."/>
                <br />
                <asp:CheckBox class="checkbox-inline" runat="server" ID="chkToR" Text="I agree with terms and reference"/> 
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button runat="server" ID="btnSubmit" class="btn btn-danger" Text="Submit" OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>
</asp:Content>

