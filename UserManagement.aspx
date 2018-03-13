<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="UserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><small>USERS MANAGEMENT</small></h4>
    <table class="table table-border">
        <tr runat="server" id="dvDep">
            <td>Department</td>
            <td>
                <asp:DropDownList class="form-control" runat="server" ID="ddlDep" AutoPostBack="true" /></td>
        </tr>
        <tr>
            <td>User ID</td>
            <td>
                <asp:TextBox class="form-control" runat="server" ID="txtUserID" /></td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox class="form-control" TextMode="Password" runat="server" ID="txtPassword" /></td>
        </tr>
        <tr>
            <td>First Name</td>
            <td>
                <asp:TextBox class="form-control" runat="server" ID="txtFirst" /></td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td>
                <asp:TextBox class="form-control" runat="server" ID="txtLast" /></td>
        </tr>
        <tr>
            <td>BirthDate</td>
            <td>
                <asp:TextBox class="form-control" runat="server" TextMode="Date" ID="txtBirth" /></td>
        </tr>
        <tr>
            <td>Gender</td>
            <td>
                <asp:RadioButton class="checkbox-inline" runat="server" ID="gen1" Checked="true" Text="Male" GroupName="groupGen" />
                <asp:RadioButton class="checkbox-inline" runat="server" ID="gen2" Text="Female" GroupName="groupGen" />
        </tr>
        <tr>
            <td>Phone</td>
            <td>
                <asp:TextBox runat="server" class="form-control" ID="txtPhone" /></td>
        </tr>
        <tr>
            <td>Address</td>
            <td>
                <asp:TextBox class="form-control" runat="server" ID="txtAddress" /></td>
        </tr>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox class="form-control" runat="server" ID="txtEmail" /></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button runat="server" class="btn btn-danger" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>
</asp:Content>

