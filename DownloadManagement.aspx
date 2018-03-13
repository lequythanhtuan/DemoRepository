<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeFile="DownloadManagement.aspx.cs" Inherits="DownloadManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:GridView CssClass="table table-bordered" class="pagination"  runat="server"
        AllowPaging="true" PageSize="5" DataKeyNames="IdeaID" OnPageIndexChanging="grvIdea_PageIndexChanging" ID="grvIdea" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="chkDown" OnCheckedChanged="chkDown_CheckedChanged" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Title" DataField="Title"/>
            <asp:BoundField HeaderText="View" DataField="Views" />
            <asp:BoundField HeaderText="Author" DataField="DisplayName" />
        </Columns>
    </asp:GridView>
    <asp:Button runat="server" ID="btnDownload" Text="Download" OnClick="btnDownload_Click"/>
</asp:Content>

