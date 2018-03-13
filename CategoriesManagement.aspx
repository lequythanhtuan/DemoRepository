<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeFile="CategoriesManagement.aspx.cs" Inherits="CategoriesManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h4><small>CATEGORIES MANAGEMENT</small></h4>
    <table class="table table-border">
            <tr>
                <td>Name</td>
                <td><asp:TextBox runat="server" ID="txtName" class="form-control" /></td>
            </tr>
            <tr>
               <td></td>
                <td><asp:Button runat="server"  class="btn btn-danger" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" /></td>
            </tr>
     </table>
    <h4><small>CATEGORIES DETAIL</small></h4>
    <asp:GridView runat="server" ID="grvCategory" AutoGenerateColumns="false" CssClass="table table-border">
        <Columns>
            <asp:BoundField HeaderText="Name" DataField="Name" />
            <asp:BoundField HeaderText="CreateDate" DataField="CreateDate" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnDelete" Text="Delete"  class="glyphicons glyphicons-remove"
                        OnClick="btnDelete_Click" CommandArgument='<%#Eval("CatID") %>'>
                    </asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

