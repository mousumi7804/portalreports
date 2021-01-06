<%@ Control Language="C#" AutoEventWireup="true" CodeFile="doctorvisit_search.ascx.cs" Inherits="UserControl_doctorvisit_search" %>



<div style="height:50px;"></div>

<div id="adminsearch" style="visibility: visible;">
    <table style="width: 75%;">
        <tr>
            <td colspan="3" style="text-align:center; height:50px;">
                <h2>Doctor Visit Report Search</h2>
            </td>
        </tr>
        <tr>
            <td style="width: 15%"></td>
            <td style="width: 10%"><h4>Month</h4></td>
            <td style="width: 50%; height:50px;">
                <asp:ListBox ID="src_month4m"  runat="server" Width="60%" SelectionMode="Multiple" AppendDataBoundItems="false"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="width: 15%"></td>
            <td style="width: 10%"><h4>Division</h4></td>
            <td style="width: 50%; height:50px;">
                <asp:ListBox ID="src_div" runat="server" Width="60%" SelectionMode="Multiple" AppendDataBoundItems="false"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="width: 15%"></td>
            <td style="width: 10%"><h4>RSM Name-HQ</h4></td>
            <td style="width: 50%; height:50px;">
                <asp:ListBox ID="src_rsm" CssClass="dropdown dropdown-menu" runat="server" Width="60%" SelectionMode="Multiple" AppendDataBoundItems="false"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="width: 15%"></td>
            <td style="width: 10%"><h4>District</h4></td>
            <td style="width: 50%; height:50px;">
                <asp:ListBox ID="src_district" CssClass="dropdown dropdown-menu" runat="server" Width="60%" SelectionMode="Multiple" AppendDataBoundItems="false"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="width: 15%"></td>
            <td style="width: 10%"><h4>Employee</h4></td>
            <td style="width: 50%; height:50px;">
                <asp:ListBox ID="src_employee" CssClass="dropdown dropdown-menu" runat="server" Width="60%" SelectionMode="Multiple" AppendDataBoundItems="false"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="width: 15%"></td>
            <td style="width: 10%"><h4>Designation</h4></td>
            <td style="width: 50%; height:50px;">
                <asp:ListBox ID="src_designation" CssClass="dropdown dropdown-menu" runat="server" Width="60%" SelectionMode="Multiple" AppendDataBoundItems="false"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height:25px;"></td>
        </tr>
        <tr>
            <td style="width: 15%"></td>
            <td style="width: 15%"></td>
            <td style="width: 50%"></td>
        </tr>
    </table>
</div>


<script type="text/javascript">
    $(function () {
        //$("#datepicker1").datepicker();
        //$("#datepicker2").datepicker();

        $('[id*=src_month4m]').multiselect({
            includeSelectAllOption: true
        });

        $('[id*=src_div]').multiselect({
            includeSelectAllOption: true
        });

    });
</script>
