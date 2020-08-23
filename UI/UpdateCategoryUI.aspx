<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCategoryUI.aspx.cs" Inherits="StockMS.UI.UpdateCategoryUI" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Category</title>
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/myStyle.css" rel="stylesheet" />

</head>
<body>
<form runat="server" id="updateCategoryForm">
    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <div class="top-part">
                    <asp:Label ID="Label1" runat="server" Text="Update Category" Font-Size="Large"></asp:Label>
                   <!-- <asp:Button ID="Button2" runat="server" Text="HOME" class="btn btn-default pull-right" style="margin-right: 10px" /> -->
                    <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="HomeUI.aspx" CssClass="pull-right" style="margin-right: 20px; color: #ffffff">Home</asp:HyperLink>
                </div>                
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <div class="add-company">
                    <asp:Label ID="Label2" runat="server" Text="UPDATE CATEGORY"></asp:Label>
                </div>                
            </div>            
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="add-company-form">
                    
                        <asp:Label ID="Label3" runat="server" Text="Name" CssClass="add-company-form-label"></asp:Label>                           
                        <asp:TextBox ID="categoryNameTextBox" runat="server" CssClass="add-company-form-textbox"></asp:TextBox>
                        <asp:Label ID="errorLabel" runat="server" Text=" " CssClass="instruction-warning"></asp:Label><br /> <br/>
                        <asp:Label ID="messageLabel" runat="server" Text=" " CssClass="add-company-form-success instruction-success" style="margin-left: 125px;"></asp:Label><br/>
                        <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn btn-primary add-company-form-button" OnClick="updateButton_OnClick"/><br />
                        
                </div>
            </div>
        </div>
    </div>
</form> 
    
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    
    <script>
        $("#updateCategoryForm").validate({
            errorElement: 'div',
            rules: {
                categoryNameTextBox: "required"

            },
            messages: {
                categoryNameTextBox: "* Enter valid new Category Name *"
            }
        });
    </script>
</body>
</html>

