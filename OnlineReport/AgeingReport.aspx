<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineReport/MasterPage.master" AutoEventWireup="true" CodeFile="AgeingReport.aspx.cs" Inherits="OnlineReport_AgeingReport" %>
<%@ Register Src="~/UserControl/report_viewer.ascx" TagName="reportviewer" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:UpdatePanel runat="server" ID="pnl_report">
        <ContentTemplate>
         <br />

            <div>

                <div style="width: 1300px;">
                <uc1:reportviewer ReportTitle="Default" ReportName="Default Name" runat="server"
                    ID="rpt_ageing" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

