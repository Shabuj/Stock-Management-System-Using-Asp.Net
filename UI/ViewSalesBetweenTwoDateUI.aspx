<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSalesBetweenTwoDateUI.aspx.cs" Inherits="StockMS.UI.ViewSalesBetweenTwoDateUI" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Sales</title>
        <link href="../Content/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker3.min.css" rel="stylesheet" />
    <link href="../css/media.css" rel="stylesheet" />
   <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/myStyle.css" rel="stylesheet" />
    <link href="../css/fontawesome.css" rel="stylesheet" />
    <link href="../css/fontawesome.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <div class="top-part">
                    <asp:Label ID="Label" runat="server" Text="View Sales" Font-Size="Large"></asp:Label>
                    <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="HomeUI.aspx" CssClass="pull-right" style="margin-right: 20px; color: #ffffff">Home</asp:HyperLink>                </div>                
            </div>
        </div>
    </div>

    <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="add-company">
                        <asp:Label ID="la" runat="server" Text="View Sales Between Two Dates"></asp:Label>
                    </div>                
                </div>            
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="add-company-form">
                        
                            <asp:Label ID="Label1" runat="server" Text="From Date" CssClass=""></asp:Label>
                            <input id="fromDatePicker" name="fromDatePicker" type="text" style="margin-left: 19px; width: 306px;" autocomplete="off"/><br/><br/>
                            <!--<asp:Label ID="Label5" runat="server" Text="date not selected" CssClass="instruction-warning"></asp:Label>-->

                            <asp:Label ID="Label2" runat="server" Text="To Date" CssClass=""></asp:Label>
                            <input id="toDatePicker" name="toDatePicker" type="text" style="margin-left: 37px; width: 306px;" autocomplete="off"/><br/><br/>
                            <asp:Label ID="outputErrorLabel" runat="server" Text="" CssClass="instruction-warning" style="margin-left: 150px" ></asp:Label><br/><br/>
                            <asp:Button ID="searchButton" runat="server" Text="Search"  CssClass="btn btn-primary add-item-form-button" style="margin-left: 330px; width: 61px;" OnClick="searchButton_Click"/> <br/> <br/>
                            
                            <asp:GridView ID="searchGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                    </div>
                </div>
            </div>
        </div>
    </form>
    
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/bootstrap-datepicker.min.js"></script>
    
    <script>
        $('#fromDatePicker').datepicker({
            todayBtn: "linked",
            daysOfWeekHighlighted: "5",
            calendarWeeks: true,
            autoclose: true,
            todayHighlight: true,
            toggleActive: true
        });

        $('#toDatePicker').datepicker({
            todayBtn: "linked",
            daysOfWeekHighlighted: "5",
            calendarWeeks: true,
            autoclose: true,
            todayHighlight: true,
            toggleActive: true
        });

        $("#fromDatePicker").datepicker('setDate', new Date());
        $("#toDatePicker").datepicker('setDate', new Date());
    </script>
</body>
</html>