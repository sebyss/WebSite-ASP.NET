<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cos.aspx.cs" Inherits="Pages_Cos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlCos" runat="server">

    </asp:Panel>
     <table>
            <tr>
                <td>
                    <b>Total: </b>
                </td>
                <td>
                    <asp:Literal ID="litTotal" runat="server" Text=""></asp:Literal>
                </td>
            </tr>

            <tr>
                <td>
                    <b>TVA: </b>
                </td>
                <td>
                    <asp:Literal ID="litTva" runat="server" Text="" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Transport: </b>
                </td>
                <td>
                    14.99lei
                </td>
            </tr>

            <tr>
                <td>
                    <b>TOTAL: </b>
                </td>
                <td>
                    <asp:Literal ID="litPtotal" runat="server" Text="" />
                </td>
            </tr>

            <tr>
                <td>
                    <br />
                    <asp:LinkButton CssClass="buton" ID="LinkButton1" runat="server" PostBackUrl="~/Pages/Produse.aspx">Continuati Cumparaturile</asp:LinkButton> &nbsp;&nbsp; sau                     
                    <asp:Button ID="btnCheckout" runat="server" Text="Plasati Comanda" CssClass="buton" Width="250px" PostBackUrl="~/Pages/Success.aspx" OnClick="btnCheckout_Click" />

                    <br />
                    
                    

                </td>
            </tr>

        </table>

</asp:Content>

