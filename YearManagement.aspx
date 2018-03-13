<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeFile="YearManagement.aspx.cs" Inherits="YearManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h4><small>ACADEMIC YEAR</small></h4>
    <table class="table table-border">
        <tr>
            <td>Year Start</td>
            <td><asp:TextBox class="form-control"  runat="server" TextMode="Date"  ID="txtStart" /></td>
        </tr>
        <tr>
            <td>Year End</td>
            <td><asp:TextBox class="form-control"  runat="server" TextMode="Date"  ID="txtEnd" /></td>
        </tr>
        <tr>
            <td>Closure Date</td>
            <td><asp:TextBox class="form-control"  runat="server" TextMode="Date"  ID="txtClosureDate" /></td>
        </tr>
        <tr>
            <td>Final Closure Date</td>
            <td><asp:TextBox class="form-control"  runat="server" TextMode="Date"  ID="txtFinalDate" /></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button runat="server"  class="btn btn-danger" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>
</asp:Content>

