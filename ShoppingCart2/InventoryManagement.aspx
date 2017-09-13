<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryManagement.aspx.cs" Inherits="ShoppingCart2.InventoryManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ChocolateName" DataSourceID="SqlDataSource2" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ChocolateName" HeaderText="ChocolateName" ReadOnly="True" SortExpression="ChocolateName" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Shopping CartConnectionString %>" DeleteCommand="DELETE FROM [ShoppingCart] WHERE [ChocolateName] = @ChocolateName" InsertCommand="INSERT INTO [ShoppingCart] ([ChocolateName], [Price], [Brand], [Quantity]) VALUES (@ChocolateName, @Price, @Brand, @Quantity)" SelectCommand="SELECT * FROM [ShoppingCart]" UpdateCommand="UPDATE [ShoppingCart] SET [Price] = @Price, [Brand] = @Brand, [Quantity] = @Quantity WHERE [ChocolateName] = @ChocolateName">
            <DeleteParameters>
                <asp:Parameter Name="ChocolateName" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ChocolateName" Type="String" />
                <asp:Parameter Name="Price" Type="Int32" />
                <asp:Parameter Name="Brand" Type="String" />
                <asp:Parameter Name="Quantity" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Price" Type="Int32" />
                <asp:Parameter Name="Brand" Type="String" />
                <asp:Parameter Name="Quantity" Type="Int32" />
                <asp:Parameter Name="ChocolateName" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
