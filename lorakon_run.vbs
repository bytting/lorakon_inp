
function Execute(Dsc,Phase)	

	On Error Resume Next
	
    ' CREATE FILESYSTEM AND SCRIPTING OBJECTS
	set csh = CreateObject("WScript.Shell")
	set fso = CreateObject("Scripting.FileSystemObject")

    ' GET GENIE2K PATH FROM REGISTRY
	geniePath = csh.RegRead("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Canberra Industries, Inc.\Genie-2000 Environment\GENIE2K")

    ' CREATE ENVIRONMENT
	if not fso.FolderExists(geniePath & "Lorakon") then
		fso.CreateFolder(geniePath & "Lorakon")
	end if
    if not fso.FolderExists(geniePath & "Lorakon\System") then
		fso.CreateFolder(geniePath & "Lorakon\System")
	end if
  
	paramFile = geniePath & "Lorakon\System\input-params.txt"	

    ' CHECK IF DATA SOURCE IS A DETECTOR (NOT FILE)
	isDet = False
	If InStr(Dsc.Information(7), "DET:") = 1 Then
		isDet = True
	End If
	
    ' SKRIV DATA SOURCE VERDIER TIL INPUT FIL
	set f = fso.OpenTextFile(paramFile, 2, True)
	f.WriteLine Dsc.Parameter(CAM_T_SSPRSTR1) ' Lab
	f.WriteLine Dsc.Parameter(CAM_T_SCOLLNAME) ' Prøvetaker
	f.WriteLine Dsc.Parameter(CAM_T_STITLE) ' Prøvetittel
	f.WriteLine Dsc.Parameter(CAM_T_SUCSTRING1)	' Prøvetype
	f.WriteLine Dsc.Parameter(CAM_T_SUCSTRING2)	' Prøve komponent
	If isDet Then
		f.WriteLine ""
	Else
		f.WriteLine Dsc.Parameter(CAM_T_SIDENT) ' PrøveID
	End If
	f.WriteLine Dsc.Parameter(CAM_T_SUCSTRING3) ' Fylke/Kommune	
	f.WriteLine CStr(Dsc.Parameter(CAM_G_SGPSLATITUDE)) ' Lat
	f.WriteLine CStr(Dsc.Parameter(CAM_G_SGPSLONGITUD)) ' Lon
	f.WriteLine CStr(Dsc.Parameter(CAM_G_SGPSALTITUDE)) ' Alt
	f.WriteLine Dsc.Parameter(CAM_T_SUCSTRING10) ' Lokasjonstype	
	f.WriteLine Dsc.Parameter(CAM_T_SUCSTRING9) ' Lokasjon
	If isDet Then
		f.WriteLine ""
	Else
		f.WriteLine CStr(Dsc.Parameter(CAM_F_SQUANT)) ' Prøvemengde
	End If
	If isDet Then
		f.WriteLine ""
	Else
		f.WriteLine CStr(Dsc.Parameter(CAM_F_SQUANTERR)) ' Prøvemengde error
	End If
	If isDet Then
		f.WriteLine ""
	Else
		f.WriteLine Dsc.Parameter(CAM_T_SUNITS) ' Prøve Enhet
	End If
	f.WriteLine Dsc.Parameter(CAM_T_SGEOMTRY) ' Geometri
	f.WriteLine Dsc.Parameter(CAM_X_STIME) ' Referansedato
	f.WriteLine CStr(Dsc.Parameter(CAM_F_SSYSERR)) ' Syserr
	f.WriteLine CStr(Dsc.Parameter(CAM_F_SSYSTERR)) ' Systerr	
	If isDet Then
		f.WriteLine ""
	Else
		f.WriteLine Dsc.Parameter(CAM_T_SUCSTRING4) ' Kommentar	
	End If
	
	f.Close
	
    ' KJØR INPUT VINDU
	returnValue = csh.Run(geniePath & "exefiles\lorakon_inp.exe", 1, true)
	If returnValue <> 0 Then
		set fso = Nothing
		set csh = Nothing	
		Execute = 0		
		Exit Function
	End If

    ' SKRIV INPUT FIL VERDIER TIL DATA SOURCE
	set f = fso.OpenTextFile(paramFile, 1)
	idx = 0
	do until f.AtEndOfStream
		line = f.ReadLine
		
		select case idx
		case 0 ' LABORATORY
            Dsc.Parameter(CAM_T_SSPRSTR1) = line ' Lab
		case 1 ' OPERATØR
            Dsc.Parameter(CAM_T_SCOLLNAME) = line ' Prøvetaker
		case 2 ' PRØVETITTEL
            Dsc.Parameter(CAM_T_STITLE) = line ' Prøvetittel
		case 3 ' PRØVETYPE
            Dsc.Parameter(CAM_T_SUCSTRING1) = line ' Prøvetype
		case 4 ' PRØVE KOMPONENT
            Dsc.Parameter(CAM_T_SUCSTRING2) = line ' Prøve komponent
		case 5 ' PRØVE ID
            Dsc.Parameter(CAM_T_SIDENT) = line ' PrøveID
		case 6 ' KOMMUNE / FYLKE
            Dsc.Parameter(CAM_T_SUCSTRING3) = line ' Fylke/Kommune					        
		case 7 ' LATITUDE
            If line <> "" Then
                Dsc.Parameter(CAM_G_SGPSLATITUDE) = CDbl(line) ' Lat
			Else
				Dsc.Parameter(CAM_G_SGPSLATITUDE) = 0
            End If
		case 8 ' LONGITUDE
            If line <> "" Then
                Dsc.Parameter(CAM_G_SGPSLONGITUD) = CDbl(line) ' Lon
			Else
				Dsc.Parameter(CAM_G_SGPSLONGITUD) = 0
            End If
		case 9 ' ALTITUDE
            If line <> "" Then
                Dsc.Parameter(CAM_G_SGPSALTITUDE) = CDbl(line) ' Alt
			Else
				Dsc.Parameter(CAM_G_SGPSALTITUDE) = 0
            End If
		case 10 ' LOKASJONSTYPE
            Dsc.Parameter(CAM_T_SUCSTRING10) = line ' Lokasjonstype	
		case 11 ' LOKASJON
            Dsc.Parameter(CAM_T_SUCSTRING9) = line ' Lokasjon
		case 12 ' PRØVEMENGDE
            If line <> "" Then
                Dsc.Parameter(CAM_F_SQUANT) = CDbl(line) ' Prøvemengde
            End If
		case 13 ' PRØVEMENGDE ERROR
            If line <> "" Then
                Dsc.Parameter(CAM_F_SQUANTERR) = CDbl(line) ' Prøvemengde error
            End If
		case 14 ' PRØVEMENGDE ENHET
            Dsc.Parameter(CAM_T_SUNITS) = line ' Prøvemengde enhet
		case 15 ' GEOMETRI
            Dsc.Parameter(CAM_T_SGEOMTRY) = line ' Geometri
		case 16 ' REFERANSEDATO
            If line <> "" Then
                Dsc.Parameter(CAM_X_STIME) = CDate(line) ' Referansedato
            End If
		case 17	' RANDOM ERROR
            If line <> "" Then
                Dsc.Parameter(CAM_F_SSYSERR) = CDbl(line) ' Syserr
			Else
				Dsc.Parameter(CAM_F_SSYSERR) = 0	
            End If
		case 18	' SYSTEM ERROR
            If line <> "" Then
                Dsc.Parameter(CAM_F_SSYSTERR) = CDbl(line) ' Systerr
			Else
				Dsc.Parameter(CAM_F_SSYSTERR) = 0
            End If
		case 19 ' KOMMENTAR
			Dsc.Parameter(CAM_T_SUCSTRING4) = line ' Kommentar
		case else
			exit do
		end select
		idx = idx + 1
	loop
	f.Close
	
	Dsc.Parameter(CAM_T_SSPRSTR2) = "LORAKON"
	Dsc.Parameter(CAM_T_STYPE) = ""
	Dsc.Parameter(CAM_T_SLOCTN) = ""
	Dsc.Parameter(CAM_T_SDESC1)	= "LORAKON"
	Dsc.Parameter(CAM_T_SDESC2)	= ""
	Dsc.Parameter(CAM_T_SDESC3) = ""
	Dsc.Parameter(CAM_T_SDESC4) = ""
	
	set fso = Nothing
	set csh = Nothing	

	Execute = 0

end function

function Setup(Dsc,Phase)
	
	Setup = 0

end function

