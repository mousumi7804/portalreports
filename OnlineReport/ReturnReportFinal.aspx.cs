using DataLayer;
using Microsoft.Reporting.WebForms;
using model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OnlineReport_ReturnReportFinal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            populatestaticdrops();
            GenerateReportFunction();
        }
    }

    private void GenerateReportFunction()
    {
        int monthno = DateTime.Now.Month;
        GenerateReportFunction(monthno,"",500);
    }

    private void GenerateReportFunction(int monthno,String division,int rows)           //(SearchAgeing newsearch)
    {
        //  ReportViewer1.ProcessingMode = ProcessingMode.Local;
        // ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rdlcs/ReportReturn.rdlc");

        DataSet dt = (new RptReturnDL()).GetReturnReportData(monthno,division,rows);

        DataTable newtab = dt.Tables[1];
        object sumqty = newtab.Compute("Sum(qty)", "");
        object sumvalue = newtab.Compute("Sum(value)", "");
        object sumnrv = newtab.Compute("Sum(NRVPrice)", "");

        newtab.Columns.Remove("RptReturnId");
        newtab.Columns.Remove("month");

        //remove fields as per division

        if(division.ToUpper()== "EVA")
        {
            newtab.Columns.Remove("SO_HQ");
            newtab.Columns.Remove("SO_Name");
            newtab.Columns.Remove("SM_HQ");
            newtab.Columns.Remove("SM_Name");
            newtab.Columns.Remove("DRSM_HQ");
            newtab.Columns.Remove("DRSM_Name");
        }
        else if(division.ToUpper()== "PHOENIX")
        {
            newtab.Columns.Remove("MFSO_HQ");
            newtab.Columns.Remove("MFSO_Name");
            newtab.Columns.Remove("SM_HQ");
            newtab.Columns.Remove("SM_Name");
            newtab.Columns.Remove("DRSM_HQ");
            newtab.Columns.Remove("DRSM_Name");
        }
        else if(division.ToUpper()== "CONCORD")
        {
            newtab.Columns.Remove("MFSO_HQ");
            newtab.Columns.Remove("MFSO_Name");
            newtab.Columns.Remove("GM_HQ");
            newtab.Columns.Remove("GM_Name");
            newtab.Columns.Remove("DRSM_HQ");
            newtab.Columns.Remove("DRSM_Name");
        }
        else if (division.ToUpper() == "MAD")
        {
            newtab.Columns.Remove("MFSO_HQ");
            newtab.Columns.Remove("MFSO_Name");
            newtab.Columns.Remove("SO_HQ");
            newtab.Columns.Remove("SO_Name");
            newtab.Columns.Remove("GM_HQ");
            newtab.Columns.Remove("GM_Name");
            newtab.Columns.Remove("ZSM_HQ");
            newtab.Columns.Remove("ZSM_Name");
            newtab.Columns.Remove("RSM_HQ");
            newtab.Columns.Remove("RSM_Name");
            newtab.Columns.Remove("SM_HQ");
            newtab.Columns.Remove("SM_Name");
        }



        //extra row insert for total
        DataRow drinsert = newtab.NewRow();
        newtab.Rows.InsertAt(drinsert, 0);

        for (int i = 0; i < newtab.Columns.Count; i++)
        {
            DataColumn dc = newtab.Columns[i];
            if (dc.ColumnName.Contains("NRVPrice"))
            {
                newtab.Rows[0][i]= Common.GetDecimal(sumnrv.ToString());
            }
            else if (dc.ColumnName.Contains("qty"))
            {
                newtab.Rows[0][i] = Common.GetInt(sumqty.ToString());
            }
            else if (dc.ColumnName.Contains("value"))
            {
                newtab.Rows[0][i] = Common.GetInt(sumvalue.ToString());
            }
            else
            {
                if (i == 0)
                    newtab.Rows[0][i] = "TOTALS : ";
                else
                    newtab.Rows[0][i] = "";
            }
        }


        rpt_return.ReportTitle = "Return Report";
        rpt_return.ReportName = "ReturnReport";
        rpt_return.DataBind(newtab.Copy());
        rpt_return.Visible = true;

        /*lbltotnrv.Text = Common.GetString(sumnrv);
        lbltotqty.Text = Common.GetString(sumqty);
        lbltotvalue.Text = Common.GetString(sumvalue);*/

        /* ReportViewer1.LocalReport.DataSources.Clear();
         ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource()
         {
             Name = "ReturnDs",
             Value = dt.Tables[0]
         });

         ReportViewer1.LocalReport.Refresh(); */
    }




    protected void ExportCSVReport()
    {
        // ReportDataSource ds = ReportViewer1.LocalReport.DataSources["ReturnDs"];

        ReportDataSource ds = rpt_return.GetReportView();
        DataTable dt = (DataTable)ds.Value;

        StringBuilder sb = new StringBuilder();
        //add the header row
        foreach (DataColumn fcol in dt.Columns)
        {
            sb.Append(fcol.Caption);
            sb.Append(",");
        }
        sb.AppendLine("\t");

        foreach (DataRow row in dt.Rows)
        {
            foreach (DataColumn column in dt.Columns)
            {

                sb.Append(row[column].ToString());
                sb.Append(",");
            }
            sb.AppendLine("\t");
        }


        Response.Clear();
        Response.ContentType = "text/csv";
        Response.AddHeader("content-disposition", "attachment; filename=Report.csv");
        Response.Write(sb.ToString());
        Response.End();
    }

    protected void btnsprun_Click(object sender, EventArgs e)
    {
        /*  string div = ddlDivision.Text;
          string mn = ddlmonth.Text;
          (new RptReturnDL()).populateReportFromSP(div, mn); */

        // populatedropdowns();
    }


    private void populatestaticdrops()
    {
        filterdivision.Items.Add("EVA");
        filterdivision.Items.Add("PHOENIX");
        filterdivision.Items.Add("CONCORD");
        filterdivision.Items.Add("MAD");

        
        foreach (string str in Common.monthlist)
        {
            //ddlmonth.Items.Add(str);
            filtermonth.Items.Add(str);
        }

        String curmonth = DateTime.Now.ToString("MMMM");
        //ddlmonth.SelectedValue = curmonth;
        filtermonth.SelectedValue = curmonth;
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        String monthname = filtermonth.SelectedValue;
        int monthno = Common.GetMonthNo(monthname);

        String division = filterdivision.SelectedValue;

        GenerateReportFunction(monthno, division,0);
    }
}