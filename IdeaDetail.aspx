<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeFile="IdeaDetail.aspx.cs" Inherits="IdeaDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:DataList runat="server" ID="dtlIdea" RepeatColumns="1" RepeatDirection="Horizontal">
        <ItemTemplate>
            <table>
                <tr>
                    <h2><%#Eval("Title") %></h2>
                </tr>
                <tr>
                    <h5><span class="glyphicon glyphicon-time"></span>Post by <%#Eval("DisplayName") %>,<small><%#Eval("DateCreated") %>.</small></h5>
                    <tr>
                        <p>
                            <%#Eval("Content") %>
                            <small>
                                <asp:LinkButton runat="server" OnClick="lbtnEdit_Click" ID="lbtnEdit" Text="Edit" /></small>
                        </p>
                    </tr>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>

    <br />
    <br />
    <asp:RadioButtonList OnSelectedIndexChanged="rbtnStatus_SelectedIndexChanged"
        runat="server" ID="rbtnStatus"
        CssClass="radio radio-inline"
        AutoPostBack="true">
        <asp:ListItem Value="0" style="display: none" />
        <asp:ListItem Text="Like" Value="1" />
        <asp:ListItem Text="Dislike" Value="2" />
    </asp:RadioButtonList>
    <br />
    <br />
    <h4>Leave a comment:</h4>
    <div class="form-group">
        <asp:TextBox runat="server" CssClass="form-control" ID="txtComment" TextMode="MultiLine" Rows="3" />
        <asp:CheckBox class="checkbox-inline" runat="server" ID="chkAnony" Text="Do you want to be anonymous" />
        <br />
    </div>
    <asp:Button runat="server" class="btn btn-success" ID="btnSubmit" Text="Comment" OnClick="btnSubmit_Click" />
    <br>
    <br>

    <p><span class="badge" id="span" runat="server"></span>Comments:</p>
    <br>

    <div class="row">
        <div class="col-sm-12">
            <asp:DataList runat="server" ID="dtComment" RepeatColumns="1" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <table>
                        <tr>
                            <h4><%#Eval("DisplayName") %>, <small><%#Eval("DateCreated") %></small></h4>
                        </tr>
                        <tr>
                            <td>
                                <p><%#Eval("Content") %></p>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <br>
        </div>
    </div>


</asp:Content>

