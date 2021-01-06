
using model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RptAgeingDL
/// </summary>
/// 

namespace DataLayer
{
    public class RptDocVisitDL
    {
        public RptDocVisitDL()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public MendineMasterdummyDataSet GetAgeingReportData(SearchAgeing itmsearch)
        {
            RptAgeingList lstAgeing = new RptAgeingList();
            Common.OpenConnection();
            String sql = "select * from rpt_ageing";
            string whsql = "";
            string strconcat = "";
            if (itmsearch.rsm != null && itmsearch.rsm != "" && itmsearch.rsm != "select")
            {
                whsql = whsql + strconcat + " RSMHQ like '%" + itmsearch.rsm + "%'";
                strconcat = " and ";
            }
            if (itmsearch.asm != null && itmsearch.asm != "" && itmsearch.asm != "select")
            {
                whsql = whsql + strconcat + " ASMHQ like '%" + itmsearch.asm + "%'";
                strconcat = " and ";
            }
            if (itmsearch.msr != null && itmsearch.msr != "" && itmsearch.msr != "select")
            {
                whsql = whsql + strconcat + " MSRHQ like '%" + itmsearch.msr + "%'";
                strconcat = " and ";
            }
            if (itmsearch.area != null && itmsearch.area != "" && itmsearch.area != "select")
            {
                whsql = whsql + strconcat + " Area like '%" + itmsearch.area + "%'";
                strconcat = " and ";
            }
            if (itmsearch.doctor != null && itmsearch.doctor != "" && itmsearch.doctor != "select")
            {
                whsql = whsql + strconcat + " DoctorName like '%" + itmsearch.doctor + "%'";
                strconcat = " and ";
            }

            if (itmsearch.intFrom > 0 && itmsearch.intTo > 0)
            {
                string months = "";
                string separator = "";
                int count = itmsearch.intFrom;
                while (count <= itmsearch.intTo)
                {
                    months = months + separator + "'" + Common.monthlist.ElementAt(count) + "'";
                    separator = ",";
                    count++;
                }

                whsql = whsql + strconcat + " month in (" + months + ")";
            }

            if (whsql != null && whsql != "")
                sql = sql + " where " + whsql;

            SqlCommand cmd = new SqlCommand(sql, Common.conn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //return dt;

            MendineMasterdummyDataSet dsCustomers = new MendineMasterdummyDataSet();
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                sda.SelectCommand = cmd;
                sda.Fill(dsCustomers, "rpt_ageing");
            }

            return dsCustomers;



            //using (SqlDataReader rdr = cmd.ExecuteReader())
            //{
            //    while (rdr.Read())
            //    {
            //        RptAgeing itmaging = new RptAgeing();
            //        itmaging.ZsmHQ = Common.GetString(rdr["ZsmHQ"]);
            //        itmaging.Area = Common.GetString(rdr["Area"]);
            //        itmaging.AreaType = Common.GetString(rdr["AreaType"]);
            //        itmaging.DoctorName = Common.GetString(rdr["DoctorName"]);
            //        lstAgeing.Add(itmaging);
            //    }
            //}



        }

        public StaticData GetDropdownData(string pmonth)
        {
            StaticData itmstaticdata = PopulateDropdownOnData("division", "'eva'", pmonth, "");

            itmstaticdata.lstdivision = new List<string>();
            //itmstaticdata.lstdivision.Add("select");
            itmstaticdata.lstdivision.Add("EVA");
            itmstaticdata.lstdivision.Add("MAD");
            itmstaticdata.lstdivision.Add("PHOENIX");
            itmstaticdata.lstdivision.Add("CONCORD");


            return itmstaticdata;
        }

        public StaticData PopulateDropdownOnData(string filteron, string values)
        {
            return PopulateDropdownOnData(filteron, values, "", "");
        }

        public StaticData PopulateDropdownOnData(string filteron, string values,string mvalue,string dvalue)
        {
            Common.OpenConnection();
            StaticData itmstaticdata = new StaticData();

            itmstaticdata.lstdistrict = new List<string>();
            itmstaticdata.lstemployee = new List<string>();
            itmstaticdata.lstdesignation = new List<string>();
            itmstaticdata.lstrsm = new List<string>();
            itmstaticdata.lstdivision = new List<string>();
            itmstaticdata.lstasm = new List<string>();
            itmstaticdata.lstmsr = new List<string>();


            if (filteron != null && filteron != "" && filteron.ToLower() == "month")
            {
                string sql = "select distinct Division from rpt_doctorvisit where lower(month) ='" + values.ToLower() + "'";
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdivision.Add(Common.GetString(rdr["Division"]));
                }
                rdr.Close();

                sql = "select distinct RsmHQ from rpt_doctorvisit where lower(month) ='" + values.ToLower() + "'";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (Common.GetString(rdr["RsmHQ"]) != "")
                        itmstaticdata.lstrsm.Add(Common.GetString(rdr["RsmHQ"]));
                }
                rdr.Close();

                sql = "select distinct Area from rpt_doctorvisit where lower(month) ='" + values.ToLower() + "'";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdistrict.Add(Common.GetString(rdr["Area"]));
                }
                rdr.Close();

                sql = "select distinct employee from rpt_doctorvisit where lower(month) ='" + values.ToLower() + "'";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstemployee.Add(Common.GetString(rdr["employee"]));
                }
                rdr.Close();

                sql = "select distinct designation from rpt_doctorvisit where lower(month) ='" + values.ToLower() + "'";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdesignation.Add(Common.GetString(rdr["designation"]));
                }
                rdr.Close();

                sql = "select distinct AsmHQ from rpt_doctorvisit where lower(month) ='" + values.ToLower() + "'";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstasm.Add(Common.GetString(rdr["AsmHQ"]));
                }
                rdr.Close();

                sql = "select distinct MFSOHQ from rpt_doctorvisit where lower(month) ='" + values.ToLower() + "'";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstmsr.Add(Common.GetString(rdr["MFSOHQ"]));
                }
                rdr.Close();
            }


            if (filteron != null && filteron != "" && filteron.ToLower() == "division")
            {
                string extra = "";
                if (mvalue != null && mvalue != "")
                    extra = " and lower(month)=" + mvalue.ToLower() + "";

                string sql = "select distinct RsmHQ from rpt_doctorvisit where lower(division) in(" + values.ToLower() + ")" + extra;
                
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (Common.GetString(rdr["RsmHQ"]) != "")
                        itmstaticdata.lstrsm.Add(Common.GetString(rdr["RsmHQ"]));
                }
                rdr.Close();

                sql = "select distinct Area from rpt_doctorvisit where lower(division) in(" + values.ToLower() + ")" + extra;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdistrict.Add(Common.GetString(rdr["Area"]));
                }
                rdr.Close();

                sql = "select distinct empname from rpt_doctorvisit where lower(division) in(" + values.ToLower() + ")" + extra;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstemployee.Add(Common.GetString(rdr["empname"]));
                }
                rdr.Close();

                sql = "select distinct designation from rpt_doctorvisit where lower(division) in(" + values.ToLower() + ")" + extra;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdesignation.Add(Common.GetString(rdr["designation"]));
                }
                rdr.Close();

                sql = "select distinct AsmHQ from rpt_doctorvisit where lower(division) in(" + values.ToLower() + ")" + extra;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstasm.Add(Common.GetString(rdr["AsmHQ"]));
                }
                rdr.Close();

                sql = "select distinct MFSOHQ from rpt_doctorvisit where lower(division) in(" + values.ToLower() + ")" + extra;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstmsr.Add(Common.GetString(rdr["MFSOHQ"]));
                }
                rdr.Close();
            }


            if (filteron != null && filteron != "" && filteron.ToLower() == "rsm")
            {
                string extra1 = "",extra2="";
                if(mvalue!=null && mvalue!="")
                    extra1=" and lower(month)='" + mvalue.ToLower() + "'";

                if(dvalue!=null && dvalue!="")
                    extra2 =" and lower(division) in (" + dvalue.ToLower() + ")";


                string sql = "select distinct District from rpt_doctorvisit where RsmHQ ='" + values + "'" + extra1 + extra2;
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdistrict.Add(Common.GetString(rdr["District"]));
                }
                rdr.Close();

                sql = "select distinct empname from rpt_doctorvisit where RsmHQ ='" + values + "'" + extra1 + extra2;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstemployee.Add(Common.GetString(rdr["empname"]));
                }
                rdr.Close();

                sql = "select distinct designation from rpt_doctorvisit where RsmHQ ='" + values + "'" + extra1 + extra2;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdesignation.Add(Common.GetString(rdr["designation"]));
                }
                rdr.Close();
            }


            if (filteron != null && filteron != "" && filteron.ToLower() == "District")
            {
                string extra1 = "", extra2 = "";
                if (mvalue != null && mvalue != "")
                    extra1 = " and lower(month)='" + mvalue.ToLower() + "'";

                if (dvalue != null && dvalue != "")
                    extra2 = " and lower(division) in (" + dvalue.ToLower() + ")";

                string sql = "select distinct empname from rpt_doctorvisit where District ='" + values + "'" + extra1 + extra2;
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstemployee.Add(Common.GetString(rdr["empname"]));
                }
                rdr.Close();

                sql = "select distinct designation from rpt_doctorvisit where District ='" + values + "'" + extra1 + extra2;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdesignation.Add(Common.GetString(rdr["designation"]));
                }
                rdr.Close();
            }


            if (filteron != null && filteron != "" && filteron.ToLower() == "employee")
            {
                
                string extra1 = "", extra2 = "";
                if (mvalue != null && mvalue != "")
                    extra1 = " and lower(month)='" + mvalue.ToLower() + "'";

                if (dvalue != null && dvalue != "")
                    extra2 = " and lower(division) in (" + dvalue.ToLower() + ")";

                string sql = "select distinct designation from rpt_doctorvisit where Area ='" + values + "'" + extra1 + extra2;
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdesignation.Add(Common.GetString(rdr["designation"]));
                }
                rdr.Close();
            }

            Common.CloseConnection();

            return itmstaticdata;
        }

        public DataSet GetDoctorVisitReportDataDynamic(SearchDoctorVisit itmsearch, int rows)
        {
            RptAgeingList lstAgeing = new RptAgeingList();
            Common.OpenConnection();
            String sql = "select * from rpt_doctorvisit";
            if (rows > 0)
                sql = "select top " + rows + " * from rpt_doctorvisit";

            string whsql = "";
            string strconcat = "";
            if (itmsearch.months != null && itmsearch.months != "")
            {
                whsql = whsql + strconcat + " month in (" + itmsearch.months + ")";
                strconcat = " and ";
            }

            if (itmsearch.divs != null && itmsearch.divs != "" && itmsearch.divs != "select")
            {
                whsql = whsql + strconcat + " division in(" + itmsearch.divs + ")";
                strconcat = " and ";
            }

            if (itmsearch.rsms != null && itmsearch.rsms != "" && itmsearch.rsms != "select")
            {
                whsql = whsql + strconcat + " RSMHQ in (" + itmsearch.rsms + ")";
                strconcat = " and ";
            }

            if (itmsearch.dists != null && itmsearch.dists != "" && itmsearch.dists != "select")
            {
                whsql = whsql + strconcat + " Area in (" + itmsearch.dists + ")";
                strconcat = " and ";
            }

            if (itmsearch.emps != null && itmsearch.emps != "" && itmsearch.emps != "select")
            {
                whsql = whsql + strconcat + " EmpName in (" + itmsearch.emps + ")";
                strconcat = " and ";
            }

            if (itmsearch.desigs != null && itmsearch.desigs != "" && itmsearch.desigs != "select")
            {
                whsql = whsql + strconcat + " Designation in (" + itmsearch.desigs + ")";
                strconcat = " and ";
            }

            if(itmsearch.asms!=null && itmsearch.asms!="" && itmsearch.asms != "select")
            {
                whsql = whsql + strconcat + " AsmHQ in (" + itmsearch.asms + ")";
                strconcat = " and ";
            }

            if (itmsearch.msrs != null && itmsearch.msrs != "" && itmsearch.msrs != "select")
            {
                whsql = whsql + strconcat + " MFSOHQ in (" + itmsearch.msrs + ")";
                strconcat = " and ";
            }


            if (whsql != null && whsql != "")
                sql = sql + " where " + whsql;

            SqlCommand cmd = new SqlCommand(sql, Common.conn);
            DataSet dsCustomers = new DataSet();
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                sda.SelectCommand = cmd;
                //sda.Fill(dsCustomers, "rpt_ageing");
                sda.Fill(dsCustomers);
            }
            Common.CloseConnection();

            return dsCustomers;

        }



        public String populateReportFromSP(string mont,int mno)
        {
            String ret = "";
            
            Common.OpenConnection();
            string sql = "delete from rpt_doctorvisit where monthno=" + mno;
            SqlCommand cmd = new SqlCommand(sql, Common.conn);
            cmd.ExecuteNonQuery();

            using (SqlCommand cmd1 = new SqlCommand("SaveDoctorVisitReportFromDT"))
            {
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Connection = Common.conn;
                cmd1.Parameters.AddWithValue("@mname", mont);
                cmd1.Parameters.AddWithValue("@mn", mno);
                cmd1.ExecuteNonQuery();

            }
            Common.CloseConnection();

            ret = "Execution completed for Doctor Visit report";
            return ret;
        }
    }
}