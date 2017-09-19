<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="ShoppingCart2.ShoppingCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" OnRowCommand="Gridview_row_command" runat="server"  Height="317px" Width="458px" BackColor="White" BorderColor0="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"  AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="ChocolateName" HeaderText="ChocolateName" />
                <asp:BoundField Datafield="Brand" HeaderText="Brand" />
                <asp:BoundField Datafield="Price" HeaderText="Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            
            <asp:TemplateField HeaderText="Add To Cart">
                <itemTemplate>
                    <asp:Button Text="Add" runat="server" CommandName="Add" CommandArgument="<%#Container.DataItemIndex %>" />
                </itemTemplate>
            </asp:TemplateField>
                </Columns>
            <EmptyDataTemplate>
                <asp:Button ID="Button2" runat="server" Height="31px"  Text="Add" Width="62px" />
            </EmptyDataTemplate>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />

        </asp:GridView>
        <div style="margin-left: 160px">
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Btn_OnClick" Height="44px" Text="Checkout" Width="140px" />
            <asp:Button ID="Button5" runat="server" Height="44px" OnClick="Btn_Click" Text="AdminControl" Width="120px" />
        </div>
        <div style="margin-left: 160px">
        </div>
    </form>
</body>
</html>
