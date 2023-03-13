//<!--
var thisUrl = location.href;
servername = thisUrl.substr(thisUrl.indexOf('//')+2,thisUrl.indexOf('/',thisUrl.indexOf('//')+2)-(thisUrl.indexOf('//')+2));

if (servername == '') servername = "localhost";


var App_VirtualRoot = "/cportal"
var App_ServerPath = thisUrl.substr(0,thisUrl.indexOf('/',thisUrl.indexOf('//')+2));
var App_WebRoot = App_ServerPath+App_VirtualRoot
//derive webroot from the url
var App_FullWebRoot = thisUrl.substr(0, thisUrl.indexOf('?'));
var App_ImageRoot = App_WebRoot+"/images/";

/* This Set of functions are used to simplify tab scrolling in cPortal PortalHeader.jsp */
function resetTabBand(tabType) {   
    if(document.getElementById("cp_cs_"+tabType+"_band")){              
        document.getElementById("cp_cs_"+tabType+"_band").value = 0;
    }
}
function scrollTabToLeft(tabType) {                 
    
    var currentBand = parseInt(document.getElementById("cp_cs_"+tabType+"_band").value,10);
    var maxBand = parseInt(document.getElementById("cpMaximum"+tabType+"Band").value,10);
    
    
    if(currentBand != 0){               
        if((currentBand-1) == 0){
            document.getElementById(tabType+"LeftScroll").style.display = "none"; 
        }
        if(currentBand < maxBand ){
            document.getElementById(tabType+"RightScroll").style.display = ""; 
            document.getElementById(tabType+"RightScroll2").style.display = "none";
        }                
        document.getElementById("cp_cs_"+tabType+"_band").value=currentBand-1;                
        document.getElementById(tabType+"Band"+(currentBand-1)).style.display = ""; 
        document.getElementById(tabType+"Band"+currentBand).style.display = "none";
        
    }
    
}

function scrollTabToRight(tabType) {
    var currentBand = parseInt(document.getElementById("cp_cs_"+tabType+"_band").value,10);
    var maxBand = parseInt(document.getElementById("cpMaximum"+tabType+"Band").value,10);
    
    if(currentBand < maxBand){               
        if((currentBand+2) == maxBand){				 
            document.getElementById(tabType+"RightScroll").style.display = 'none'; 				
            document.getElementById(tabType+"RightScroll2").style.display = ""; 
            
        }
        if(currentBand < maxBand){
            document.getElementById(tabType+"LeftScroll").style.display = ""; 
        }
        document.getElementById("cp_cs_"+tabType+"_band").value=currentBand+1;                
        document.getElementById(tabType+"Band"+(currentBand+1)).style.display = ""; 
        document.getElementById(tabType+"Band"+currentBand).style.display = "none";
        
    }    
    
}

function doSubmitTab(tabname) {
    var theform = document.getElementById("defaultForm");
    if(theform){
	   progressView();
        theform.TabName.value = tabname;    
        theform.submit();
    }else{
	   progressView();
        theform = document.defaultForm;
        theform.TabName.value = tabname;    
        theform.submit();
    }
}

/* End of Tab specific functions */


function App_NewWindow(pUrl,pWidth,pHeight,pTop,pLeft,pEtc) {
    win_New = window.open(pUrl,"win_New","width="+pWidth+",height="+pHeight+",top="+pTop+",left="+pLeft+pEtc);
    win_New.focus();
}

function fullScreen(pUrl) {
    App_NewWindow(pUrl,window.screen.width,window.screen.height,0,0,", toolbar=yes, menubar=yes");
}

function openWindow(pUrl) {
    App_NewWindow(pUrl,window.screen.width-100,window.screen.height-100,10,10,", toolbar=yes, menubar=yes, scrollbars=yes, status=yes, resizable=yes");
    
}
function windowClose(part,moduleWindowState) {
    var thisPart = document.all[part];
    if (thisPart.style.display == '') {
        thisPart.style.display = "none";		
    } else {
        thisPart.style.display = "";		
    }
    document.all[moduleWindowState].value=document.all["ClosedWindowValue"].value;	
    //document.getElementById(moduleWindowState).value=document.getElementById("ClosedWindowValue").value;
    
}

function windowMaximize(moduleWindowState) {
    //document.getElementById(moduleWindowState).value=document.getElementById("MaximizedWindowValue").value;
    document.all[moduleWindowState].value=document.all["MaximizedWindowValue"].value;
}
function windowRestoreMinimize(part,alt,moduleWindowState,imageRoot) {
    var thisPart = document.all['part'+part];
    var thisImg = document.all['min'+part];
    if (thisPart.style.display == '') {
        thisPart.style.display = "none";
        thisImg.src = imageRoot+"restore"+alt+".gif";
        document.getElementById(moduleWindowState).value=document.getElementById("MinimizedWindowValue").value;
        //document.all[moduleWindowState].value=document.all["MinimizedWindowValue"].value;
    } else {
        thisPart.style.display = "";
        thisImg.src = App_ImageRoot+"min"+alt+".gif";
        document.getElementById(moduleWindowState).value=document.getElementById("NormalizedWindowValue").value;
        //document.all[moduleWindowState].value=document.all["NormalizedWindowValue"].value;
    }
}
function windowRestoreMaximize(moduleWindowState) {
    if(document.getElementById(moduleWindowState)){
        document.getElementById(moduleWindowState).value=document.getElementById("NormalizedWindowValue").value;
    }else{
        document.all[moduleWindowState].value=document.all["NormalizedWindowValue"].value;
    }
}

function App_MinMax(part,alt) {
    var thisPart = document.all['part'+part];
    var thisImg = document.all['min'+part];
    if (thisPart.style.display == '') {
        thisPart.style.display = "none";
        thisImg.src = App_ImageRoot+"plus"+alt+".gif";
    } else {
        thisPart.style.display = "";
        thisImg.src = App_ImageRoot+"minus"+alt+".gif";
    }
}
function App_MinMax(part,alt,moduleWindowState) {
    var thisPart = document.all['part'+part];
    var thisImg = document.all['min'+part];
    if (thisPart.style.display == '') {
        thisPart.style.display = "none";
        thisImg.src = App_ImageRoot+"plus"+alt+".gif";
        document.getElementById(moduleWindowState).value=document.getElementById("MinimizedWindowValue").value;
    } else {
        thisPart.style.display = "";
        thisImg.src = App_ImageRoot+"minus"+alt+".gif";
        document.getElementById(moduleWindowState).value=document.getElementById("NormalizedWindowValue").value;
    }
}
function disableEnterKey(){
    if(event.keyCode == 13) event.returnValue = false;
    event.cancelBubble = true
}

//still leave for now, study more with time
function App_FindMatch(param) {
    var sURL =  App_VirtualRoot+"/services/peopleFinder.aspx?"+param;
    App_NewWindow(sURL,700,400,100,50,'",scrollbars=1"');
}

function Footer_Link(pagename) {
    var sURL = App_VirtualRoot + "/services/footerLinks.aspx?id=" + pagename;
    App_NewWindow(sURL,400,300,100,50,'",scrollbars=1"');
}


function doOnload(redirect, newUrl) {
    if (redirect) {
        //move to specified page
        window.location.href = newUrl;
    } else {
        document.getElementById('splashScreen').style.visibility='hidden';
        document.getElementById('contentScreen').style.display='';
    }
}

function loadHelp() {
    window.location.href = App_FullWebRoot + "?Event=default&TabName=Help";
}

function doSubmit(target, action) {
    progressView();
    doSubmitAllModules(target, action);	
     //doSubmitPage(target, action);	
}
function doSubmitPage(target, action) {
    var theform = document.defaultForm;
    theform.Target.value = target;
    theform.Action.value = action;
    theform.submit();
}


function doSubmitState(target, action,windowState) {		
    //fn_AjaxSubmit(target, action, windowState,"","RefreshContent", true);
    doSubmitState2(target, action,windowState);
}
function doSubmitState2(target, action,windowState) {
    var theform = document.defaultForm;
    theform.Target.value = target;
    theform.Action.value = action;
    theform.WindowState.value = windowState;
    theform.submit();
}



function showAlert(msg) {
    alert(msg);
    
}

// Ajax stuff

function doAjaxCall(target, method, paramArray, callBack, asynch){
    outerCallback = callBack;
    var params = "Event=ajax&Target="+target+"&CallType=SingleValue&CallFunction="+method;
    for(i=0;i < paramArray.length;i++){
        params+="&CallParameter="+paramArray[i];
    }
    return sendAjaxRequest(App_FullWebRoot+"?"+params, asynch, callSubmitCallback);
}
function showLoadDiv(target){
  if(document.getElementById("progressLoadingDivDataFrame") !=window.undefined && document.getElementById("progressLoadingDivDataFrame") !=null){
  	document.getElementById("progressLoadingDivDataFrame").style.display="block";
  }else{  
  	    progressView();
    }
}
function hideLoadDiv(target){
	if(document.getElementById("progressLoadingDivDataFrame") !=window.undefined && document.getElementById("progressLoadingDivDataFrame") !=null){
		document.getElementsByTagName("body")[0].removeChild(document.getElementById("progressLoadingDivDataFrame"));
	}else{
		//nothing dey happen says leke
	}
        document.getElementsByTagName("body")[0].scrollTop=1;
}
var req;
var outerCallback;
var _sFormData;
/*
function fn_AjaxSubmit(target, action, windowState,extraParam,callType, asynch){
    showLoadDiv(target);
    
    //alert("CALL 2");
    var divs = document.getElementsByTagName("div");
    var params = "Event=ajax&Target="+target+"&Action="+action+"&WindowState="+windowState+"&CallType="+callType+extraParam;
    for(i=0;i < divs.length;i++){
        if(divs[i].id==null) continue;
        if(divs[i].id.indexOf(target) >= 0) break;
    }
    if(i < divs.length){
        var elements = divs[i].all;
          for(j=0;j<elements.length;j++){
            if(elements[j].name==null) continue;
 
            if(elements[j].type=="checkbox"){
                if(elements[j].checked){
                    params+="&"+elements[j].name+"="+elements[j].value;
                }
            }else{
                params+="&"+elements[j].name+"="+elements[j].value;
            }
 
        }
    }
    //alert(params.length);
    if(params.length<2000){
        //alert("using get");
        if(!sendAjaxRequest(App_FullWebRoot+"?"+params, asynch, ajaxSubmitCallback)){
            doSubmitState2(target, action,windowState);
        }
    }else{
        //alert("using post");
        if(!sendAjaxPostRequest(App_FullWebRoot,params, asynch, ajaxSubmitCallback)){
            doSubmitState2(target, action,windowState);
        }
    }
 
}
 */
function encodeURIComponent(param){
    return param;
}

function provideElementArray(){
	var array = new Array();
	var elem = document.getElementsByTagName("INPUT");
	var elem2 = document.getElementsByTagName("SELECT");
	// new addition by leke
	var elem3 = document.getElementsByTagName("TEXTAREA");
	for(var i=0; i< elem.length; i++){
	array[array.length] = elem[i];
	}
	//after the input; now the select;
	
	for(var k=0; k< elem2.length; k++){
	array[array.length] = elem2[k];
	}
	
	//for textarea values
	// new addition by leke
	for(var t=0; t< elem3.length; t++){
	array[array.length] = elem3[t];
	}
	return array;
}

function fn_AjaxSubmit(target, action, windowState,extraParam,callType, asynch){
    try{
   	 showLoadDiv(target);
    	
    	
	var oForm = provideElementArray();
	 var oElement, oName, oValue, oDisabled;
    var hasSubmit = false;
    _sFormData="";
    // Iterate over the form elements collection to construct the
    // label-value pairs.
    //alert("FormData Length = " +oForm.elements.length );
    for (var i=0; i<oForm.length; i++){
        oDisabled = oForm[i].disabled;
        
        // If the name attribute is not populated, the form field's
        // value will not be submitted.
        oElement = oForm[i];
        oName = oForm[i].name;
        oValue = oForm[i].value;
		
        //alert( oName + oValue);
        // Do not submit fields that are disabled or
        // do not have a name attribute value.
        if(!oDisabled && oName && oName!="Action" && oName!="Target" && oName!="WindowState" ) {
        	  switch (oElement.type) {
                case 'select-one':
                case 'select-multiple':
                    for(var j=0; j<oElement.options.length; j++){
                        if(oElement.options[j].selected){
                            _sFormData += encodeURIComponent(oName) + '=' + encodeURIComponent(oElement.options[j].value || oElement.options[j].text) + '&';
                        }
                    }
                    break;
                case 'radio':
                case 'checkbox':
                    if(oElement.checked){
				_sFormData += encodeURIComponent(oName) + '=' + encodeURIComponent(oValue) + '&';
                    }
                    break;
                case 'file':
                    // stub case as XMLHttpRequest will only send the file path as a string.
                case undefined:
                    // stub case for fieldset element which returns undefined.
                case 'reset':
                    // stub case for input type reset button.
                case 'button':
                    // stub case for input type button elements.
                    break;
                case 'submit':
                    if(hasSubmit == false){
                        _sFormData += encodeURIComponent(oName) + '=' + encodeURIComponent(oValue) + '&';
                        hasSubmit = true;
                    }
                    break;
                default:
                    _sFormData += encodeURIComponent(oName) + '=' + encodeURIComponent(oValue) + '&';
                    break;
            }
        }
    }
    
    
    _sFormData+="Event=ajax&Target="+target+"&Action="+action+"&WindowState="+windowState+"&CallType="+callType+extraParam;
    
       if(_sFormData.length<2000){
        if(!sendAjaxRequest(App_FullWebRoot+"?"+_sFormData, asynch, ajaxSubmitCallback)){
			doSubmitState2(target, action,windowState);
        }
    }else{
          if(!sendAjaxPostRequest(App_FullWebRoot,_sFormData, asynch, ajaxSubmitCallback)){
			 doSubmitState2(target, action,windowState);
        }
    }
}catch(err){
		alert(err.message);
	}
    
}




function fn_AjaxSubmitNoTargetParams(target, action, windowState,extraParam,callType, asynch){
    
    showLoadDiv(target);
    //alert("CALL 2");
    
    var params = "Event=ajax&Target="+target+"&Action="+action+"&WindowState="+windowState+"&CallType="+callType+extraParam;
    
    //alert(params.length);
    if(params.length<2000){
        //alert("using get");
        if(!sendAjaxRequest(App_FullWebRoot+"?"+params, asynch, ajaxSubmitCallback)){
            doSubmitState2(target, action,windowState);
        }
    }else{
        //alert("using post");
        if(!sendAjaxPostRequest(App_FullWebRoot,params, asynch, ajaxSubmitCallback)){
            doSubmitState2(target, action,windowState);
        }
    }
    
}


function doSubmitAjax(target, action){
    fn_AjaxSubmit(target, action, "","", "RefreshCaller", true);
}
function doRefreshAjax(target, action){
    fn_AjaxSubmit(target, action, "","", "RefreshAll", true);
}
function doSubmitModule(target, action){
    //fn_AjaxSubmit(target, action, "","", "RefreshCaller", true);
    doSubmitPage(target,action);
}
function doSubmitPane(target, action){
    fn_AjaxSubmit(target, action, "","", "RefreshPane", true);
}

function doSubmitAllModules(target, action){
    //fn_AjaxSubmit(target, action, "","", "RefreshAll", true);
    doSubmitPage(target,action);
}
/* Used by framework modules */
function ajax_doSubmit(target, action){
    fn_AjaxSubmit(target, action, "","", "RefreshAll", true);
    
}
function ajax_doSubmitAllModules(target, action){
    fn_AjaxSubmit(target, action, "","", "RefreshAll", true);
    
}
function ajax_doSubmitModule(target, action){
    fn_AjaxSubmit(target, action, "","", "RefreshCaller", true);
    
}
function ajax_doLinkSubmit(target, action){
    fn_AjaxSubmitNoTargetParams(target, action, "","", "RefreshAll", true);
    
}
function ajax_doLinkSubmitAllModules(target, action){
    fn_AjaxSubmitNoTargetParams(target, action, "","", "RefreshAll", true);
    
}
function ajax_doLinkSubmitModule(target, action){
    fn_AjaxSubmitNoTargetParams(target, action, "","", "RefreshCaller", true);
    
}

function doSubmitAllModules_NoTargetParams(target, action){
    fn_AjaxSubmitNoTargetParams(target, action, "","", "RefreshAll", true);
    //doSubmitPage(target,action);
}

function doRefreshContent(target, action){
    fn_AjaxSubmit(target, action,"","", "RefreshContent", true);
}

function doRefreshContentWithParam(target, action,paramName,paramValue){
    fn_AjaxSubmit(target, action,"","&"+paramName + "="+paramValue, "RefreshContent", true);
}
function doRefreshContentWithParam_NoTargetParams(target, action,paramName,paramValue){
    fn_AjaxSubmitNoTargetParams(target, action,"","&"+paramName + "="+paramValue, "RefreshContent", true);
}

function doRefreshPane(target, action,paramName,paramValue){
    fn_AjaxSubmit(target, action,"","&"+paramName + "="+paramValue, "RefreshPane", true);
}

function doRefreshPane_NoTargetParams(target, action,paramName,paramValue){
    fn_AjaxSubmitNoTargetParams(target, action,"","&"+paramName + "="+paramValue, "RefreshPane", true);
}

function callSubmitCallback(){
    if(req.readyState == 4){
        var resp = req.responseText;
		req = null;
        var myRegExp = /\<result\>\s*\<\!\[CDATA\[\s*([\d|\D]*)\s*\]\]\>\s*\<\/result\>/;
        var results = myRegExp.exec(resp);
        myRegExp = /\<error_message\>\s*\<\!\[CDATA\[\s*([\d|\D]*)\s*\]\]\>\s*\<\/error_message\>/
        var error = myRegExp.exec(resp);
        if(error){
            showAlert(error[1]);
        }else if(results){
			outerCallback(results[1]);
        }else{
            document.close();
            document.write(resp);
        }
        
    }//end if
}
function ajaxSubmitCallback(){
    if(req.readyState == 4){
        var resp = req.responseText; 
		req = null;
        var myRegExp = /\<module\>\s*\<id\>(\w+)\<\/id\>\s*\<content\>\s*\<\!\[CDATA\[\s*([\d|\D]*?)\s*\]\]\>\s*\<\/content\>\s*\<\/module\>/g;
        var results = myRegExp.exec(resp);
		 if(results){
            while(results){
                var divId = results[1];
				 hideLoadDiv(divId);
                var theDiv = document.getElementById(divId);
				 if(theDiv){
					theDiv.innerHTML=results[2];
                }
				results = myRegExp.exec(resp);
            }
        }else{
	    document.close();
            document.write(resp);
        }
        myRegExp = /\<error_message\>\s*\<\!\[CDATA\[\s*([\d|\D]*)\s*\]\]\>\s*\<\/error_message\>/
        results = myRegExp.exec(resp);
        if(results){
            showAlert(results[1]);
        }
        
    }//end if
}





function sendAjaxRequest(url, asynch, callback){
    req = false;
    try{
        if (window.XMLHttpRequest) {
            req = new XMLHttpRequest();
        }
        else if (window.ActiveXObject) {
            req = new ActiveXObject("Microsoft.XMLHTTP");
        }
        
    }catch(e){
        
        req = false;
    }
    if (req) {
        
        req.onreadystatechange = callback;
        req.open("GET", url, asynch);
        req.send(null);
        
        return true;
    }else{
        return false;
    }
}


function sendAjaxPostRequest(url,params, asynch, callback){
    // return false;
    
    req = false;
    try{			
        if (window.XMLHttpRequest) {
            req = new XMLHttpRequest();
        }
        else if (window.ActiveXObject) {
            req = new ActiveXObject("Microsoft.XMLHTTP");
        }
    }catch(e){
        req = false;
    }
    if (req) {		
        req.onreadystatechange = callback;
        req.open("POST", url, asynch);
        req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        req.send(params);
        
        return true;
    }else{
        return false;
    }
    
}
function doLoginSubmit(){
    var IE = (navigator.appName.indexOf("Microsoft") >= 0);
    var loginForm = document.loginForm;
    var key = new Date().getTime();
    var password = loginForm.UserPassword1.value;
    loginForm.UserPassword.value = MD5(password + key);
    loginForm.LoginKey.value = key;
    loginForm.UserPassword1.disabled = true;
    loginForm.submit();
}

function doEnterEvent(event,obj){
    try{
        var key = (event.keyCode || event.charCode);
        if(key==13){
            document.getElementsByName(obj)[0].click();
        }
    }catch(err){

    }
}

var helpObject = new Object();
var helpMessageObject = new Object();

function getImageURL(){
    try{
	if(document.getElementById("progressImageFile") !=window.undefined && document.getElementById("progressImageFile") !=null){
		return document.getElementById("progressImageFile").src;
	}else{
		return "./images/progressbar.gif";
	}
  }catch(err){
  return "./images/progressbar.gif";
}
}

function progressView(){
	try{
	var createloadingDiv = document.createElement("div");
      createloadingDiv.id="progressLoadingDivDataFrame";
	createloadingDiv.style.position="absolute";
	createloadingDiv.style.width="200px";
	var y = (screen.height/2);
	var x=(screen.width/2)-100;
	createloadingDiv.style.top=y+"px";
	createloadingDiv.style.left=x+"px";
	var formTable="<table cellspacing='0' cellpadding='0' width='100%' border='1' bgcolor='#eeeee0' style='border-collapse:collapse'>";
	formTable+="<tr><td align='center'>";
	formTable+="<table cellspacing='1' cellpadding='1' width='60%'>";
	formTable+="<tr><td><img src='"+getImageURL()+"'></img></td></tr>";
	formTable+="<tr><td align='center' style='font-Weight:bold'>Please Wait.........</td></tr>";
	formTable+="</td></tr>";
	formTable+="</table>";
	createloadingDiv.innerHTML=formTable;
	document.getElementsByTagName("body")[0].appendChild(createloadingDiv);
	}catch(e){
	alert(e.message);
	}
}

var helpObject = new Object();
var helpMessageObject = new Object();

function doRemoveHelp(){
    try{
    document.getElementsByTagName("body")[0].removeChild(document.getElementById("HelpDiv"));
    }catch(exception){
    alert(exception.message);
    }
}

function doHelpView(obj,e){
    try{
    if(document.getElementById("HelpDiv") !=window.undefined && document.getElementById("HelpDiv") !=null){
    doRemoveHelp()
    }
    var message = obj.id;
    var y = (e.clientY+20);
    var x = e.clientX;
    if(x > (screen.width -100)){
    x =(x-300);
    }
    var createdDiv = document.createElement("div");
    createdDiv.style.position="absolute";
    createdDiv.id="HelpDiv";
    createdDiv.style.top=y;
    createdDiv.style.left=x;
    createdDiv.zIndex=30;
    createdDiv.style.width="300px";
    var formatedTable ="<table cellspacing='0' cellpadding='0' width='100%'>";
    formatedTable+="<tr class='cpPartTitle'><td width='90%' style='font-size:8pt'>&nbsp;"+message.split("@_")[1]+" Usage</td><td width='10%' align='right'><img src='./images/klose.gif' title='Close Help' style='cursor:ponter' onclick='doRemoveHelp()'></img></td></tr>";
    formatedTable+="</table>";
    formatedTable+="<table cellspacing='1' cellpadding='1' width='100%' border='1' class='rptEditColumn' style='border-collapse:collapse;border:1px #375788 solid;padding: 2px 8px 2px 8px'>";
    formatedTable+="<tr><td>"+message.split("@_")[0]+"</td></tr>";
    formatedTable+="</table>";
    createdDiv.innerHTML=formatedTable;
    document.getElementsByTagName("body")[0].appendChild(createdDiv);
    }catch(exception){
    alert(exception.message );
    }

}
function showHelpMessage(key){
    try{
    var message="<fieldset><legend style='font-Weight:bold'>"+helpObject[key]+"</legend>";
    message+=helpMessageObject[key];
    message+="</fieldset>";
    }catch(exception){
    alert("Help Message Error =========="+exception.message +" exception type=========="+exception.type);
    }
    document.getElementById("helpMessage").innerHTML=message;

}

function getHelpModuleMenus(){
    var menu_Files="<tr><td>&nbsp;</td></tr>";
    try{
    var modules = modulesTitle.split("@");
    for(var i=0; i< modules.length; i++){
    if(modules[i].length >0){
    helpObject[i] = modules[i].split("_")[0];
    helpMessageObject[i] = modules[i].split("_")[1];
    menu_Files+="<tr onmouseOver=this.className='rowChange' onmouseOut=this.className='rptEditColumn'><td valign='middle' title='Click To View Message' style='cursor:pointer; font-Weight:bold' align='left' onclick=showHelpMessage('"+i+"') nowrap><ul type='square'><li>"+modules[i].split("_")[0]+"</li></ul></td></tr>";
    }
    }

    }catch(exception){}
    menu_Files+="<tr><td><br><br><br><br></td></tr>";
    return menu_Files;
}

function windowDisplayPage(){
    try{
    if(document.getElementById("HelpDiv") !=window.undefined && document.getElementById("HelpDiv") !=null){
    doRemoveHelp()
    }
    if(getHelpModuleMenus().indexOf("null") !=-1){
    return false;
    }
    var y = (screen.height/2)-270;
    var x = (screen.width/2)-150;
    var parentDiv = document.createElement("div");
    parentDiv.style.position="absolute";
    parentDiv.id="HelpDiv";
    parentDiv.style.top=y;
    parentDiv.style.left=x;
    parentDiv.zIndex=30;
    parentDiv.style.width="550px";
    var formatedTable ="<table cellspacing='0' cellpadding='0' width='100%'>";
    formatedTable+="<tr class='cpPartTitle'><td width='90%' style='font-size:8pt'>&nbsp;Module Help Info</td><td width='10%' align='right'><img src='./images/klose.gif' title='Close Help' style='cursor:ponter' onclick='doRemoveHelp()'></img></td></tr>";
    formatedTable+="</table>";
    formatedTable+="<table cellspacing='1' cellpadding='1' width='100%' border='1' class='rptEditColumn' style='border-collapse:collapse;border:1px #375788 solid;padding: 2px 8px 2px 8px;'>";
    formatedTable+="<tr><td width='30%' style='border:1px #375788 solid;padding: 2px 8px 2px 8px;'><table cellspacing='1' cellpadding='1' width='100%'>";
    formatedTable+=getHelpModuleMenus();
    formatedTable+="</table></td>";
    formatedTable+="<td width='70%' valign='top' align='center'>";
    formatedTable+="<br><table cellspacing='1' cellpadding='1' width='90%'>";
    formatedTable+="<tr><td id='helpMessage'>Click on the module name to display help message</td></tr>";
    formatedTable+="</table>";
    formatedTable+="</td></tr>";
    formatedTable+="</table>";
    parentDiv.innerHTML=formatedTable;
    document.getElementsByTagName("body")[0].appendChild(parentDiv);
    }catch(exception){

    }
}


function doHelpDisplayWindow(e){

    e =(e)?e:(window.event)?window.event:"";
    if(e.keyCode==112){
    if(navigator.userAgent.indexOf("Gecko") !=-1){
    e.preventDefault();
    }else{
    e.cancelBubble = true;
    e.returnValue = false;

    }
    windowDisplayPage();
    return false;
    }
    else if(e.keyCode==27){
        doRemoveHelp();
    }
}


function waitPreloadPage() { 
	hideLoadDiv(0);
}
//trim function for general used

String.prototype.trim = function(){
    var stringValue = this;
    stringValue = stringValue.replace( /^\s+/g, "" );
    stringValue = stringValue.replace( /\s+$/g, "" );
    return stringValue;
}
// End -->