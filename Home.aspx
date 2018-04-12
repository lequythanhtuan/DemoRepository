<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><small>IDEA</small></h4>

    <%--<asp:DropDownList CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged" runat="server" ID="ddlFilter">
        <asp:ListItem Text="List Of Thumbs Up" Value="1" />
        <asp:ListItem Text="List Of Thumbs Down" Value="2" />
        <asp:ListItem Text="List Of Views Ideas" Value="3" />
        <asp:ListItem Text="List Of Last Ideas" Value="4" />
        <asp:ListItem Text="List Of Last Comment" Value="5" />
    </asp:DropDownList>--%>

    <asp:GridView CssClass="table table-bordered" class="pagination" runat="server"
                AllowPaging="true" PageSize="5" OnPageIndexChanging="grvIdea_PageIndexChanging" ID="grvIdea" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Title">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbtnID" OnClick="lbtnID_Click"
                                CommandArgument='<%#Eval("IdeaID") %>'
                                Text='<%#Eval("Title") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="View" DataField="Views" />
                    <asp:BoundField HeaderText="Author" DataField="DisplayName" />
               <%--     <asp:BoundField HeaderText="Like" DataField="SoLuong" />--%>
                    <asp:BoundField HeaderText="Created Date" DataField="DateCreated" DataFormatString="{0:dd/MM/yyyy}" />
                </Columns>
            </asp:GridView>


</asp:Content>

