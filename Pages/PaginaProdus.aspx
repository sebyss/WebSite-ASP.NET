<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaginaProdus.aspx.cs" Inherits="Pages_PaginaProdus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 218px;
        }
        .auto-style2 {
            height: 82px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 852px; height: 620px">
        <tr>
            <td rowspan="4">
                <asp:Image ID="imgProdus" runat="server" CssClass="imagine"/></td>
            <td class="auto-style1">
                <h2>
                    <asp:Label ID="lblTitlu" runat="server" Text="Label"></asp:Label>
                    <hr/>
                </h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescriere" runat="server" CssClass="descriere" Text="Label"></asp:Label></td>
            <td>
                <asp:Label ID="lblPret" runat="server" CssClass="pret" Text="Label"></asp:Label></td><br />
                Cantitate:
                <asp:DropDownList ID="Cantitate" runat="server"></asp:DropDownList><br />
                <asp:Label ID="lblMesaj" runat="server" Text=""></asp:Label>
        </tr>
        <tr>
            <td class="auto-style2">Cod Produs: <asp:Label ID="lblCodProd" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="addCos" runat="server" OnClick="Button1_Click" CssClass="buton" Text="Adauga In Cos" />
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="disponibilitate" runat="server" Text=""></asp:Label></td>
                
            
        </tr>
    </table>
</asp:Content>

