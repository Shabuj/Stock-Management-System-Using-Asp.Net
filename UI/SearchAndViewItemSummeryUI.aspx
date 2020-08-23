<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchAndViewItemSummeryUI.aspx.cs" Inherits="StockMS.UI.SearchAndViewItemSummeryUI" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search & View Items Summary</title>
       <link href="../css/myStyle.css" rel="stylesheet" />
   <link href="../css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <div class="top-part">
                    <asp:Label ID="Label" runat="server" Text="Search & View Items Summary" Font-Size="Large"></asp:Label>
                    <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="HomeUI.aspx" CssClass="pull-right" style="margin-right: 20px; color: #ffffff">Home</asp:HyperLink>                </div>                
            </div>
        </div>
    </div>

    <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="add-company">
                        <asp:Label ID="la" runat="server" Text="Search & View Items Summary"></asp:Label>
                    </div>                
                </div>            
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="add-company-form">
                        
                            <asp:Label ID="Label1" runat="server" Text="Company" CssClass=""></asp:Label>
                            <asp:DropDownList ID="companyDropDownList" runat="server" CssClass="add-company-form-dropdown" AutoPostBack="True">
                                
                            </asp:DropDownList><br/><br/>
                           <!-- <asp:Label ID="Label5" runat="server" Text="company not selected" CssClass="instruction-warning"></asp:Label> -->

                            <asp:Label ID="Label2" runat="server" Text="Category" CssClass=""></asp:Label>
                            <asp:DropDownList ID="categoryDropDownList" runat="server" CssClass="add-company-form-dropdown" AutoPostBack="True">
                                
                            </asp:DropDownList><br/><br/>
                            <!--<asp:Label ID="Label6" runat="server" Text="category not selected" CssClass="instruction-warning"></asp:Label> -->
                            <asp:Label ID="errorLabel" runat="server" Text=" " CssClass="instruction-warning" style="margin-left: 150px;"></asp:Label><br/><br/>

                            <asp:Button ID="searchButtton" runat="server" Text="Search"  CssClass="btn btn-primary add-item-form-button" style="margin-left: 341px" OnClick="searchButtton_OnClick"/>
                            <asp:GridView ID="showSearchedResultGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                            <Columns>

                                <asp:TemplateField HeaderText ="SL">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("SL")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText ="Item">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("ItemName")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText ="Company">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("CompanyName")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText ="Category">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("CategoryName")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText ="Available <br/>quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("AvailableQuantity")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText ="Reorder <br/>Level">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("ReorderLevel")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
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
                        
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
