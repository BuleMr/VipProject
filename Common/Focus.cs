using System; 
using System.Text;
using System.Web.UI; 

/// <summary>
///控件获取焦点类
/// </summary>
public class Focus
{
	public Focus()
	{
	}

    public void SetFocus(System.Web.UI.Page page, String m_focusedControl) 
    { 
    //如果控件名称为空，则返回 
    if(m_focusedControl == "") 
    return; 
    //添加脚本以声明函数 
    StringBuilder sb = new StringBuilder(""); 
    sb.Append("<script language=javascript>"); 
    sb.Append("function "); 
    sb.Append("setFocusFunctionName"); 
    sb.Append("(ctl) {"); 
    sb.Append("if(document.forms[0][ctl] != null) ");//如果不为空，则设置焦点，这里调用的Javascript里面的方法 
    sb.Append(" document.forms[0][ctl].focus();" ); 
    sb.Append("}"); 

    //添加脚本以调用函数 
    sb.Append("setFocusFunctionName"); 
    sb.Append("('"); 
    sb.Append(m_focusedControl); 
    sb.Append("');"); 
    sb.Append("</"); 
    sb.Append("script>"); 

    if (!page.IsStartupScriptRegistered("SetFocusScriptName"))  
    page.RegisterStartupScript("SetFocusScriptName", sb.ToString());//将这段javascript代码写到页面中去 
   
    } 
     
    public void SetEnterControl(System.Web.UI.Control Ctrl)  
    {  
    Page mPage = Ctrl.Page;  
    string mScript;  
    mScript = @"<script language=""javascript"">  
    function document.onkeydown()  
    {  
    var e = event.srcElement;  
    var k = event.keyCode;  
    if (k == 13 && e.type != ""textarea"")  
    {  
    document.all." + Ctrl.ClientID + @".click();  
    event.cancelBubble = true;  
    event.returnValue = false;  
    }  
    }  
    </script>";  
    if(!mPage.IsClientScriptBlockRegistered("SetEnterControl"))  
    mPage.RegisterClientScriptBlock("SetEnterControl",mScript);  
    
    } 
} 

