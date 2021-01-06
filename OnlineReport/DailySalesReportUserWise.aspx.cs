﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

public partial class OnlineReport_DailySalesReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		
		 if (Session["username"].ToString() == "pradip.sarkar@mendine.co.in" )
        {
            //Menu mainMenu = (Menu)Page.Master.FindControl("Candidatemeenu");
            Label1.Visible=true;
			Ddlselect.Visible=true;
			Ddlselect.Items[5].Enabled = false;
        }
		else
		if(Session["username"].ToString() == "sanjay.mukherjee@mendine.co.in")
		{
			
			Label1.Visible=true;
			Ddlselect.Visible=true;
			Ddlselect.Items[3].Enabled = false;
		}
		else
if(Session["username"].ToString() == "lincon.banerjee@mendine.co.in")
		{
			
			Label1.Visible=true;
			Ddlselect.Visible=true;
			Ddlselect.Items[5].Enabled = false;
			//Ddlselect.Items[3].Enabled = false;
		}
      
	else
	  {
		  Label1.Visible=false;
			Ddlselect.Visible=false;
	  }
	
        if (Session["username"] == null)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            //or use Response.Redirect to go to a different page
            FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("~/Account/Login.aspx");

        }
        Session["username"] = User.Identity.Name;
        Menu men = (Menu)Master.FindControl("NavigationMenu");
        men.Visible = false;
        if (!IsPostBack)
        {
			
			Session["username"]=User.Identity.Name;
			ddldivision.Visible=false;
			lbldiv_div.Visible=false;
             if(Session["div"].ToString()=="MAD")
			 {



                 #region for loading division dropdown
                 string constr_div = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                 using (SqlConnection conn_div = new SqlConnection(constr_div))
                 {

                     using (SqlCommand cmd_div = new SqlCommand("empsalesdivision"))
                     {
                         cmd_div.CommandType = CommandType.StoredProcedure;
                         cmd_div.Parameters.AddWithValue("@username", Session["username"].ToString());
                         //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                         //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                         using (SqlDataAdapter sda_div = new SqlDataAdapter())
                         {
                             cmd_div.Connection = conn_div;
                             sda_div.SelectCommand = cmd_div;
                             using (DataTable dt_div = new DataTable())
                             {
                                 sda_div.Fill(dt_div);
                                 //lbldiv.Text = dt.Rows[0][0].ToString();

                                 ddldivision.DataSource = dt_div;
                                 ddldivision.DataTextField = "division";
                                 ddldivision.DataValueField = "division";
                                 ddldivision.DataBind();
                                 ddldivision.Visible = true;
                                 lbldiv_div.Visible = true;


                             }
                         }
                     }
                 }
                 #endregion
                 DataSet ds = new DataSet();
                //ds.Tables.Add(table1);

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    using (SqlCommand cmd = new SqlCommand("Mad_userwise_higher"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username",  Session["username"].ToString());
                        //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                        //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = conn;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                //lbldiv.Text = dt.Rows[0][0].ToString();

                                DropDownstocklocation.DataSource = dt;
                                DropDownstocklocation.DataTextField = "name";
                                DropDownstocklocation.DataValueField = "empemail";
                                DropDownstocklocation.DataBind();

                            }
                        }
                    }
                }
						
		   ReportBinding();
			 }
			 if(Session["div"].ToString()=="EVA")
			 {	
		 
		 
		 
		      string constr_div = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                using (SqlConnection conn_div = new SqlConnection(constr_div))
                {

                    using (SqlCommand cmd_div = new SqlCommand("empsalesdivision"))
                    {
                        cmd_div.CommandType = CommandType.StoredProcedure;
                        cmd_div.Parameters.AddWithValue("@username",  Session["username"].ToString());
                        //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                        //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                        using (SqlDataAdapter sda_div = new SqlDataAdapter())
                        {
                            cmd_div.Connection = conn_div;
                            sda_div.SelectCommand = cmd_div;
                            using (DataTable dt_div = new DataTable())
                            {
                                sda_div.Fill(dt_div);
                                //lbldiv.Text = dt.Rows[0][0].ToString();
								
                                ddldivision.DataSource = dt_div;
                                ddldivision.DataTextField = "division";
                                ddldivision.DataValueField = "division";
                                ddldivision.DataBind();
								ddldivision.Visible=true;
								lbldiv_div.Visible=true;
								

                            }
                        }
                    }
                }
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 

                DataSet ds = new DataSet();
                //ds.Tables.Add(table1);

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    using (SqlCommand cmd = new SqlCommand("Eva_userwise_higher"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username",  Session["username"].ToString());
                        //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                        //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = conn;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                //lbldiv.Text = dt.Rows[0][0].ToString();

                                DropDownstocklocation.DataSource = dt;
                                DropDownstocklocation.DataTextField = "name";
                                DropDownstocklocation.DataValueField = "empemail";
                                DropDownstocklocation.DataBind();

                            }
                        }
                    }
                }
		 
		 
		   ReportBindingeva();
			 }
			 if(Session["div"].ToString()=="PHOENIX")
             {
                 #region for loading division dropdown
                 string constr_div = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                 using (SqlConnection conn_div = new SqlConnection(constr_div))
                 {

                     using (SqlCommand cmd_div = new SqlCommand("empsalesdivision"))
                     {
                         cmd_div.CommandType = CommandType.StoredProcedure;
                         cmd_div.Parameters.AddWithValue("@username", Session["username"].ToString());
                         //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                         //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                         using (SqlDataAdapter sda_div = new SqlDataAdapter())
                         {
                             cmd_div.Connection = conn_div;
                             sda_div.SelectCommand = cmd_div;
                             using (DataTable dt_div = new DataTable())
                             {
                                 sda_div.Fill(dt_div);
                                 //lbldiv.Text = dt.Rows[0][0].ToString();

                                 ddldivision.DataSource = dt_div;
                                 ddldivision.DataTextField = "division";
                                 ddldivision.DataValueField = "division";
                                 ddldivision.DataBind();
                                 ddldivision.Visible = true;
                                 lbldiv_div.Visible = true;


                             }
                         }
                     }
                 }
                 #endregion

                 DataSet ds = new DataSet();
                //ds.Tables.Add(table1);

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    using (SqlCommand cmd = new SqlCommand("Phoenix_userwise_higher"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username",  Session["username"].ToString());
                        //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                        //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = conn;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                //lbldiv.Text = dt.Rows[0][0].ToString();

                                DropDownstocklocation.DataSource = dt;
                                DropDownstocklocation.DataTextField = "name";
                                DropDownstocklocation.DataValueField = "empemail";
                                DropDownstocklocation.DataBind();

                            }
                        }
                    }
                }
		 
		   ReportBindingPhoenix();
			 }
            ///--------------------------------
             if (Session["div"].ToString() == "CONCORD")
             {
                 #region for loading division dropdown
                 string constr_div = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                 using (SqlConnection conn_div = new SqlConnection(constr_div))
                 {

                     using (SqlCommand cmd_div = new SqlCommand("empsalesdivision"))
                     {
                         cmd_div.CommandType = CommandType.StoredProcedure;
                         cmd_div.Parameters.AddWithValue("@username", Session["username"].ToString());
                         //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                         //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                         using (SqlDataAdapter sda_div = new SqlDataAdapter())
                         {
                             cmd_div.Connection = conn_div;
                             sda_div.SelectCommand = cmd_div;
                             using (DataTable dt_div = new DataTable())
                             {
                                 sda_div.Fill(dt_div);
                                 //lbldiv.Text = dt.Rows[0][0].ToString();

                                 ddldivision.DataSource = dt_div;
                                 ddldivision.DataTextField = "division";
                                 ddldivision.DataValueField = "division";
                                 ddldivision.DataBind();
                                 ddldivision.Visible = true;
                                 lbldiv_div.Visible = true;


                             }
                         }
                     }
                 }
                 #endregion

                 DataSet ds = new DataSet();
                 //ds.Tables.Add(table1);

                 string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                 using (SqlConnection conn = new SqlConnection(constr))
                 {

                     using (SqlCommand cmd = new SqlCommand("Concord_userwise_higher"))
                     {
                         cmd.CommandType = CommandType.StoredProcedure;
                         cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                         //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                         //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                         using (SqlDataAdapter sda = new SqlDataAdapter())
                         {
                             cmd.Connection = conn;
                             sda.SelectCommand = cmd;
                             using (DataTable dt = new DataTable())
                             {
                                 sda.Fill(dt);
                                 //lbldiv.Text = dt.Rows[0][0].ToString();

                                 DropDownstocklocation.DataSource = dt;
                                 DropDownstocklocation.DataTextField = "name";
                                 DropDownstocklocation.DataValueField = "empemail";
                                 DropDownstocklocation.DataBind();

                             }
                         }
                     }
                 }

                 ReportBindingconcord();
             }
            //-----------------------------------------------------
        }
    }
protected void DropDownstocklocation_DataBound(object sender, EventArgs e)
    {
      DropDownstocklocation.Items.Insert(0, new ListItem("--SELECT--", "0"));
   }
   
   protected void ddldivision_DataBound(object sender, EventArgs e)
    {
      ddldivision.Items.Insert(0, new ListItem("--SELECT--", "0"));
   }
   
   protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
    {
		
		if(ddldivision.SelectedValue=="EVA")
		{
		
		 DataSet ds = new DataSet();
                //ds.Tables.Add(table1);

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    using (SqlCommand cmd = new SqlCommand("Eva_userwise_higher"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username",  Session["username"].ToString());
                        //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                        //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = conn;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                //lbldiv.Text = dt.Rows[0][0].ToString();

                                DropDownstocklocation.DataSource = dt;
                                DropDownstocklocation.DataTextField = "name";
                                DropDownstocklocation.DataValueField = "empemail";
                                DropDownstocklocation.DataBind();

                            }
                        }
                    }
                }
				ReportBindingeva();
		}
		
		if(ddldivision.SelectedValue=="PHOENIX")
		{
		
		 DataSet ds = new DataSet();
                //ds.Tables.Add(table1);

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    using (SqlCommand cmd = new SqlCommand("Phoenix_userwise_higher"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username",  Session["username"].ToString());
                        //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                        //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = conn;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                //lbldiv.Text = dt.Rows[0][0].ToString();

                                DropDownstocklocation.DataSource = dt;
                                DropDownstocklocation.DataTextField = "name";
                                DropDownstocklocation.DataValueField = "empemail";
                                DropDownstocklocation.DataBind();

                            }
                        }
                    }
                }
				ReportBindingPhoenix();
		}

        if (ddldivision.SelectedValue == "ROD")
        {

            DataSet ds = new DataSet();
            //ds.Tables.Add(table1);

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("Rod_userwise_higher"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                    //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                    //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = conn;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            //lbldiv.Text = dt.Rows[0][0].ToString();

                            DropDownstocklocation.DataSource = dt;
                            DropDownstocklocation.DataTextField = "name";
                            DropDownstocklocation.DataValueField = "empemail";
                            DropDownstocklocation.DataBind();

                        }
                    }
                }
            }
            ReportBindingRod();
        }

        if (ddldivision.SelectedValue == "CONCORD")
        {

            DataSet ds = new DataSet();
            //ds.Tables.Add(table1);

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("concord_userwise_higher"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                    //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                    //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = conn;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            //lbldiv.Text = dt.Rows[0][0].ToString();

                            DropDownstocklocation.DataSource = dt;
                            DropDownstocklocation.DataTextField = "name";
                            DropDownstocklocation.DataValueField = "empemail";
                            DropDownstocklocation.DataBind();

                        }
                    }
                }
            }
            ReportBindingconcord();
        }
	}
   
    public void ReportBinding()
    {
        //Data for binding to the Report
        //DataTable table1 = new DataTable("patients");
        //table1.Columns.Add("Name");
        //table1.Columns.Add("State");
        //table1.Columns.Add("Country");
        //table1.Columns.Add("CurrentResidence");
        //table1.Columns.Add("MaritalStatus");
        //table1.Columns.Add("EmploymentStatus");

        //table1.Rows.Add("Nadir", "Kerala", "India", "Bangalore", "Single","Is SelfEmployed");
        //table1.Rows.Add("Lijo", "Kerala", "India", "Philipines", "Single", "Is Salaried");
        //table1.Rows.Add("Shelley", "Kerala", "India", "Kashmir", "Married", "Is SelfEmployed");

        DataSet ds = new DataSet();
        //ds.Tables.Add(table1);

        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("Mad_userwise_sale"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username",  Session["username"].ToString());
                //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {

                        sda.Fill(dt);
                        ds.Tables.Add(dt);
                        rpt_daily.ReportTitle = "Daily Sales Report ";
                        rpt_daily.ReportName = "SalesReport";
                        rpt_daily.DataBind(ds);
                        rpt_daily.Visible = true;
                    }
                }
            }
        }
    }
	
	public void ReportBindingeva()
    {
        //Data for binding to the Report
        //DataTable table1 = new DataTable("patients");
        //table1.Columns.Add("Name");
        //table1.Columns.Add("State");
        //table1.Columns.Add("Country");
        //table1.Columns.Add("CurrentResidence");
        //table1.Columns.Add("MaritalStatus");
        //table1.Columns.Add("EmploymentStatus");

        //table1.Rows.Add("Nadir", "Kerala", "India", "Bangalore", "Single","Is SelfEmployed");
        //table1.Rows.Add("Lijo", "Kerala", "India", "Philipines", "Single", "Is Salaried");
        //table1.Rows.Add("Shelley", "Kerala", "India", "Kashmir", "Married", "Is SelfEmployed");

        DataSet ds = new DataSet();
        //ds.Tables.Add(table1);

        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("eva_userwise_sale"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {

                        sda.Fill(dt);
                        ds.Tables.Add(dt);
                        rpt_daily.ReportTitle = "Daily Sales Report ";
                        rpt_daily.ReportName = "SalesReport";
                        rpt_daily.DataBind(ds);
                        rpt_daily.Visible = true;
                    }
                }
            }
        }
    }
	
	public void ReportBindingPhoenix()
    {
        //Data for binding to the Report
        //DataTable table1 = new DataTable("patients");
        //table1.Columns.Add("Name");
        //table1.Columns.Add("State");
        //table1.Columns.Add("Country");
        //table1.Columns.Add("CurrentResidence");
        //table1.Columns.Add("MaritalStatus");
        //table1.Columns.Add("EmploymentStatus");

        //table1.Rows.Add("Nadir", "Kerala", "India", "Bangalore", "Single","Is SelfEmployed");
        //table1.Rows.Add("Lijo", "Kerala", "India", "Philipines", "Single", "Is Salaried");
        //table1.Rows.Add("Shelley", "Kerala", "India", "Kashmir", "Married", "Is SelfEmployed");

        DataSet ds = new DataSet();
        //ds.Tables.Add(table1);

        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("Phoenix_userwise_sale"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {

                        sda.Fill(dt);
                        ds.Tables.Add(dt);
                        rpt_daily.ReportTitle = "Daily Sales Report ";
                        rpt_daily.ReportName = "SalesReport";
                        rpt_daily.DataBind(ds);
                        rpt_daily.Visible = true;
                    }
                }
            }
        }
    }
    public void ReportBindingRod()
    {
        //Data for binding to the Report
        //DataTable table1 = new DataTable("patients");
        //table1.Columns.Add("Name");
        //table1.Columns.Add("State");
        //table1.Columns.Add("Country");
        //table1.Columns.Add("CurrentResidence");
        //table1.Columns.Add("MaritalStatus");
        //table1.Columns.Add("EmploymentStatus");

        //table1.Rows.Add("Nadir", "Kerala", "India", "Bangalore", "Single","Is SelfEmployed");
        //table1.Rows.Add("Lijo", "Kerala", "India", "Philipines", "Single", "Is Salaried");
        //table1.Rows.Add("Shelley", "Kerala", "India", "Kashmir", "Married", "Is SelfEmployed");

        DataSet ds = new DataSet();
        //ds.Tables.Add(table1);

        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("rod_userwise_sale"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {

                        sda.Fill(dt);
                        ds.Tables.Add(dt);
                        rpt_daily.ReportTitle = "Daily Sales Report ";
                        rpt_daily.ReportName = "SalesReport";
                        rpt_daily.DataBind(ds);
                        rpt_daily.Visible = true;
                    }
                }
            }
        }
    }
    public void ReportBindingconcord()
    {
        //Data for binding to the Report
        //DataTable table1 = new DataTable("patients");
        //table1.Columns.Add("Name");
        //table1.Columns.Add("State");
        //table1.Columns.Add("Country");
        //table1.Columns.Add("CurrentResidence");
        //table1.Columns.Add("MaritalStatus");
        //table1.Columns.Add("EmploymentStatus");

        //table1.Rows.Add("Nadir", "Kerala", "India", "Bangalore", "Single","Is SelfEmployed");
        //table1.Rows.Add("Lijo", "Kerala", "India", "Philipines", "Single", "Is Salaried");
        //table1.Rows.Add("Shelley", "Kerala", "India", "Kashmir", "Married", "Is SelfEmployed");

        DataSet ds = new DataSet();
        //ds.Tables.Add(table1);

        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("concord_userwise_sale"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {

                        sda.Fill(dt);
                        ds.Tables.Add(dt);
                        rpt_daily.ReportTitle = "Daily Sales Report ";
                        rpt_daily.ReportName = "SalesReport";
                        rpt_daily.DataBind(ds);
                        rpt_daily.Visible = true;
                    }
                }
            }
        }
    }
	
	protected void DropDownstocklocation_SelectedIndexChanged(object sender, EventArgs e)
    {
		
        //  if(Session["div"]=="MAD")
        //     {
        //Session["username"]=DropDownstocklocation.SelectedValue;
        ////lbldiv.Text = DropDownstocklocation.SelectedItem.ToString();//dt.Rows[0][0].ToString();
        //  ReportBinding();
        //     }
		  
        //   if(Session["div"]=="PHOENIX")
        //     {
        //         Session["username"]=DropDownstocklocation.SelectedValue;
        //          ReportBindingPhoenix();
        //     }
			 
        //      if(Session["div"]=="EVA")
        //     {
        //         Session["username"]=DropDownstocklocation.SelectedValue;
        //         if (ddldivision.SelectedValue == "ROD")
        //         {
        //             ReportBindingRod();
        //            // Session["username"] = User.Identity.Name;
        //         }
        //         else
        //         {
        //             ReportBindingeva();
        //            // Session["username"] = User.Identity.Name;
        //         }
        //     }
        string division = ddldivision.SelectedValue;
        switch (division)
        {
            case "EVA":
                {
                    Session["username"] = DropDownstocklocation.SelectedValue;
                    ReportBindingeva();
                    break;
                }
            case "MAD":
                {
                    Session["username"] = DropDownstocklocation.SelectedValue;
                    ReportBinding();
                    break;
                }
            case "PHOENIX":
                {
                    Session["username"] = DropDownstocklocation.SelectedValue;
                    ReportBindingPhoenix();
                    break;
                }
            case "ROD":
                {
                    Session["username"] = DropDownstocklocation.SelectedValue;
                    ReportBindingRod();
                    break;
                }
            case "CONCORD":
                {
                    Session["username"] = DropDownstocklocation.SelectedValue;
                    ReportBindingconcord();
                    break;
                }
            default:
                {
                    break;
                }
            
        }
    }
	
	 protected void btnstocksearch_Click(object sender, EventArgs e)
    {
//lbldiv.Text = DropDownstocklocation.SelectedItem.ToString();
    }

    protected void Ddlselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(""+Ddlselect.SelectedValue.ToString());
    }
}