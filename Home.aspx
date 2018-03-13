<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h4><small>IDEA</small></h4>

    <br /><br />

    <asp:GridView CssClass="table table-bordered" class="pagination"  runat="server"
        AllowPaging="true" PageSize="5" OnPageIndexChanging="grvIdea_PageIndexChanging" ID="grvIdea" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbtnID" OnClick="lbtnID_Click"
                        CommandArgument=<%#Eval("IdeaID") %>
                        Text=<%#Eval("Title") %> />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="View" DataField="Views" />
            <asp:BoundField HeaderText="Author" DataField="DisplayName" />
        </Columns>
    </asp:GridView>
</asp:Content>

