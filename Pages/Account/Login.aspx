<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="litStatus2" runat="server"></asp:Literal>

<br />
<br />
Nume Utilizator:<br />
<br />
<asp:TextBox ID="txtuser" runat="server" CssClass="inputs" OnTextChanged="TextBox1_TextChanged" style="margin-left: 0px"></asp:TextBox>
<br />
<br />
Parola:<br />
<asp:TextBox ID="txtpass" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
<br />
<br />
<asp:Button ID="btnLogin" runat="server" CssClass="buton" OnClick="btnLogin_Click" Text="Conectare" />
<br />

</asp:Content>

