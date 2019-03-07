using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vipProject.WeatherService;


public partial class paymentmanager_select_weather : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        WeatherWebService w = new WeatherWebService();
        string[] res = new string[23];
        string cityname = txtcity.Text.Trim();
        res = w.getWeatherbyCityName(cityname);
        lbtianqi.Text = cityname + " " + res[6];
        txtcityweather.Text = res[10];
    }
}
