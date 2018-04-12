<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeFile="FindUser.aspx.cs" Inherits="FindUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><small>USERS MANAGEMENT</small></h4>
    <table>
        <tr>
            <td>
                <asp:DropDownList class="form-control" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" runat="server" ID="ddlRole" AutoPostBack="true" /></td>
            <td>
                <asp:Button runat="server" ID="btnSubmit" Text="Add" class="btn btn-danger"
                    OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>
    <h4><small>USERS INFORMATION</small></h4>
    <asp:GridView runat="server" ID="grvUser" CssClass="table table-responsive" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="User ID">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbtnId" Text='<%#Eval("IDUsers") %>'
                        OnClick="lbtnId_Click"
                        CommandArgument='<%#Eval("ID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Name" DataField="Name" />
            <asp:BoundField HeaderText="Birthdate" DataField="Birthdate" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField HeaderText="Gender">
                <ItemTemplate>
                    <%#bool.Parse(Eval("Gender").ToString())?"Male" : "Female" %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Phone" DataField="Phone" />
            <asp:BoundField HeaderText="Address" DataField="Address" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Department" DataField="DepartmentName" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnPassword" Text="Default Password" OnClick="btnPassword_Click" CommandArgument='<%#Eval("ID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

