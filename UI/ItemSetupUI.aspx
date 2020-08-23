<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSetupUI.aspx.cs" Inherits="StockMS.UI.ItemSetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Item Setup</title>

    <link href="../css/myStyle.css" rel="stylesheet" />
</head>
<body>
<form runat="server" id="itemSetupForm">
    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <div class="top-part">
                    <asp:Label ID="Label" runat="server" Text="Item Setup" Font-Size="Large"></asp:Label>
                    <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="HomeUI.aspx" CssClass="pull-right" style="margin-right: 20px; color: #ffffff">Home</asp:HyperLink>                </div>                
            </div>
        </div>
    </div>

    <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="add-company">
                        <asp:Label ID="la" runat="server" Text="ADD ITEM"></asp:Label>
                    </div>                
                </div>            
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="add-company-form">
                        
                            <asp:Label ID="Label1" runat="server" Text="Category" CssClass=""></asp:Label>
                            <asp:DropDownList ID="categoryDropDownList" runat="server" CssClass="add-company-form-dropdown">
                                <asp:ListItem Text="--Select Category--" Value=""/> 
                            </asp:DropDownList>
                            <asp:Label ID="noCategorySelectDropDownError" runat="server" Text="" CssClass="instruction-warning"></asp:Label><br/><br/>

                            <asp:Label ID="Label2" runat="server" Text="Company" CssClass=""></asp:Label>
                            <asp:DropDownList ID="companyDropDownList" runat="server" CssClass="add-company-form-dropdown">
                                <asp:ListItem Enabled="true" Text="" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="--Select Category--" Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="noCompanySelectDropDownError" runat="server" Text="" CssClass="instruction-warning"></asp:Label><br/><br/>

                            <asp:Label ID="Label3" runat="server" Text="Item Name" CssClass="add-item-name-margin"></asp:Label>
                            <asp:TextBox ID="itemNameTextBox" runat="server"  CssClass="add-company-form-textbox"></asp:TextBox>
                            <asp:Label ID="emptyItemNameTextboxError" runat="server" Text="" CssClass="instruction-warning"></asp:Label><br/><br/>

                            <asp:Label ID="Label4" runat="server" Text="Reorder Level" CssClass="add-item-reorder-margin"></asp:Label>
                            <asp:TextBox ID="reorderLevelTextBox" runat="server"  CssClass="add-company-form-textbox" Text="0"></asp:TextBox>
                            <asp:Label ID="emptyReorderLevelTextBoxError" runat="server" Text=" " CssClass="instruction-warning"></asp:Label><br/><br/>

                            <asp:Label ID="messageLabel" runat="server" Text="" CssClass="instruction-success "></asp:Label><br/>
                            <asp:Button ID="saveButton" runat="server" Text="Save"  CssClass="btn btn-primary add-item-form-button" OnClick="saveButton_OnClick"/>
                        
                    </div>
                </div>
            </div>
        </div>
</form>
    
    
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    
    <script>

        $("#itemSetupForm").validate({
            errorElement: 'div',
            rules: {
                categoryDropDownList: { min: 1 },
                companyDropDownList: { min: 1 },
                itemNameTextBox: "required",
                reorderLevelTextBox: {
                    required: true,
                    digits: true
                }
            },
            messages: {
                categoryDropDownList: "* Choose at least one Category from dropdown *",
                companyDropDownList: "* Choose at least one Company from dropdown *",
                itemNameTextBox: "* Enter a valid Item name in this field *",
                reorderLevelTextBox: "* Enter Reorder Level on number (default is 0) *"
            }
        });
    </script>
</body>
</html>
