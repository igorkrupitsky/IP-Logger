'To View IP History in browser http://localhost/IpLogger/Default.aspx?server=igor

'To Save IP
GetUrlData "http://localhost/IpLogger/Default.aspx?server=igor&save=1"

Function GetUrlData(sUrl)
	Dim oHttp
	'Set oHttp = CreateObject("Microsoft.XMLHTTP")
	Set oHttp = CreateObject("MSXML2.ServerXMLHTTP")
    oHttp.setTimeouts 0, 0, 0, 0
	
	oHttp.Open "GET", sUrl, False
	oHttp.send
	GetUrlData = oHttp.responseText
	Set oHttp = Nothing
End Function
