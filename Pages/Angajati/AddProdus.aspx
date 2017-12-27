<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddProdus.aspx.cs" Inherits="Pages_AddProdus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    Nume:</p>
<p>
    <asp:TextBox ID="txtnume" runat="server"></asp:TextBox>
</p>
<p>
    Categoria:</p>
<p>
    <asp:DropDownList ID="categdrop" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FarmacieConnectionString %>" SelectCommand="SELECT * FROM [ProdusTip] ORDER BY [Name]"></asp:SqlDataSource>
</p>
<p>
    Pret:</p>
<p>
    <asp:TextBox ID="txtpret" runat="server"></asp:TextBox>
</p>
    <p>
        Stoc:</p>
    <p>
        <asp:TextBox ID="textStoc" runat="server"></asp:TextBox>
</p>
<p>
    Imagine:</p>
<p>
    <asp:DropDownList ID="dropimg" runat="server" OnSelectedIndexChanged="Dropimg_SelectedIndexChanged">
    </asp:DropDownList>
</p>
<p>
    Descriere:</p>
<p>
    <asp:TextBox ID="textdescriere" runat="server" Height="76px" TextMode="MultiLine" Width="264px"></asp:TextBox>
</p>
<p>
    &nbsp;</p>
<p>
    <asp:Button ID="realizprod" runat="server" Text="Realizat" OnClick="Realizprod_Click" />
</p>
<p>
    <asp:Label ID="lblprod" runat="server"></asp:Label>
</p>
<p>
    &nbsp;</p>
</asp:Content>

