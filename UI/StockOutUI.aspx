<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockMS.UI.StockOutUI" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Out</title>
 <link href="../css/myStyle.css" rel="stylesheet" />
<link href="../css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="stockOutForm" runat="server">
    
        <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <div class="top-part">
                    <asp:Label ID="Label" runat="server" Text="STOCK OUT" Font-Size="Large"></asp:Label>
                    <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="HomeUI.aspx" CssClass="pull-right" style="margin-right: 20px; color: #ffffff">Home</asp:HyperLink>                </div>                
            </div>
        </div>
    </div>

    <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="add-company">
                        <asp:Label ID="la" runat="server" Text="STOCK OUT"></asp:Label>
                    </div>                
                </div>            
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="stock-out-form">
                        <asp:Label ID="Label1" runat="server" Text="Company" CssClass=""></asp:Label>
                        <asp:DropDownList ID="companyDropDownList" runat="server" CssClass="stock-in-company-dropdown" AutoPostBack="True" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged">
                            
                        </asp:DropDownList>
                        <asp:Label ID="companySelectionErrorLabel" runat="server" Text="" CssClass="instruction-warning"></asp:Label><br/><br/>

                        <asp:Label ID="Label2" runat="server" Text="Item" CssClass=""></asp:Label>
                        <asp:DropDownList ID="itemDropDownList" runat="server" CssClass="stock-in-item-dropdown" AutoPostBack="True" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged">
                            
                        </asp:DropDownList>
                        <asp:Label ID="itemSelectionErrorLabel" runat="server" Text="" CssClass="instruction-warning"></asp:Label><br/><br/>

                        <asp:Label ID="Label3" runat="server" Text="Reorder Level" CssClass="stock-in-reorder-margin"></asp:Label>
                        <asp:TextBox ID="reorderLevelTextBox" runat="server"  CssClass="add-company-form-textbox" Enabled="False"></asp:TextBox><br/><br/>

                        <asp:Label ID="Label4" runat="server" Text="Available Quantity" CssClass="stock-in-available-quantity"></asp:Label>
                        <asp:TextBox ID="availableQuantityTextBox" runat="server"  CssClass="add-company-form-textbox" Enabled="False"></asp:TextBox><br/><br/>
                        
                        <asp:Label ID="Label7" runat="server" Text="Stock Out Quantity" style="margin-right: 15px;"></asp:Label>
                        <asp:TextBox ID="stockOutQuantityTextBox" runat="server" CssClass="add-company-form-textbox"></asp:TextBox>
                        <asp:Label ID="stockEmptyErrorLabel" runat="server" Text="" CssClass="instruction-warning"></asp:Label><br/><br/>

                        <asp:Label ID="stockNotAvailableErrorLabel" runat="server" Text="" CssClass="instruction-success "></asp:Label><br/>
                        <asp:Button ID="addButton" runat="server" Text="Add"  CssClass="btn btn-primary stock-in-save-button" OnClick="addButton_OnClick"/><br/><br/>
                        
                        <asp:GridView ID="addItemGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        
                        <asp:Label ID="outputLabel" runat="server" Text="" CssClass="instruction-success"></asp:Label><br/> <br/>

                        <asp:Button ID="sellButton" formnovalidate="formnovalidate" runat="server" Text="Sell" CssClass="btn btn-primary stock-in-save-button" style="margin-left: 250px" OnClick="sellButton_Click" />
                        <asp:Button ID="damageButton" formnovalidate="formnovalidate" runat="server" Text="Damage" CssClass="btn btn-primary stock-in-save-button" style="margin-left: 2px" OnClick="damageButton_Click" />
                        <asp:Button ID="lostButton" formnovalidate="formnovalidate" runat="server" Text="Lost" CssClass="btn btn-primary stock-in-save-button" style="margin-left: 2px" OnClick="lostButton_Click" />
                    </div>
                </div>
            </div>
        </div>

    </form>
    
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    
    <script>
        $("#stockOutForm").validate({
            errorElement: 'div',
            rules: {
                companyDropDownList: { min: 1 },
                itemDropDownList: { min: 1 },
                stockOutQuantityTextBox: {
                    required: true,
                    digits: true
                }

            },
            messages: {
                companyDropDownList: "* Choose at least one Company from dropdown *",
                itemDropDownList: "* Choose at least one Item from dropdown *",
                stockOutQuantityTextBox: "* Enter valid Quantity in number *"
            }
        });
    </script>
</body>
</html>
