using DataLayer;
using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for DoctorVisitJSON
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DoctorVisitJSON : System.Web.Services.WebService
{

    public DoctorVisitJSON()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public String PopulateAllData(String filteron, String value, String mvalue, String dvalue)
    {
        StaticData itmstaticdata = (new RptDocVisitDL()).PopulateDropdownOnData(filteron, value, mvalue, dvalue);

        String outstr = "";
        StringBuilder sb = new StringBuilder();
        foreach (String str in itmstaticdata.lstrsm)
        {
            sb.Append("<option class='checkbox'>" + str + "</option>");
        }



        outstr = sb.ToString();
        return outstr;
    }

}
