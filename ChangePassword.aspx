<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table class="table table-responsive">
        <tr>
            <td>New Pasword</td>
            <td>
                <asp:TextBox runat="server" ID="txtNew" TextMode="Password" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password cannot be empty" ControlToValidate="txtNew" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Confirm Password</td>
            <td>
                <asp:TextBox runat="server" ID="txtConfirm" TextMode="Password" />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNew" ControlToValidate="txtConfirm" ErrorMessage="Password and confirm password don't match" CssClass="alert alert-danger"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Submit" /></td>
        </tr>
    </table>
</asp:Content>

