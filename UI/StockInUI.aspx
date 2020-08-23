<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockInUI.aspx.cs" Inherits="StockMS.UI.StockInUI" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Stock In</title>
  <link href="../css/style.css" rel="stylesheet" />
<link href="../css/myStyle.css" rel="stylesheet" />
</head>
<body>
<form runat="server" id="stockInForm">
    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <div class="top-part">
                    <asp:Label ID="Label" runat="server" Text="STOCK IN" Font-Size="Large"></asp:Label>
                    <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="HomeUI.aspx" CssClass="pull-right" style="margin-right: 20px; color: #ffffff">Home</asp:HyperLink>                </div>                
            </div>
        </div>
    </div>

    <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="add-company">
                        <asp:Label ID="la" runat="server" Text="STOCK IN"></asp:Label>
                    </div>                
                </div>            
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="add-company-form">
                        
                            <asp:Label ID="Label1" runat="server" Text="Company" CssClass=""></asp:Label>
                            <asp:DropDownList ID="companyDropDownList" runat="server" CssClass="stock-in-company-dropdown" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged" AutoPostBack="True">
                                
                            </asp:DropDownList>
                            <asp:Label ID="companySelectionErrorLabel" runat="server" Text="" CssClass="instruction-warning"></asp:Label><br/><br/>

                            <asp:Label ID="Label2" runat="server" Text="Item" CssClass=""></asp:Label>
                            <asp:DropDownList ID="itemDropDownList" runat="server" CssClass="stock-in-item-dropdown" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged" AutoPostBack="True">
                                
                            </asp:DropDownList>
                            <asp:Label ID="itemSelectionErrorLabel" runat="server" Text="" CssClass="instruction-warning"></asp:Label><br/><br/>

                            <asp:Label ID="Label3" runat="server" Text="Reorder Level" CssClass="stock-in-reorder-margin"></asp:Label>
                            <asp:TextBox ID="reorderLevelTextBox" runat="server"  CssClass="add-company-form-textbox" Enabled="False"></asp:TextBox><br/><br/>

                            <asp:Label ID="Label4" runat="server" Text="Available Quantity" CssClass="stock-in-available-quantity"></asp:Label>
                            <asp:TextBox ID="quantityTextBox" runat="server"  CssClass="add-company-form-textbox" Enabled="False"></asp:TextBox><br/><br/>
                            
                            <asp:Label ID="Label7" runat="server" Text="Stock In Quantity" CssClass="stock-in-quantity-label"></asp:Label>
                            <asp:TextBox ID="stockInQuantityTextBox" runat="server" CssClass="add-company-form-textbox"></asp:TextBox>
                            <asp:Label ID="quantityEmptyTextBoxMessage" runat="server" Text="" CssClass="instruction-warning"></asp:Label><br/><br/>

                            <asp:Label ID="messageLabel" runat="server" Text="" CssClass="instruction-success "></asp:Label><br/>
                            <asp:Button ID="saveButton" runat="server" Text="Save"  CssClass="btn btn-primary stock-in-save-button" OnClick="saveButton_OnClick"/>
                        
                    </div>
                </div>
            </div>
        </div>
</form>
    
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    
    <script>
        $("#stockInForm").validate({
            errorElement: 'div',
            rules: {
                companyDropDownList: { min: 1 },
                itemDropDownList: { min: 1 },
                stockInQuantityTextBox: {
                    required: true,
                    digits: true
                }
            },
            messages: {
                companyDropDownList: "* Choose at least one Company from dropdown *",
                itemDropDownList: "* Choose at least one Item from dropdown *",
                stockInQuantityTextBox: "* Enter quantity in number *"
            }
        });
    </script>
</body>
</html>
