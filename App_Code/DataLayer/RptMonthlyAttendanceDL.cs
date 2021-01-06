
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
    public class RptMonthlyAttendanceDL
    {
        public RptMonthlyAttendanceDL()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public StaticData GetDropdownData(string pmonth,string yr)
        {
            StaticData itmstaticdata = PopulateDropdownOnData("division", "'eva'",yr, pmonth, "");

            itmstaticdata.lstdivision = new List<string>();
            //itmstaticdata.lstdivision.Add("select");
            itmstaticdata.lstdivision.Add("EVA");
            itmstaticdata.lstdivision.Add("MAD");
            itmstaticdata.lstdivision.Add("PHOENIX");
            itmstaticdata.lstdivision.Add("CONCORD");


            return itmstaticdata;
        }

        public StaticData PopulateDropdownOnData(string filteron, string values,string yr)
        {
            return PopulateDropdownOnData(filteron, values,yr, "", "");
        }

        public StaticData PopulateDropdownOnData(string filteron, string values, string yr, string mvalue, string dvalue)
        {
            Common.OpenConnection();
            StaticData itmstaticdata = new StaticData();

            itmstaticdata.lstdistrict = new List<string>();
            itmstaticdata.lstemployee = new List<string>();
            itmstaticdata.lstdivision = new List<string>();
            itmstaticdata.lstarea = new List<string>();
            itmstaticdata.lstzsm = new List<string>();
            itmstaticdata.lstrsm = new List<string>();
            itmstaticdata.lsthq = new List<string>();

            if (filteron != null && filteron != "" && filteron.ToLower() == "month")
            {
                string sql = "select distinct Division from rpt_monthlyattendance where lower(month) ='" + values.ToLower() + "'" + " and year='" + yr + "'";
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdivision.Add(Common.GetString(rdr["Division"]));
                }
                rdr.Close();

                //zsm
                sql = "select distinct District from rpt_monthlyattendance where lower(month) ='" + values.ToLower() + "'" + " and year='" + yr + "'";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (Common.GetString(rdr["District"]) != "")
                        itmstaticdata.lstzsm.Add(Common.GetString(rdr["District"]));
                }
                rdr.Close();

                sql = "select distinct EmpName from rpt_monthlyattendance where lower(month) ='" + values.ToLower() + "'" + " and year='" + yr + "'";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstemployee.Add(Common.GetString(rdr["EmpName"]));
                }
                rdr.Close();


            }


            if (filteron != null && filteron != "" && filteron.ToLower() == "division")
            {
                string extra = "";
                if (mvalue != null && mvalue != "")
                    extra = " and lower(month)=" + mvalue.ToLower() + "" + " and year='" + yr + "'";

                //zsm
                string sql = "select distinct District from rpt_monthlyattendance where lower(division) in(" + values.ToLower() + ")" + extra;
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (Common.GetString(rdr["District"]) != "")
                        itmstaticdata.lstdistrict.Add(Common.GetString(rdr["District"]));
                }
                rdr.Close();

                sql = "select distinct EmpName from rpt_monthlyattendance where lower(division) in(" + values.ToLower() + ")" + extra;
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstemployee.Add(Common.GetString(rdr["EmpName"]));
                }
                rdr.Close();

            }


            Common.CloseConnection();

            return itmstaticdata;
        }

        public DataSet GetSampleReportDataDynamic(SearchReportCommon itmsearch, int rows)
        {
            Common.OpenConnection();
            
            String sql = "select * from rpt_monthlyattendance";
            if (rows > 0)
                sql = "select top " + rows + " * from rpt_monthlyattendance";

            string whsql = "";
            string strconcat = "";
            if (itmsearch.months != null && itmsearch.months != "")
            {
                whsql = whsql + strconcat + " month in (" + itmsearch.months + ")";
                strconcat = " and ";
            }

            if(itmsearch.yr!=null && itmsearch.yr != "")
            {
                whsql = whsql + strconcat + " year ='" + itmsearch.yr + "'";
                strconcat = " and ";
            }

            if (itmsearch.divs != null && itmsearch.divs != "" && itmsearch.divs != "select")
            {
                whsql = whsql + strconcat + " division in(" + itmsearch.divs + ")";
                strconcat = " and ";
            }

            if (itmsearch.dists != null && itmsearch.dists != "" && itmsearch.dists != "select")
            {
                whsql = whsql + strconcat + " DISTRICT in(" + itmsearch.dists + ")";
                strconcat = " and ";
            }

            if (itmsearch.emps != null && itmsearch.emps != "" && itmsearch.emps != "select")
            {
                whsql = whsql + strconcat + " empname in (" + itmsearch.emps + ")";
                strconcat = " and ";
            }


            if (whsql != null && whsql != "")
                sql = sql + " where " + whsql;

            SqlCommand cmd = new SqlCommand(sql, Common.conn);
            DataSet dsCustomers = new DataSet();
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                sda.SelectCommand = cmd;
                sda.Fill(dsCustomers);
            }
            Common.CloseConnection();

            return dsCustomers;

        }



        public String populateReportFromSP(string mont,int mno)
        {
            String ret = "";

            int curyear = DateTime.Now.Year;
            int curmn = DateTime.Now.Month;
            if (mno > curmn)
                curyear = curyear - 1;

            DateTime dt = Convert.ToDateTime("01/" + mno + "/" + curyear);
            String searchdata = mont.Substring(0, 3) +"'"+ dt.ToString("yy");
            
            Common.OpenConnection();
            string sql = "delete from rpt_monthlyattendance where monthno=" + mno + " and year='" + curyear.ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, Common.conn);
            cmd.ExecuteNonQuery();

            using (SqlCommand cmd1 = new SqlCommand("SaveMonthlyAttendanceReportFromDT"))
            {
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Connection = Common.conn;
                cmd1.Parameters.AddWithValue("@mname", mont);
                cmd1.Parameters.AddWithValue("@mn", mno);
                cmd1.Parameters.AddWithValue("@year", curyear);
                cmd1.Parameters.AddWithValue("@search", searchdata);
                cmd1.ExecuteNonQuery();

            }
            Common.CloseConnection();

            ret = "Execution completed for Monthly Attendance report";
            return ret;
        }
    }
}