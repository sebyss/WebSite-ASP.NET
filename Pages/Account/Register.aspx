<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Pages_Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .inputs {}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="litStatus" runat="server"></asp:Literal>
<br />
<br />
<asp:Label ID="lblusername" runat="server" Text="Nume Utilizator:"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="usertxt" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblparola" runat="server" Text="Parola:"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="pwtxt" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Confirmati Parola:"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="confirmtxt" runat="server" CssClass="inputs" TextMode="Password" Width="118px"></asp:TextBox>
    <br />
    <br />
    Nume:<br />
    <br />
    <asp:TextBox ID="txtNume" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    Prenume:<br />
    <br />
    <asp:TextBox ID="txtPrenume" runat="server" CssClass="inputs" ></asp:TextBox>
    <br />
    <br />
    Adresa:<br />
    <br />
    <asp:TextBox ID="txtAdresa" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    Cod Postal:<br />
    <br />
    <asp:TextBox ID="txtCodPostal" runat="server" CssClass="inputs"></asp:TextBox>
<br />
<br />
<asp:Button ID="Button" runat="server" CssClass="buton" OnClick="Button_Click" Text="Creare Cont" />
<br />
</asp:Content>

