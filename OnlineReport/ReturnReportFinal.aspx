<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineReport/OReport.master" AutoEventWireup="true" CodeFile="ReturnReportFinal.aspx.cs" Inherits="OnlineReport_ReturnReportFinal" %>

<%@ Register Src="../UserControl/report_viewer.ascx" TagName="report_viewer" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div style="height:50px; text-align:center;">
        <h2>Return Report</h2>
    </div>
    <div style="height:30px;">

    </div>
    <div style="text-align:right; padding-right:50px;height:50px;">
            <asp:LinkButton ID="lnklogout" runat="server" Text="Logout"></asp:LinkButton>
        </div>

    <div style="padding-top:20px; padding-left:50px; padding-bottom:10px;">
        <table style="width:90%;">
            <tr>
                <td style="width:25%">
                    <asp:DropDownList ID="filterdivision" runat="server" Width="75%"></asp:DropDownList>
                </td>
                <td style="width:25%">
                    <asp:DropDownList ID="filtermonth" runat="server" Width="75%"></asp:DropDownList>
                </td>
                <td style="width:25%">
                    <asp:Button ID="btnsearch" runat="server" Text="Search" Width="40%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnsearch_Click" />
                </td>
                <td style="width:25%"></td>
            </tr>
        </table>
    </div>

     <asp:UpdatePanel runat="server" ID="pnl_report">
            <ContentTemplate>
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
                <div style="width: auto;">
                    <uc1:report_viewer ReportTitle="Default" ReportName="Default Name" runat="server"
                        ID="rpt_return" Visible="true" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    <%--<div style="padding-top:20px; padding-left:50px;">
        <table style="width:30%; font-size:20px;" >
            <tr>
                <td>Total Qty :</td>
                <td>
                    <asp:Label ID="lbltotqty" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Total Value :</td>
                <td>
                    <asp:Label ID="lbltotvalue" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Total NRV Price :</td>
                <td>
                    <asp:Label ID="lbltotnrv" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>--%>
</asp:Content>

