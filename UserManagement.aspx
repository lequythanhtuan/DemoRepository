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
                <asp:TextBox class="form-control" runat="server" ID="txtUserID" />
            </td>
            <td>
                <asp:RequiredFieldValidator CssClass="alert alert-danger" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserID" ErrorMessage="UserID cannot be blank" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr runat="server" id="dvPassword">
            <td>Password</td>
            <td>
                <asp:TextBox class="form-control" TextMode="Password" runat="server" ID="txtPassword" ControlToValidate="txtPassword" /></td>
        </tr>
        <tr>
            <td>First Name</td>
            <td>
                <asp:TextBox class="form-control" runat="server" ID="txtFirst" />
            </td>
            <td>
                <asp:RequiredFieldValidator CssClass="alert alert-danger" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirst" ErrorMessage="First Name cannot be blank" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td>
                <asp:TextBox class="form-control" runat="server" ID="txtLast" />
            </td>
            <td>
                <asp:RequiredFieldValidator CssClass="alert alert-danger" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLast" ErrorMessage="Last Name cannot be blank" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>BirthDate</td>
            <td>
                <asp:TextBox class="form-control" runat="server" TextMode="Date" ID="txtBirth" />
            </td>
            <td>
                <asp:RequiredFieldValidator CssClass="alert alert-danger" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBirth" ErrorMessage="BirthDay cannot be blank" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Gender</td>
            <td>
                <asp:RadioButtonList runat="server" CssClass="checkbox-inline" ID="btlGender">
                    <asp:ListItem Value="True" Text="Male" />
                    <asp:ListItem Value="False" Text="Female" />
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Phone</td>
            <td>
                <asp:TextBox runat="server" class="form-control" ID="txtPhone" />
            </td>
            <td>
                <asp:CompareValidator CssClass="alert alert-danger" ID="CompareValidator1" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone must be a number" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Integer"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Address</td>
            <td>
                <asp:TextBox class="form-control" runat="server" ID="txtAddress" />
            </td>
            <td>
                <asp:RequiredFieldValidator CssClass="alert alert-danger" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address cannot be blank" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox class="form-control" runat="server" ID="txtEmail" />
            </td>
            <td>
                <asp:RegularExpressionValidator CssClass="alert alert-danger" ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email must be follow format" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button runat="server" class="btn btn-danger" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>
</asp:Content>

