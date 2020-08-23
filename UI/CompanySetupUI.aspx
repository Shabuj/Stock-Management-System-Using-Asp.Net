<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanySetupUI.aspx.cs" Inherits="StockMS.UI.CompanySetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Company Setup</title>
    <link href="../css/OtherPage/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/OtherPage/css/media.css" rel="stylesheet" />
    <link href="../css/OtherPage/css/style.css" rel="stylesheet" />
<link href="../css/myStyle.css" rel="stylesheet" />
</head>
<body>
<form runat="server" id="companySetupForm">
<div class="container">
    <div class="row">
        <div class="col-sm-12">
            <div class="top-part">
                <asp:Label ID="Label1" runat="server" Text="Company Setup" Font-Size="Large"></asp:Label>
                <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="HomeUI.aspx" CssClass="pull-right" style="margin-right: 20px; color: #ffffff">Home</asp:HyperLink>
            </div>                
        </div>
    </div>
</div>
<div class="container">
    <div class="row">
        <div class="col-sm-12">
            <div class="add-company">
                <asp:Label ID="Label2" runat="server" Text="ADD COMPANY"></asp:Label>
            </div>                
        </div>            
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="add-company-form">
                
                    <asp:Label ID="Label3" runat="server" Text="Name" CssClass="add-company-form-label"></asp:Label>                           
                    <asp:TextBox ID="companyNameTextBox" runat="server" CssClass="add-company-form-textbox"></asp:TextBox>
                    <asp:Label ID="errormessageLabel" runat="server" Text=" " CssClass="instruction-warning"></asp:Label><br /> <br/>
                    <asp:Label ID="outputMessageLabel" runat="server" Text=" " CssClass="add-company-form-success instruction-success" style="margin-left: 125px;"></asp:Label><br/>
                    <asp:Button ID="companySaveButton" runat="server" Text="Save" CssClass="btn btn-primary add-company-form-button" OnClick="saveButton_Click"/><br />
                    <asp:GridView ID="companyGridView" runat="server" CssClass="add-company-form-table" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
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
                                
                            <asp:TemplateField HeaderText="Company Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("CompanyName") %>' style="margin: 0px 45px" ></asp:Label>
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
        $("#companySetupForm").validate({
            errorElement: 'div',
            rules: {
                companyNameTextBox: "required"

            },
            messages: {
                companyNameTextBox: "* Enter valid Company Name *"
            }
        });

 
    </script>
</body>
</html>
