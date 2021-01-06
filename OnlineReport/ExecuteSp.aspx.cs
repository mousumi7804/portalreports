using DataLayer;
using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OnlineReport_ExecuteSp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            populatestaticdrops();
        }
    }

    private void populatestaticdrops()
    {
        //for ageing
        ddlDivision_ageing.Items.Clear();
        ddlDivision_ageing.Items.Add("EVA");
        ddlDivision_ageing.Items.Add("MAD");
        ddlDivision_ageing.Items.Add("PHOENIX");
        ddlDivision_ageing.Items.Add("CONCORD");

        ddlmonth_ageing.Items.Clear();
        foreach (string str in Common.monthlist)
        {
            ddlmonth_ageing.Items.Add(str);
        }
        String curmonth = DateTime.Now.ToString("MMMM");
        ddlmonth_ageing.SelectedValue = curmonth;



        //for return
        ddlDivision_return.Items.Clear();        
        ddlDivision_return.Items.Add("EVA");
        ddlDivision_return.Items.Add("PHOENIX");
        ddlDivision_return.Items.Add("CONCORD");
        ddlDivision_return.Items.Add("MAD");

        ddlmonth_return.Items.Clear();
        foreach (string str in Common.monthlist)
        {
            ddlmonth_return.Items.Add(str);
        }
        curmonth = DateTime.Now.ToString("MMMM");
        ddlmonth_return.SelectedValue = curmonth;


        //for doctor visit
        ddlmonth_docvisit.Items.Clear();
        foreach (string str in Common.monthlist)
        {
            ddlmonth_docvisit.Items.Add(str);
        }
        curmonth = DateTime.Now.ToString("MMMM");
        ddlmonth_docvisit.SelectedValue = curmonth;


        //for doctor chemist mapping
        ddlmonth_docchemmap.Items.Clear();
        foreach (string str in Common.monthlist)
        {
            ddlmonth_docchemmap.Items.Add(str);
        }
        curmonth = DateTime.Now.ToString("MMMM");
        ddlmonth_docchemmap.SelectedValue = curmonth;


        //for doctor list
        ddlmonth_doclist.Items.Clear();
        foreach (string str in Common.monthlist)
        {
            ddlmonth_doclist.Items.Add(str);
        }
        curmonth = DateTime.Now.ToString("MMMM");
        ddlmonth_doclist.SelectedValue = curmonth;


        //for tour plan
        ddlmonth_tourplan.Items.Clear();
        foreach (string str in Common.monthlist)
        {
            ddlmonth_tourplan.Items.Add(str);
        }
        curmonth = DateTime.Now.ToString("MMMM");
        ddlmonth_tourplan.SelectedValue = curmonth;


        //for unlisted client visit
        ddlmonth_unlistedvisit.Items.Clear();
        foreach (string str in Common.monthlist)
        {
            ddlmonth_unlistedvisit.Items.Add(str);
        }
        curmonth = DateTime.Now.ToString("MMMM");
        ddlmonth_unlistedvisit.SelectedValue = curmonth;


        //for unlisted client visit
        ddlmonth_sample.Items.Clear();
        foreach (string str in Common.monthlist)
        {
            ddlmonth_sample.Items.Add(str);
        }
        curmonth = DateTime.Now.ToString("MMMM");
        ddlmonth_sample.SelectedValue = curmonth;

        //for call average
        ddlmonth_callaverage.Items.Clear();
        foreach (string str in Common.monthlist)
        {
            ddlmonth_callaverage.Items.Add(str);
        }
        curmonth = DateTime.Now.ToString("MMMM");
        ddlmonth_callaverage.SelectedValue = curmonth;

        //for ageing transaction
        ddlmonth_ageingtransaction.Items.Clear();
        foreach (string str in Common.monthlist)
        {
            ddlmonth_ageingtransaction.Items.Add(str);
        }
        curmonth = DateTime.Now.ToString("MMMM");
        ddlmonth_ageingtransaction.SelectedValue = curmonth;

        //for monthly attendance
        ddlmonth_monthlyattn.Items.Clear();
        foreach (string str in Common.monthlist)
        {
            ddlmonth_monthlyattn.Items.Add(str);
        }
        curmonth = DateTime.Now.ToString("MMMM");
        ddlmonth_monthlyattn.SelectedValue = curmonth;
    }

    protected void btnsprun_ageing_Click(object sender, EventArgs e)
    {
        string div = ddlDivision_ageing.SelectedValue;
        string mn = ddlmonth_ageing.SelectedValue;
        String ret = (new RptAgeingDL()).populateReportFromSP(div, mn);
        lblageingmsg.Text = ret;

    }

    protected void btnsprun_return_Click(object sender, EventArgs e)
    {
        string div = ddlDivision_return.SelectedValue;
        string mn = ddlmonth_return.SelectedValue;
        String ret= (new RptReturnDL()).populateReportFromSP(div, mn);
        
        lblreturnmsg.Text = ret;
    }

    protected void btnsprun_docvisit_Click(object sender, EventArgs e)
    {
        string mn = ddlmonth_docvisit.SelectedValue;
        int mno = Common.GetMonthNo(mn);

        String ret = (new RptDocVisitDL()).populateReportFromSP(mn, mno);
        lbldocvisitmsg.Text = ret;
    }

    protected void btnsprun_docchemmap_Click(object sender, EventArgs e)
    {
        string mn = ddlmonth_docchemmap.SelectedValue;
        int mno = Common.GetMonthNo(mn);

        String ret = (new RptDocChemMapDL()).populateReportFromSP(mn, mno);
        lbldocchemmapmsg.Text = ret;
    }

    protected void btnsprun_doclist_Click(object sender, EventArgs e)
    {
        string mn = ddlmonth_doclist.SelectedValue;
        int mno = Common.GetMonthNo(mn);

        String ret = (new RptDocListDL()).populateReportFromSP(mn, mno);
        lbldoclist.Text = ret;
    }

    protected void btnsprun_tourplan_Click(object sender, EventArgs e)
    {
        string mn = ddlmonth_tourplan.SelectedValue;
        int mno = Common.GetMonthNo(mn);

        String ret = (new RptTourPlanDL()).populateReportFromSP(mn, mno);
        lbltourplan.Text = ret;
    }

    protected void btnsprun_unlistedvisit_Click(object sender, EventArgs e)
    {
        string mn = ddlmonth_unlistedvisit.SelectedValue;
        int mno = Common.GetMonthNo(mn);

        String ret = (new RptUnlistedVisitDL()).populateReportFromSP(mn, mno);
        lblunlistedvisit.Text = ret;
    }

    protected void btnsprun_sample_Click(object sender, EventArgs e)
    {
        string mn = ddlmonth_sample.SelectedValue;
        int mno = Common.GetMonthNo(mn);

        String ret = (new RptSampleDL()).populateReportFromSP(mn, mno);
        lblsample.Text = ret;
    }

    protected void btnsprun_callaverage_Click(object sender, EventArgs e)
    {
        string mn = ddlmonth_callaverage.SelectedValue;
        int mno = Common.GetMonthNo(mn);

        String ret = (new RptCallAverageDL()).populateReportFromSP(mn, mno);
        lblcallaverage.Text = ret;
    }

    protected void btnsprun_ageingtransaction_Click(object sender, EventArgs e)
    {
        string mn = ddlmonth_ageingtransaction.SelectedValue;
        int mno = Common.GetMonthNo(mn);

        String ret = (new RptAgeingTransactionDL()).populateReportFromSP(mn, mno);
        lblageingtransaction.Text = ret;
    }

    protected void btnsprun_monthlyattn_Click(object sender, EventArgs e)
    {
        string mn = ddlmonth_monthlyattn.SelectedValue;
        int mno = Common.GetMonthNo(mn);

        String ret = (new RptMonthlyAttendanceDL()).populateReportFromSP(mn, mno);
        lblmonthlyattn.Text = ret;
    }
}