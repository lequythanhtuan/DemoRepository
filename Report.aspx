<%@ Page Title="" Language="C#" MasterPageFile="~/FramePage.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Number of ideas made by each Department</h2>
    <asp:GridView runat="server" ID="grvReport" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Name"  HeaderText="Department" />
            <asp:BoundField DataField="QuantityOfIdeas"  HeaderText="Quantity Of Ideas" />
            <asp:TemplateField HeaderText="Percent">
                <ItemTemplate>
                    <asp:Label runat="server"  ID="lbPercent" Text='<%#Eval("Percent") %>' />%
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

