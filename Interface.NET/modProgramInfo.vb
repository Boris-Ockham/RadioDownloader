Option Strict Off
Option Explicit On
Module modProgramInfo
	
	Public Sub ListStation(ByRef strStationId As String, ByRef lstAddTo As AxComctlLib.AxListView)
		lstAddTo.ListItems.Clear()
		
		Dim strStationPage As String
		Dim lngTrim As Integer
		
		strStationPage = GetUrlAsString("http://www.bbc.co.uk/radio/aod/networks/" & strStationId & "/audiolist.shtml")
		' Cut off the 'highlights' from the top of the page to stop repitition
		lngTrim = InStr(1, strStationPage, "<div id=""az"">")
		strStationPage = Mid(strStationPage, lngTrim)
		
		Dim objRegExp As VBScript_RegExp_55.RegExp
		Dim objMatch As VBScript_RegExp_55.Match
		Dim colMatches As VBScript_RegExp_55.MatchCollection
		
		objRegExp = New VBScript_RegExp_55.RegExp
		objRegExp.Pattern = "<a href=""aod\.shtml\?(.*?)"" target=""bbcplayer""( class=""txday""|)>(.*?)</a>"
		objRegExp.IgnoreCase = True
		objRegExp.Global = True
		
		If objRegExp.Test(strStationPage) = False Then
			Exit Sub
		End If
		
		colMatches = objRegExp.Execute(strStationPage)
		
		Dim strThisName As String
		Dim strLastName As String
		Dim booLastWasNamed As Boolean
		Dim strDay As String
		
		Dim lstAddItem As ComctlLib.ListItem
		For	Each objMatch In colMatches
			Select Case objMatch.SubMatches(2)
				Case "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN"
					strThisName = strLastName
					'UPGRADE_WARNING: Couldn't resolve default property of object objMatch.SubMatches(). Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					strDay = objMatch.SubMatches(2)
					
					If booLastWasNamed Then
						booLastWasNamed = False
						Call lstAddTo.ListItems.Remove(lstAddTo.ListItems.Count)
					End If
				Case Else
					'UPGRADE_WARNING: Couldn't resolve default property of object objMatch.SubMatches(). Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					strThisName = objMatch.SubMatches(2)
					strDay = ""
					strLastName = strThisName
					booLastWasNamed = True
			End Select
			
			lstAddItem = lstAddTo.ListItems.Add
			
			If strDay <> "" Then
				strDay = " (" & StrConv(strDay, VbStrConv.ProperCase) & ")"
			End If
			
			lstAddItem.Text = Replace(strThisName, "&amp;", "&") & strDay
			lstAddItem.SmallIcon = 5
			'UPGRADE_WARNING: Couldn't resolve default property of object objMatch.SubMatches(). Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lstAddItem.Tag = "BBCLA" & "||" + objMatch.SubMatches(0)
		Next objMatch
	End Sub
End Module