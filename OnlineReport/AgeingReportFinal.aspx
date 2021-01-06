<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineReport/OReport.master" AutoEventWireup="true" CodeFile="AgeingReportFinal.aspx.cs" Inherits="OnlineReport_AgeingReportFinal" %>

<%@ Register Src="../UserControl/report_viewer.ascx" TagName="report_viewer" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     <table width="100%">
        <tr>
            <td>
                <div style="height: 30px; text-align: center;">
                    <h2>Ageing Report</h2>
                </div>
                <%--<div style="text-align: right; padding-right: 50px; height: 50px;">--%>
                <div style="text-align: right; padding-right: 50px;">
                    <asp:LinkButton ID="lnklogout" runat="server" Text="Logout" OnClick="lnklogout_Click" Visible="false"></asp:LinkButton>
                </div>

                <div style="padding-top: 10px; padding-bottom: 40px;">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="adminsearch" style="visibility: visible">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 12%">Month</td>
                            <td style="width: 12%">Division</td>
                            <td style="width: 12%">RSM Name-HQ</td>
                            <%--<td style="width: 12%">ASM Name-HQ</td>--%>
                            <td style="width: 12%">MSR Name-HQ</td>
                            <td style="width: 12%">Area</td>
                            <td style="width: 12%">Doctor Name</td>
                            
                            <%--<td colspan="2" style="text-align: center;">Date Range</td>--%>
                        </tr>
                        <tr>
                            <td style="width: 12%">
                                <asp:DropDownList ID="src_month4m" runat="server" Width="60%" OnSelectedIndexChanged="src_month4m_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <%--<input type="text" id="datepicker1" />--%>
                            </td>
                            <td style="width: 12%">
                                <asp:DropDownList ID="src_div" runat="server" Width="95%" OnSelectedIndexChanged="src_div_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </td>
                            <td style="width: 12%">
                                <asp:DropDownList ID="src_rsm" runat="server" Width="95%" OnSelectedIndexChanged="src_rsm_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </td>
                            <%--<td style="width: 12%">
                                <asp:DropDownList ID="src_asm" runat="server" Width="95%"></asp:DropDownList>
                            </td>--%>
                            <td style="width: 12%">
                                <asp:DropDownList ID="src_msr" runat="server" Width="95%" OnSelectedIndexChanged="src_msr_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </td>
                            <td style="width: 12%">
                                <asp:DropDownList ID="src_area" runat="server" Width="95%" OnSelectedIndexChanged="src_area_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </td>
                            <td style="width: 12%">
                                <asp:DropDownList ID="src_doctor" runat="server" Width="95%"></asp:DropDownList>
                            </td>
                            
                           <%-- <td style="width: 12%">To &nbsp;
                        <asp:DropDownList ID="src_monthto" runat="server" Width="60%"></asp:DropDownList>
                                <%--<input type="text" id="datepicker2" />
                            </td>--%>
                        </tr>
                        <tr>
                            <td style="padding-top: 60px;" colspan="2"></td>
                            <td style="text-align: center">
                                <asp:Button ID="btnadminsearch" runat="server" Text="Search" Width="90%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnadminsearch_Click" />
                            </td>
                            <td style="text-align: center">
                                <asp:Button ID="btnadminReset" runat="server" Text="Reset" Width="90%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnadminReset_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnExporttoCSV" runat="server" Text="Export to CSV" Width="90%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnExporttoCSV_Click" />
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>

        <tr>
            <td>
                <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>--%>
                <div style="width: auto;">
                    <uc1:report_viewer ReportTitle="Default" ReportName="Default Name" runat="server"
                        ID="rpt_ageing" Visible="true" />
                </div>

            </td>

        </tr>
    </table>


    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#datepicker1").datepicker();
            $("#datepicker2").datepicker();
        });





    </script>
</asp:Content>

