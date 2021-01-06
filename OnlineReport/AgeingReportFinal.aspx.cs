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

public partial class OnlineReport_AgeingReportFinal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            populatestaticdrops();

            //initially execute the ageing report SP
            /*      string div = ddlDivision.Text;
                  string mn = ddlmonth.Text;
                  (new RptAgeingDL()).populateReportFromSP(div, mn); */

            populatedropdowns();        //populate search dropdowns
            applyrole();


            //generate report
            SearchAgeing newsearch = new SearchAgeing();
            //    newsearch.rsm = "mad";
            newsearch.div = "eva";
            newsearch.fromdate = src_month4m.Text;
            //newsearch.todate = src_monthto.Text;
            newsearch.intFrom = Common.GetPositionof(newsearch.fromdate);
            //newsearch.intTo = Common.GetPositionof(newsearch.todate);

            

            GenerateReportFunction(newsearch,500);
        }
    }

    private void GenerateReportFunction(SearchAgeing newsearch)
    {
        GenerateReportFunction(newsearch, 0);
    }


    private void GenerateReportFunction(SearchAgeing newsearch, int rows)
    {
        // ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rdlcs/Report2.rdlc");

        DataSet dt = (new RptAgeingDL()).GetAgeingReportDataDynamic(newsearch,rows);

        dt.Tables[0].Columns.Remove("AsmHQ");
        dt.Tables[0].Columns.Remove("MfsoHQ");
        dt.Tables[0].Columns.Remove("rptageingID");
        dt.Tables[0].Columns.Remove("MfsoVisitPlan");
        dt.Tables[0].Columns.Remove("MfsoVisitDays");

        if (newsearch.div.ToLower() == "eva")
        {
            dt.Tables[0].Columns["MsrVisitDays"].ColumnName = "MFSOVisitDays";
            dt.Tables[0].Columns["MsrVisitPlan"].ColumnName = "MFSOVisitPlan";
        }
        else if (newsearch.div.ToLower() == "phoenix")
        {
            dt.Tables[0].Columns["MsrVisitDays"].ColumnName = "SOVisitDays";
            dt.Tables[0].Columns["MsrVisitPlan"].ColumnName = "SOVisitPlan";
        }
        else if (newsearch.div.ToLower() == "concord")
        {
            dt.Tables[0].Columns["MsrVisitDays"].ColumnName = "MFSOVisitDays";
            dt.Tables[0].Columns["MsrVisitPlan"].ColumnName = "MFSOVisitPlan";
        }

        rpt_ageing.ReportTitle = "Ageing Report";
        rpt_ageing.ReportName = "AgeingReport";

        /*   DataTable newdt = dt.Tables[0];
           foreach(DataColumn dc in newdt.Columns)
           {
               String cname = dc.ColumnName;
               if (Common.GetInt(newdt.Compute("COUNT("+cname+")", cname+" <> NULL")) == 0)
                   newdt.Columns.Remove(cname);
           }*/

        rpt_ageing.DataBind(dt.Tables[0].Copy());
        rpt_ageing.Visible = true;



        /*ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource()
        {
            Name = "ageingDS",
            Value = dt.Tables[0]
        });

        ReportViewer1.LocalReport.Refresh();*/
    }

    private void populatedropdowns()
    {
        string curmonth = DateTime.Now.ToString("MMMM");
        bool blncontinue = true;
        String prevmonth = "";
        foreach (string str in Common.monthlist)
        {
            if (curmonth == str)
            {
                blncontinue = false;
            }

            if (blncontinue)
            {
                src_month4m.Items.Add(str);
                prevmonth = str;
            }
            //   src_monthto.Items.Add(str);
        }

        src_month4m.SelectedValue = prevmonth;


        StaticData itmstaticdata = (new RptAgeingDL()).GetDropdownData(prevmonth);
        src_rsm.DataSource = itmstaticdata.lstrsm;
        src_rsm.DataBind();
        //src_asm.DataSource = itmstaticdata.lstasm;
        //src_asm.DataBind();
        src_area.DataSource = itmstaticdata.lstarea;
        src_area.DataBind();
        src_doctor.DataSource = itmstaticdata.lstdoctor;
        src_doctor.DataBind();
        src_msr.DataSource = itmstaticdata.lstmsr;
        src_msr.DataBind();
        src_div.DataSource = itmstaticdata.lstdivision;
        src_div.DataBind();
        
        src_div.SelectedValue = "EVA";
        //src_monthto.SelectedValue = curmonth;

    }

    private void populatestaticdrops()
    {
        /*     ddlDivision.Items.Add("EVA");
             ddlDivision.Items.Add("MAD");
             ddlDivision.Items.Add("PHOENIX");
             ddlDivision.Items.Add("CONCORD");

             foreach (string str in Common.monthlist)
             {
                 ddlmonth.Items.Add(str);
             }

             String curmonth = DateTime.Now.ToString("MMMM");
             ddlmonth.SelectedValue = curmonth; */
    }

    private void applyrole()
    {
        string role = Common.GetString(Session["loggedrole"]);
        switch (role)
        {
            case "admin":
                break;
            case "zsm":
                // divheadselection.Visible = false;
                break;
            case "rsm":
               // src_asm.Enabled = false;
                // divheadselection.Visible = false;
                break;
            case "asm":
                src_rsm.Enabled = false;
              //  src_asm.Enabled = false;
                //  divheadselection.Visible = false;
                break;
            case "msr":
                src_rsm.Enabled = false;
            //    src_asm.Enabled = false;
                src_msr.Enabled = false;
                //  divheadselection.Visible = false;
                break;
        }
    }

    protected void btnsprun_Click(object sender, EventArgs e)
    {
        /*  string div = ddlDivision.Text;
          string mn = ddlmonth.Text;
          (new RptAgeingDL()).populateReportFromSP(div, mn);

          populatedropdowns(); */
    }

    protected void btnadminsearch_Click(object sender, EventArgs e)
    {
        SearchAgeing itmsearch = new SearchAgeing();
        itmsearch.div = src_div.Text;
        itmsearch.rsm = src_rsm.Text;
       // itmsearch.asm = src_asm.Text;
        itmsearch.msr = src_msr.Text;
        itmsearch.area = src_area.Text;
        itmsearch.doctor = src_doctor.Text;
        itmsearch.fromdate = src_month4m.Text;
       // itmsearch.todate = src_monthto.Text;
        itmsearch.intFrom = Common.GetPositionof(itmsearch.fromdate);
        itmsearch.intTo = Common.GetPositionof(itmsearch.todate);

        bool blncontinue = true;
        //if ((itmsearch.intFrom > 0 && itmsearch.intTo > 0 && itmsearch.intFrom < itmsearch.intTo) || (itmsearch.intFrom == 0 && itmsearch.intTo == 0))
        //{
        //    blncontinue = true;
        //    lblmsg.Text = "";
        //}
        //else
        //{
        //    lblmsg.Text = "Wrong month range selection";
        //}


        if (blncontinue)
        {
            GenerateReportFunction(itmsearch);
        }
    }

    protected void btnadminReset_Click(object sender, EventArgs e)
    {
        SearchAgeing itmsearch = new SearchAgeing();

        GenerateReportFunction(itmsearch);

        src_rsm.SelectedIndex = 0;
       // src_asm.SelectedIndex = 0;
        src_area.SelectedIndex = 0;
        src_msr.SelectedIndex = 0;
        src_doctor.SelectedIndex = 0;
        src_month4m.SelectedIndex = 0;
        //src_monthto.SelectedIndex = 0;

        lblmsg.Text = "";
    }

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session["loggedrole"] = "";
        Response.Redirect("login.aspx");
    }

    protected void btnExporttoCSV_Click(object sender, EventArgs e)
    {
        ExportCSVReport();
    }

    protected void ExportCSVReport()
    {
        //ReportDataSource ds = ReportViewer1.LocalReport.DataSources["ageingDS"];
        ReportDataSource ds = rpt_ageing.GetReportView();

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




    protected void src_rsm_SelectedIndexChanged(object sender, EventArgs e)
    {
        String mval = src_month4m.SelectedValue;
        string dval = src_div.SelectedValue;
        String val = ((DropDownList)sender).SelectedValue;
        StaticData staticData = (new RptAgeingDL()).PopulateDropdownOnData("rsm", val, mval, dval);

        src_area.DataSource = staticData.lstarea;
        src_area.DataBind();
        src_doctor.DataSource = staticData.lstdoctor;
        src_doctor.DataBind();
        src_msr.DataSource = staticData.lstmsr;
        src_msr.DataBind();
    }

    protected void src_msr_SelectedIndexChanged(object sender, EventArgs e)
    {
        String mval = src_month4m.SelectedValue;
        string dval = src_div.SelectedValue;
        String val = ((DropDownList)sender).SelectedValue;
        StaticData staticData = (new RptAgeingDL()).PopulateDropdownOnData("msr", val, mval, dval);

        src_area.DataSource = staticData.lstarea;
        src_area.DataBind();
        src_doctor.DataSource = staticData.lstdoctor;
        src_doctor.DataBind();
    }

    protected void src_area_SelectedIndexChanged(object sender, EventArgs e)
    {
        String mval = src_month4m.SelectedValue;
        string dval = src_div.SelectedValue;
        String val = ((DropDownList)sender).SelectedValue;
        StaticData staticData = (new RptAgeingDL()).PopulateDropdownOnData("area", val, mval, dval);

        src_doctor.DataSource = staticData.lstdoctor;
        src_doctor.DataBind();
    }

    protected void src_month4m_SelectedIndexChanged(object sender, EventArgs e)
    {
        String mval = src_month4m.SelectedValue;
        string dval = src_div.SelectedValue;
        String val = ((DropDownList)sender).SelectedValue;
        StaticData staticData = (new RptAgeingDL()).PopulateDropdownOnData("month", val, mval, dval);

        src_div.DataSource = staticData.lstdivision;
        src_div.DataBind();
        src_rsm.DataSource = staticData.lstrsm;
        src_rsm.DataBind();
        src_msr.DataSource = staticData.lstmsr;
        src_msr.DataBind();
        src_area.DataSource = staticData.lstarea;
        src_area.DataBind();
        src_doctor.DataSource = staticData.lstdoctor;
        src_doctor.DataBind();
    }

    protected void src_div_SelectedIndexChanged(object sender, EventArgs e)
    {
        String mval = src_month4m.SelectedValue;
        string dval = src_div.SelectedValue;
        String val = ((DropDownList)sender).SelectedValue;
        StaticData staticData = (new RptAgeingDL()).PopulateDropdownOnData("division", val, mval, dval);

        src_rsm.DataSource = staticData.lstrsm;
        src_rsm.DataBind();
        src_msr.DataSource = staticData.lstmsr;
        src_msr.DataBind();
        src_area.DataSource = staticData.lstarea;
        src_area.DataBind();
        src_doctor.DataSource = staticData.lstdoctor;
        src_doctor.DataBind();

    }
}