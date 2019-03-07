var CreatedOKLodop7766 = null;

function getLodop(oOBJECT, oEMBED) {
    var LODOP;
    try {
        //=====判断浏览器类型:===============
        var isIE = (navigator.userAgent.indexOf('MSIE') >= 0) || (navigator.userAgent.indexOf('Trident') >= 0);
        var is64IE = isIE && (navigator.userAgent.indexOf('x64') >= 0);
        //=====如果页面有Lodop就直接使用，没有则新建:==========
        if (oOBJECT != undefined || oEMBED != undefined) {
            if (isIE)
                LODOP = oOBJECT;
            else
                LODOP = oEMBED;
        } else {
            if (CreatedOKLodop7766 == null) {
                LODOP = document.createElement("object");
                LODOP.setAttribute("width", 0);
                LODOP.setAttribute("height", 0);
                LODOP.setAttribute("style", "position:absolute;left:0px;top:-100px;width:0px;height:0px;");
                if (isIE) LODOP.setAttribute("classid", "clsid:2105C259-1E0C-4534-8141-A753534CB4CA");
                else LODOP.setAttribute("type", "application/x-print-lodop");
                document.documentElement.appendChild(LODOP);
                CreatedOKLodop7766 = LODOP;
            } else
                LODOP = CreatedOKLodop7766;
        };
        //=====判断Lodop插件是否安装过，没有安装或版本过低就提示下载安装:==========
        if ((LODOP == null) || (typeof (LODOP.VERSION) == "undefined")) {
            if (navigator.userAgent.indexOf('Chrome') >= 0)
                document.write("<h3><a href='../tools/lodop/install_lodop.exe'><font color='#A80A18' size='28'>&nbsp;&nbsp;请点击安装打印控件</font></a></h3>");
            if (navigator.userAgent.indexOf('Firefox') >= 0)
                document.write("<h3><a href='../tools/lodop/install_lodop.exe'><font color='#A80A18' size='28'>&nbsp;&nbsp;请点击安装打印控件</font></a></h3>");
            if (is64IE) document.write("<h3><a href='../tools/lodop/install_lodop64.exe'><font color='#A80A18' size='28'>&nbsp;&nbsp;请点击安装打印控件</font></a></h3>"); else
                if (isIE)
                    document.write("<h3><a href='../tools/lodop/install_lodop.exe'><font color='#A80A18' size='28'>&nbsp;&nbsp;请点击安装打印控件</font></a></h3>");
            return LODOP;
        } else
            if (LODOP.VERSION < "6.1.9.6") {
                if (is64IE) document.write("<h3><a href='../tools/lodop/install_lodop64.exe'><font color='#A80A18' size='28'>&nbsp;&nbsp;请点击安装打印控件</font></a></h3>"); else
                    if (isIE) 
                        document.write("<h3><a href='../tools/lodop/install_lodop.exe'><font color='#A80A18' size='28'>&nbsp;&nbsp;请点击安装打印控件</font></a></h3>");
                return LODOP;
            };
        //=====如下空白位置适合调用统一功能(如注册码、语言选择等):====	     
        LODOP.SET_LICENSES("", "394101451001069811011355115108", "", "");
        //============================================================	     
        return LODOP;
    } catch (err) {
        if (is64IE)
            document.write("<h3><a href='../tools/lodop/install_lodop64.exe'><font color='#A80A18' size='28'>&nbsp;&nbsp;请点击安装打印控件</font></a></h3>"); else
            document.write("<h3><a href='../tools/lodop/install_lodop.exe'><font color='#A80A18' size='28'>&nbsp;&nbsp;请点击安装打印控件</font></a></h3>");
        return LODOP;
    };
}