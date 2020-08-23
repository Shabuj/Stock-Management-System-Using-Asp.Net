<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategorySetupUI.aspx.cs" Inherits="StockMS.UI.CategorySetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Category Setup</title>
   
<link href="../content/css/sb-admin.css" rel="stylesheet" />
<link href="../content/css/sb-admin.min.css" rel="stylesheet" />
<link href="../css/myStyle.css" rel="stylesheet" />
<link href="../css/style.css" rel="stylesheet" />
</head>
<body>
<form runat="server" id="categorySetupForm">
    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <div class="top-part">
                    <asp:Label ID="Label1" runat="server" Text="Category Setup" Font-Size="Large"></asp:Label>
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
                    <asp:Label ID="Label2" runat="server" Text="ADD CATEGORY"></asp:Label>
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
                        <asp:Button ID="saveCategoryButton" runat="server" Text="Save" CssClass="btn btn-primary add-company-form-button" OnClick="saveCategoryButton_Click"/><br />
                        
                       <asp:GridView ID="categoryGridView" runat="server" style="align-content:center" CssClass="add-category-form-table" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
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
                        
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("SL")%>' style="margin: 0px 45px" ></asp:Label>
                                    <asp:HiddenField ID="idHiddenField" runat="server" Value='<% #Eval("Id")%>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                                
                             <asp:TemplateField HeaderText="Category Name">
                                    <ItemTemplate>
                                        <asp:LinkButton  ID="updateButton" Font-Overline="false"  OnClick="updateButton_OnClick" runat="server" Text='<%#Eval("CategoryName") %>'></asp:LinkButton>
                                      
                                        </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                
                    
                </div>
            </div>
        </div>
    </div>
</form>
    
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
   <script src="../Scripts/jquery.validate.min.js"></script>
    
    <script>
        $("#categorySetupForm").validate({
            errorElement: 'div',
            rules: {
                categoryNameTextBox: "required"

            },
            messages: {
                categoryNameTextBox: "* Enter valid Category Name *"
            }
        });


     
    </script>    
</body>
</html>

