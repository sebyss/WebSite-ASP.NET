<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Management.aspx.cs" Inherits="Pages_Angajati_Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinkButton CssClass="buton" ID="AddProd" runat="server" PostBackUrl="~/Pages/Angajati/AddProdus.aspx">Adauga Produs</asp:LinkButton>
    <br />
<br />
<asp:GridView ID="listProd" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="dbProd" Width="1054px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowEditing="ListProd_RowEditing" OnSelectedIndexChanged="listProd_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
        <asp:BoundField DataField="TypeID" HeaderText="TypeID" SortExpression="TypeID" />
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
        <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
        <asp:BoundField DataField="Stoc" HeaderText="Stoc" SortExpression="Stoc" />
    </Columns>
    <FooterStyle BackColor="White" ForeColor="#000066" />
    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
    <RowStyle ForeColor="#000066" />
    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#007DBB" />
    <SortedDescendingCellStyle Width="100%" BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#00547E" />
</asp:GridView>
<asp:SqlDataSource ID="dbProd" runat="server" ConnectionString="<%$ ConnectionStrings:FarmacieConnectionString %>" DeleteCommand="DELETE FROM [Produs] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Produs] ([TypeID], [Name], [Price], [Description], [Image], [Stoc]) VALUES (@TypeID, @Name, @Price, @Description, @Image, @Stoc)" SelectCommand="SELECT * FROM [Produs]" UpdateCommand="UPDATE [Produs] SET [TypeID] = @TypeID, [Name] = @Name, [Price] = @Price, [Description] = @Description, [Image] = @Image, [Stoc] = @Stoc WHERE [ID] = @ID">
    <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="TypeID" Type="Int32" />
        <asp:Parameter Name="Name" Type="String" />
        <asp:Parameter Name="Price" Type="Double" />
        <asp:Parameter Name="Description" Type="String" />
        <asp:Parameter Name="Image" Type="String" />
        <asp:Parameter Name="Stoc" Type="Int32" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="TypeID" Type="Int32" />
        <asp:Parameter Name="Name" Type="String" />
        <asp:Parameter Name="Price" Type="Double" />
        <asp:Parameter Name="Description" Type="String" />
        <asp:Parameter Name="Image" Type="String" />
        <asp:Parameter Name="Stoc" Type="Int32" />
        <asp:Parameter Name="ID" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
<br />
<br />
    <asp:LinkButton CssClass="buton" ID="AddCateg" runat="server" PostBackUrl="~/Pages/Angajati/Admin.aspx">Adauga Categorie</asp:LinkButton>
    <br />
<br />
<asp:GridView ID="listCateg" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="dbCateg" Width="367px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
    </Columns>
    <FooterStyle BackColor="White" ForeColor="#000066" />
    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
    <RowStyle ForeColor="#000066" />
    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#007DBB" />
    <SortedDescendingCellStyle Width="100%" BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#00547E" />
</asp:GridView>
<asp:SqlDataSource ID="dbCateg" runat="server" ConnectionString="<%$ ConnectionStrings:FarmacieConnectionString %>" DeleteCommand="DELETE FROM [ProdusTip] WHERE [ID] = @ID" InsertCommand="INSERT INTO [ProdusTip] ([Name]) VALUES (@Name)" SelectCommand="SELECT * FROM [ProdusTip]" UpdateCommand="UPDATE [ProdusTip] SET [Name] = @Name WHERE [ID] = @ID">
    <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Name" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Name" Type="String" />
        <asp:Parameter Name="ID" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
</asp:Content>

