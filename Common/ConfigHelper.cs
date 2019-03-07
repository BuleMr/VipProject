using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// ConfigHelper
/// </summary>
public class ConfigHelper
{
	public ConfigHelper()
	{

	}
    public static String GetValueByKey(String Key)
    {
        return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}
