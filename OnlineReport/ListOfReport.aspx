<%@ Page Title="List Of Report" Language="C#" MasterPageFile="~/OnlineReport/OReport.master" AutoEventWireup="true"
    CodeFile="ListOfReport.aspx.cs" Inherits="OnlineReport_ListOfReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/Customstyle1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #image
        {
            line-height: .5em;
            list-style-position: inside;
            list-style-image: url(../Image/reporticon2.png);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container1">
        <div class="row">
            <div class=" col-md-9">
                <h3>
                    Choose Report Here</h3>
            </div>
        </div>
        <div class="row">
            <div class=" col-md-5">
                <div class="panel panel-default">
                    <div class=" panel-body">
                        <div class="row">
                            <div class="col-md-12">
                               <label for="info">List Of Reports</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <ul>
                                    
                                    <li>
                                       <asp:HyperLink ID="HLstockreport" runat="server" NavigateUrl="~/OnlineReport/StockReportfilter.aspx">Daily Stock Report</asp:HyperLink>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        
                                    </li>
                                     
                                  
                                     <li>
                                       <asp:HyperLink ID="HldailysaleuserWise" runat="server" NavigateUrl="~/OnlineReport/DailySalesReportAll.aspx">Daily Sales Report </asp:HyperLink>
                                    </li>

                                     <li>
                                       <asp:HyperLink ID="Hlcraditnote" runat="server" NavigateUrl="~/OnlineReport/Craditnote.aspx">Creditnote Report </asp:HyperLink>
                                    </li>
                                     
                                    <li>
                                       <asp:HyperLink ID="Hlsalesordertransaction" runat="server" NavigateUrl="~/OnlineReport/Salesordertransaction.aspx">Sales Order Transaction </asp:HyperLink>
                                    </li>
                                    <li>
                                       <asp:HyperLink ID="HlSalesDelevaryStatus" runat="server" NavigateUrl="~/OnlineReport/SalesDelevaryStatus.aspx">Sales Delivary Status </asp:HyperLink>
                                    </li>
                                     <li>
                                       <asp:HyperLink ID="Hloutstanding" runat="server" NavigateUrl="~/OnlineReport/outstandingreport.aspx">Outstanding Report</asp:HyperLink>
                                    </li>
                                    <li>
                                       <asp:HyperLink ID="HlTransactionbilltrends" runat="server" NavigateUrl="~/OnlineReport/Transactionbilltrends.aspx">Transaction Bill Trends</asp:HyperLink>
                                    </li>
									<li>
                                       <asp:HyperLink ID="HlDepotwiseProductSale" runat="server" NavigateUrl="~/OnlineReport/DepotwiseProductSale.aspx">Depot wise Product Sale</asp:HyperLink>
                                    </li>
                                     <li>
                                       <asp:HyperLink ID="Hltransactionalbilldata" runat="server" NavigateUrl="~/OnlineReport/TransactionBillData.aspx">Transactional Bill Data </asp:HyperLink>
                                    </li>
									<li>
                                       <asp:HyperLink ID="Hlyearlyproductwisesalescomparison" runat="server" NavigateUrl="~/OnlineReport/MonthyearwiseProductSales.aspx">Yearly Product Wise Sales Comparison</asp:HyperLink>
                                    </li>									
									<li>
                                       <asp:HyperLink ID="Hlmadsecondarysalestatement" runat="server" NavigateUrl="~/OnlineReport/Madsecondarysalestatementt.aspx">MAD Secondary Sales Statement</asp:HyperLink>
                                    </li>
									<li>
                                       <asp:HyperLink ID="Hlevasecondarysalestatement" runat="server" NavigateUrl="~/OnlineReport/Secondarysaleeva.aspx">EVA Secondary Sales Statement</asp:HyperLink>
                                    </li>
									<li>
                                       <asp:HyperLink ID="Hlconsecondarysalestatement" runat="server" NavigateUrl="~/OnlineReport/concordsecondarysalestatement.aspx">Concord Secondary Sales Statement</asp:HyperLink>
                                    </li>
									<li>
                                       <asp:HyperLink ID="Hlphoenixsecondarysalestatement" runat="server" NavigateUrl="~/OnlineReport/phoenixsecondarysalestatement.aspx">Phoenix Secondary Sales Statement</asp:HyperLink>
                                    </li>
								
                                    <li>
                                        <asp:HyperLink ID="Hlageingreport" runat="server" NavigateUrl="~/OnlineReport/AgeingReportFinal.aspx">Ageing Report</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="Hlreturnreport" runat="server" NavigateUrl="~/OnlineReport/ReturnReportFinal.aspx">Doctor Wise Return Report</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="Hldoctorvisitreport" runat="server" NavigateUrl="~/OnlineReport/DoctorVisitReportFinal.aspx">Doctor Visit Report</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="Hldocchemmapreport" runat="server" NavigateUrl="~/OnlineReport/DocChemMapReportFinal.aspx">Doctor Chemist Mapping Report</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="Hldoclistreport" runat="server" NavigateUrl="~/OnlineReport/DocListReportFinal.aspx">Doctor List Report</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="Hltourplanreport" runat="server" NavigateUrl="~/OnlineReport/TourPlanReportFinal.aspx">Tour Plan Report</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="Hlunlistedvisitreport" runat="server" NavigateUrl="~/OnlineReport/UnlistedVisitReportFinal.aspx">Unlisted Client Visit Report</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="Hlsamplereport" runat="server" NavigateUrl="~/OnlineReport/SampleReportFinal.aspx">Sample Report</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="Hlcallaveragereport" runat="server" NavigateUrl="~/OnlineReport/CallAverageReportFinal.aspx">Call Average Report</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="Hlageingtransactionreport" runat="server" NavigateUrl="~/OnlineReport/AgeingTransactionReportFinal.aspx">Ageing Transaction Report</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="Hlmonthlyattendancereport" runat="server" NavigateUrl="~/OnlineReport/MonthlyAttendanceReportFinal.aspx">Monthly Attendance Report</asp:HyperLink>
                                    </li>
                                </ul>



                            </div>  
                            
                            
                        </div>

                        

                            <div class="row">
                        </div>
                    </div>


                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
