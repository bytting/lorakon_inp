$SEC Header
$ETEMPLATE
"$FONT ['Consolas' 10]"
$rem "$FONT ['Courier New' 10]"
$rem "$FONTS[10]"
$REM "$ORIENTATION[LANDSCAPE]"
"$ALIGNMENT[CENTER]$FONTS[20]$FONTB[ON]$FONTU[ON]GAMMA SPECTRUM ANALYSIS$FONTU[OFF]$FONTB[OFF]$FONTS[10]$ALIGNMENT[LEFT]"
""
"Filename: |AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" #filename
"Report Generated On   : |DDDDDDDDD |TTTTTTTTTT" #datetime #datetime
""
"Laboratory            : |AAAAAAAAAAAAAAAA" SSPRSTR1
"Operator              : |AAAAAAAAAAAAAAAAAAAAAAAA" SCOLLNAME
""
"$ALIGNMENT[CENTER]$FONTS[14]$FONTB[ON]$FONTU[ON]SAMPLE INFORMATION$FONTU[OFF]$FONTB[OFF]$FONTS[10]$ALIGNMENT[LEFT]"
""
"Title                 : |AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" STITLE
"Identification        : |AAAAAAAAAAAAAAAA" SIDENT
"Type                  : |AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" SUCSTRING1
"Component             : |AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" SUCSTRING2
""
"Location Type         : |AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" SUCSTRING10
"Location              : |AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" SUCSTRING9
"Community / County    : |AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" SUCSTRING3
"Coordinates (WGS84)   : |FFFF.FFFFFF |FFFF.FFFFFF |FFFF.FFFFFF" SGPSLATITUDE SGPSLONGITUD SGPSALTITUDE
""
"Comment               : |AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" SUCSTRING4
""
"Size / Error          : |EEEEEEEEEE |EEEEEEEEEE |AAAAAAAAAAAAAAAA" SQUANT SQUANTERR SUNITS
"Geometry              : |AAAAAAAAAAAAAAAA" SGEOMTRY
""
"Taken On              : |DDDDDDDDD |TTTTTTTTTT" STIME STIME
"Acquisition Started   : |DDDDDDDDD |TTTTTTTTTT" ASTIME ASTIME
""
"Live Time             : |FFFFFFF.F seconds" ELIVE
"Real Time             : |FFFFFFF.F seconds" EREAL







$SEC BackgrSub
$ETEMPLATE
""
""
"$ALIGNMENT[CENTER]$FONTS[14]$FONTB[ON]$FONTU[ON]BACKGROUND SUBTRACT REPORT$FONTU[OFF]$FONTB[OFF]$FONTS[10]$ALIGNMENT[LEFT]"
$VP 0
$SETE #IV1 0
$IF PSFENBACK
	$SETE #IV1 1
$ENDIF
$IF PSFREAGENT
	$SETE #IV1 1
$ENDIF
$IF #IV1
	$IF RECCNT(PSCENTRD)
		""
		$IF PSFENBACK
			"Background File Used: |AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" EXPBACK
		$ENDIF
		$IF PSFREAGENT
			"Reagent Blank File: |AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" REAGENTFILE
		$ENDIF
		""
		"$TABDEF[8 150]"
		"$TABHD1 [' Peak '  ' Energy ' ' Original ' ' Area '  ' Ambient '   ' Backgr. ' ' Subtracted ' ' Subtracted ']"
		"$TABHD2 [' No. ' ' (keV) '    ' Area '   ' Uncert. ' ' Background ' ' Uncert. '  ' Area ' ' Uncert. ']"

		$SETE #IV1 1
		$SETE #IV5 16
		$SETE #SV99 ' '
		$SETE #IV2 RECCNT(PSORIGAREA)
		$REC 1 PSENERGY 1 0 #IV2
		$REC 2 PSORIGAREA 1 0 #IV2
		$REC 3 PSORIGERR 1 0 #IV2
		$REC 4 PSAMBBACK 1 0 #IV2
		$REC 5 PSDAMBBACK 1 0 #IV2
		$REC 6 PSAREA 1 0 #IV2
		$REC 7 PSDAREA 1 0 #IV2
		$REC 8 PSPPFIT 1 0 #IV2
		$REC 9 PSPMULT 1 0 #IV2
		$BT #IV2
		$IF #REC8(#IV1)
			$IF #REC9(#IV1)
				$SETE #SV1 ' M'
			$ELSE
				$SETE #SV1 'F '
			$ENDIF
		$ELSE
			$IF #REC9(#IV1)
				$SETE #SV1 ' m'
			$ELSE
				$SETE #SV1 '  '
			$ENDIF
		$ENDIF
		$IF PSPENBACK(#IV1,0)
			"$TABLN [ ' |A|II ' ' |FFFF.FF ' ' |EEEEEEEEE ' ' |FFF.FF ' ' |EEEEEEEEE ' ' |EEEEEEEEE ' ' |EEEEEEEEE ' ' |EEEEEEEEE ']" #SV1 #IV1 #REC1(#IV1) #REC2(#IV1) #REC3(#IV1)/EM #REC4(#IV1) #REC5(#IV1)/EM #REC6(#IV1) #REC7(#IV1)/EM
		$ELSE
			"$TABLN [ ' |A|II ' ' |FFFF.FF ' ' |EEEEEEEEE ' ' |FFF.FF '  '|A ' '|A '                      ' |EEEEEEEEE ' ' |EEEEEEEEE ']" #SV1 #IV1 #REC1(#IV1) #REC2(#IV1) #REC3(#IV1)/EM #SV99 #SV99 #REC6(#IV1) #REC7(#IV1)/EM
		$ENDIF
		$SETA #IV1 1
		$REM If new page print column headers.
		$SETA #IV5 1
		$SETE #IV6 #IV5
		$SETD #IV6 56
		$IF #IV6			
			$SETE #IV5 6			
		$ENDIF
		$ET
		"$TABEND"
		""		
		"        M = First peak in a multiplet region"
		"        m = Other peak in a multiplet region"
		"        F = Fitted singlet"
		""
		"        Errors quoted at |F.FFF sigma" 1.0/EM
	$ELSE
		"No peak analysis results available to perform background subtract on."
		" OR"
		"No peaks remain after background subtracted."
	$ENDIF
$ELSE
	"No background subtract performed on this spectrum."
$ENDIF







$SEC NID_Intf
$ETEMPLATE

$SETE #IV77 0
""
$IF NIDFNID
	"$ALIGNMENT[CENTER]$FONTS[14]$FONTB[ON]$FONTU[ON]NUCLIDE IDENTIFICATION REPORT$FONTU[OFF]$FONTB[OFF]$FONTS[10]$ALIGNMENT[LEFT]"
	""
	"Nuclide Library Used: |AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" EXPLIB
	""
	$SETE #SV3 ACTIVUNITS
	$SETE #FV1 ACTIVMULT
	$IFNOT #FV1
		$SETE #FV1 1.0
		$SETE #SV3 'uCi'
	$ENDIF
	$SETE #IV11 NIDFCSCDONE

	$SETE #SV98 ' '

	$IFNOT #IV11
		"$TABDEF [6]"
		"$TABHD1 [  'Nuclide'    'Id'       'Energy'    'Yield'     'Activity'     'Activity' ]"
		"$TABHD2 [   'Name'   'Confidence'  '(keV)'      '(%)'     '(|AA/|AAA)'   'Uncertainty' ]" #SV3 SUNITS
	$ELSE
		"$TABDEF [7]"
		"$TABHD1 [  'Nuclide'    'Id'       'Energy'    'Yield'     'Activity'     'Activity'    'Coinc']"
		"$TABHD2 [   'Name'    'Confidence'  '(keV)'      '(%)'     '(|AA/|AAA)'   'Uncertainty'  'Corr']" #SV3 SUNITS
	$ENDIF	

	$DEFL NLENERGY NLPEAK NLABUN NLACTVTY NLERR NLCOICF NLCOIAPP NLCOINOTI
	$SETE #IV1 1
	$SETE #IV5 14
	$SETE #IV8 RECCNT(NCLNAME)
	$SETE #FV2 #FV1
	$SETM #FV2 1.0/EM
	$REC 1 NCLNAME 1 0 #IV8
	$REC 2 NCLCONFID 1 0 #IV8
	$REC 3 NCLFIDENT 1 0 #IV8
	$REC 4 NCLFPDCORRDN 1 0 #IV8
	$BT #IV8
	$IF #REC3(#IV1)
		$SETE #IV2 0
		$SETE #IV4 1
		$SETE #IV9 ENTCNT(NCLLINE,#IV1)
		$TBL 1 NCLLINE #IV1 1 #IV9
		$SETE #IV3 #TBL1(1)
		$BT #IV9
		$GETL 2 #IV3 0
		$SETE #IV7 NLFNOUSEWTM(#IV3,1)
		$SETE #IV12 #LIS2(2)
		$SETA #IV12 #REC4(#IV1)		

		$IFNOT #IV2
			$IF #IV12
				$IFNOT #IV11
					"$TABLN [   '|A|AAAAAAA' '|F.FFF'  '|FFFF.FF|A|A''|FF.FF'  '|EEEEEEEEEEEE' '|EEEEEEEEEEEE']" #REC4(#IV1)/TF=!: #REC1(#IV1) #REC2(#IV1) #LIS2(1) #LIS2(2)/TF=*: #IV7/TF=@: #LIS2(3) #LIS2(4)/MU=#FV1 #LIS2(5)/MU=#FV2
				$ELSE
					$IF #LIS2(7)
						"$TABLN [   '  |AAAAAAA' '|F.FFF'  '|FFFF.FF|A|A''|FF.FF'  '|EEEEEEEEEEEE' '|EEEEEEEEEEEE' '|F.FFF' ]" #REC1(#IV1) #REC2(#IV1) #LIS2(1) #LIS2(2)/TF=*: #IV7/TF=@: #LIS2(3) #LIS2(4)/MU=#FV1 #LIS2(5)/MU=#FV2 #LIS2(6)
					$ELSE
						"$TABLN [   '  |AAAAAAA' '|F.FFF'  '|FFFF.FF|A|A''|FF.FF'  '|EEEEEEEEEEEE' '|EEEEEEEEEEEE' '|AAA'] " #REC1(#IV1) #REC2(#IV1) #LIS2(1) #LIS2(2)/TF=*: #IV7/TF=@: #LIS2(3) #LIS2(4)/MU=#FV1 #LIS2(5)/MU=#FV2 #LIS2(8)/TF=free:miss
					$ENDIF
				$ENDIF
			$ELSE
				"$TABLN [   '  |AAAAAAA' '|F.FFF'  '|FFFF.FF|A|A''|FF.FF' ]" #REC1(#IV1) #REC2(#IV1) #LIS2(1) #LIS2(2)/TF=*: #IV7/TF=@: #LIS2(3)
			$ENDIF
		$ELSE
			$IF #IV12
				$IFNOT #IV11
					"$TABLN [  '|A' '|A' '|FFFF.FF|A|A' '|FF.FF'  '|EEEEEEEEEEEE' '|EEEEEEEEEEEE']" #SV98 #SV98 #LIS2(1) #LIS2(2)/TF=*: #IV7/TF=@: #LIS2(3) #LIS2(4)/MU=#FV1 #LIS2(5)/MU=#FV2
				$ELSE
					$IF #LIS2(7)
						"$TABLN [  '|A' '|A' '|FFFF.FF|A|A' '|FF.FF'  '|EEEEEEEEEEEE' '|EEEEEEEEEEEE|F.FFF']" #SV98 #SV98 #LIS2(1) #LIS2(2)/TF=*: #IV7/TF=@: #LIS2(3) #LIS2(4)/MU=#FV1 #LIS2(5)/MU=#FV2 #LIS2(6)
					$ELSE
						"$TABLN [  '|A' '|A' '|FFFF.FF|A|A' '|FF.FF'  '|EEEEEEEEEEEE' '|EEEEEEEEEEEE' '|AAA']" #SV98 #SV98 #LIS2(1) #LIS2(2)/TF=*: #IV7/TF=@: #LIS2(3) #LIS2(4)/MU=#FV1 #LIS2(5)/MU=#FV2 #LIS2(8)/TF=free:miss
					$ENDIF
				$ENDIF
			$ELSE
				"$TABLN [  '|A' '|A'  '|FFFF.FF|A|A' '|FF.FF']" #SV98 #SV98 #LIS2(1) #LIS2(2)/TF=*: #IV7/TF=@: #LIS2(3)
			$ENDIF
		$ENDIF
		$SETA #IV5 1
		$SETE #IV2 1
		$SETA #IV4 1
		$SETE #IV3 #TBL1(#IV4)
		$REM If new page print column headers.
		$SETE #IV6 #IV5
		$SETD #IV6 56
		$IF #IV6			
			$SETE #IV5 5		
			$SETE #IV2 0
		$ENDIF
		$ET
	$ENDIF
	$SETA #IV1 1
	$ET
	"$TABEND"	
	""
	$DEFL TOLERANCE CONFID SIGMA PSDATE PEAKSTART PEAKEND
	$GETL 1 1 0
	"        * = Energy line found in the spectrum."
	"        @ = Energy line not used for Weighted Mean Activity"
	"        ! = Nuclide was corrected for parent/daughter"
	$IF USEVARETOL
		$SETE #FV3 VARTOLERANCE
		"        Energy Tolerance : |FFF.FFF FWHM" #FV3
	$ELSE
		$SETE #FV3 TOLERANCE
		$SETD #FV3 ECALCNV
		"        Energy Tolerance : |FFF.FFF |AA" #FV3 ECALUNITS
	$ENDIF
	"        Nuclide confidence index threshold = |FF.FF" #LIS1(2)
	"        Errors quoted at |F.FFF sigma" 1.0/EM
	$IF #IV11
		"        Coincidence correction performed."
		"        free = No coincidence correction required."
		"        miss = Nuclide energy was not found in the coincidence library."
	$ENDIF
	""
	$REM $ENP
$ENDIF

$IF NIDFNID
	$IF RECCNT(PSCENTRD)
		$REM Determine if new page should be started for unidentified peaks.
		$SETE #IV1 1
		$SETE #IV2 0
		$BT RECCNT(PSORIGAREA)
		$IFNOT PSPKNOWN(#IV1,0)
			$SETA #IV2 1
		$ENDIF
		$ET
		$SETE #IV6 #IV5
		$SETA #IV6 #IV2
		$SETA #IV6 22
		$SETD #IV6 56
		$IF #IV6
			$NP
			$SETE #IV5 7
		$ENDIF
		$REM End check page.
		""
		"$ALIGNMENT[CENTER]$FONTS[14]$FONTB[ON]$FONTU[ON]UNIDENTIFIED PEAKS$FONTU[OFF]$FONTB[OFF]$FONTS[10]$ALIGNMENT[LEFT]"
		""
		"Peak Locate Channels: |IIII - |IIII" #LIS1(5) #LIS1(6)
		""
		"$TABDEF [4]"
		"$TABHD1 [ ' Peak'   ' Energy ' ' Peak Size in '    ' Peak CPS' ]"
		"$TABHD2 [ ' No.'     ' (keV)'  ' Counts per Second' ' % Uncertainty' ]"

		$SETE #IV1 1
		$SETE #IV7 0
		$BT RECCNT(PSORIGAREA)
		$GETR #PM #IV1
		$IF #PM15
		  $IF #PM17
			$SETE #SV2 ' M'
		  $ELSE
			$SETE #SV2 'F '
		  $ENDIF
		$ELSE
			$IF #PM17
				$SETE #SV2 ' m'
			$ELSE
				$SETE #SV2 '  '
			$ENDIF
		$ENDIF
		$IF #PM16
			$IFNOT PSPKNOWN(#IV1,0)
				$SETA #IV7 1
				"$TABLN  [   '|A|II' '|FFFF.FF'            '|EEEEEEEEEEE'        '|FFF.FF']" #SV2 #IV1 #PM1 #PM11 #PM12/EM
				$SETA #IV5 1
			$ENDIF
		$ENDIF
		$SETA #IV1 1
		$REM If new page print column headers.
		$SETE #IV6 #IV5
		$SETD #IV6 56
		$IF #IV6	
			$SETE #IV5 5		
		$ENDIF
		$ET
		"$TABEND"
		$IF #IV7
			""
			"        M = First peak in a multiplet region"
			"        m = Other peak in a multiplet region"
			"        F = Fitted singlet"
			""
			"        Errors quoted at |F.FFF sigma" 1.0/EM
		$ELSE
			"        All peaks were identified."
		$ENDIF
		$REM $ENP
	$ELSE
		"No peak search results available for nuclide analysis."
	$ENDIF
$ELSE
	"No nuclide identification results available for reporting purposes"
$ENDIF






$IF NIDFINTERF
	""	
	"$ALIGNMENT[CENTER]$FONTS[14]$FONTB[ON]$FONTU[ON]INTERFERENCE CORRECTED REPORT$FONTU[OFF]$FONTB[OFF]$FONTS[10]$ALIGNMENT[LEFT]"
	$IF NIDFPDCDONE		
		"$ALIGNMENT[CENTER]$FONTS[14]$FONTB[ON]$FONTU[ON]WITH PARENT/DAUGHTER CORRECTION$FONTU[OFF]$FONTB[OFF]$FONTS[10]$ALIGNMENT[LEFT]"
	$ENDIF	
	""
	""
	"$TABDEF [4 350 400]"	
	"$TABHD1 [ ' Nuclide' '    Nuclide'     '     Wt mean'          '      Wt mean' ]"
	"$TABHD2 [ '  Name  ' ' Id Confidence'  ' Activity (|AA/|AAA)'   ' Activity Uncertainty' ]" #SV3 SUNITS
	""
	$SETE #IV1 1
	$SETE #IV5 13
	$SETE #IV9 RECCNT(NCLNAME)
	$REC 1 NCLNAME 1 0 #IV9
	$REC 2 NCLCONFID 1 0 #IV9
	$REC 3 NCLWTMEAN 1 0 #IV9
	$REC 4 NCLWTMERR 1 0 #IV9
	$REC 5 NCLFINTFREJ 1 0 #IV9
	$REC 6 NCLFIDENT 1 0 #IV9
	$REC 7 NCLFPDCORRDN 1 0 #IV9
	$BT #IV9
	$SETE #IV7 0
	$SETE #IV4 ENTCNT(NCLLINE,#IV1)
	$TBL 1 NCLLINE #IV1 1 #IV4
	$SETE #IV10 #REC6(#IV1)
	$SETA #IV10 #REC5(#IV1)
	$SETE #IV2 1
	$BT #IV4
	$SETE #IV3 #TBL1(#IV2)
	$SETA #IV7 NLFNOUSEWTM(#IV3,1)
	$SETA #IV2 1
	$ET
	$IF #IV10				
		$IFNOT #REC5(#IV1)
			"$TABLN [  '|A|A |AAAAAAA|A' '|F.FFF'     '|EEEEEEEEEEEEE'  '|EEEEEEEEEEEEE' ]" #REC7(#IV1)/TF=!: NCLFUNRESINT(#IV1,0)/TF=?: #REC1(#IV1) #IV7/TF=@: #REC2(#IV1) #REC3(#IV1)/MU=#FV1 #REC4(#IV1)/MU=#FV2
		$ELSE			
			"$TABLN [  '|AX |AAAAAAA'  '|F.FFF' ]" #REC7(#IV1)/TF=!: #REC1(#IV1) #REC2(#IV1)
		$ENDIF
		$SETA #IV5 1
	$ENDIF
	$SETA #IV1 1
	$REM If new page print column headers.
	$SETE #IV6 #IV5
	$SETD #IV6 56
	$IF #IV6		
		$SETE #IV5 6		
	$ENDIF
	$ET
	"$TABEND"
	""
	$IF NIDFPDCDONE
		"        ! = Nuclide was corrected for parent/daughter"
	$ENDIF
	"        ? = nuclide is part of an undetermined solution"	
	"        X = nuclide rejected by the interference analysis"	
	"        @ = nuclide contains energy lines not used in Weighted Mean Activity"
	""
	"        Errors quoted at |F.FFF sigma" 1.0/EM
	""	
$ENDIF

$IF NIDFNID
	$IFNOT NIDFINTERF
		"No interference correction results available for reporting purposes."
	$ENDIF
$ENDIF






$SEC MDA
$ETEMPLATE

$IF NIDFMDA
	"$ALIGNMENT[CENTER]$FONTS[14]$FONTB[ON]$FONTU[ON]NUCLIDE MDA REPORT$FONTU[OFF]$FONTB[OFF]$FONTS[10]$ALIGNMENT[LEFT]"
	""
	$DEFL EXPLIB
	$GETL 1 1 0
	"Nuclide Library Used: |AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" #LIS1(1)	
	$SETE #SV3 ACTIVUNITS
	$SETE #FV1 ACTIVMULT
	$IFNOT #FV1
	$SETE #FV1 1.0
	$SETE #SV3 'uCi'
$ENDIF
$SETE #IV11 NIDFCSCDONE
""
$IFNOT #IV11
	"$TABDEF [6 350 225 175]"
	"$TABHD1 [' Nuclide'    ' Energy'    ' Yield'      ' Line MDA'    ' Nuclide MDA'    ' Activity']"
	"$TABHD2 [' Name'       ' (keV)'      ' (%)'      ' (|AA/|AAA)'   ' (|AA/|AAA)'    ' (|AA/|AAA)']" #SV3 SUNITS #SV3 SUNITS #SV3 SUNITS
$ELSE
	"$TABDEF [7]"
	"$FONTS [10]"
	"$TABHD1 [' Nuclide'   ' Energy'   ' Yield'  ' Line MDA'    ' Nuclide MDA'   ' Activity'   ' Coinc' ]"
	"$TABHD2 [' Name'      ' (keV)'     ' (%)'     ' (|AA/|AAA)'   ' (|AA/|AAA)'   ' (|AA/|AAA)'  ' Corr' ]" #SV3 SUNITS #SV3 SUNITS #SV3 SUNITS
$ENDIF
""
$DEFL NLMDA NLENERGY NLPEAK NLABUN NLACTVTY NLCOICF NLCOIAPP NLCOINOTI
$SETE #IV1 1
$SETE #IV5 14
$SETE #IV9 RECCNT(NCLNAME)
$REC 1 NCLNAME 1 0 #IV9
$REC 2 NCLFIDENT 1 0 #IV9
$REC 3 NCLFSHORTHL 1 0 #IV9
$REC 4 NCLFNORPTMDA 1 0 #IV9
$REC 5 NCLMDA 1 0 #IV9
$REC 6 NCLFPDCORRDN 1 0 #IV9

$BT #IV9
$IFNOT #REC4(#IV1)
	$SETE #IV2 0
	$SETE #IV4 1
	$SETE #IV8 ENTCNT(NCLLINE,#IV1)
	$TBL 1 NCLLINE #IV1 1 #IV8
	$SETE #IV3 #TBL1(1)
	$BT #IV8
	$GETL 2 #IV3 0
	$IFNOT #IV2
		$IFNOT #IV11
			"$TABLN [    '|A|A|A|A|AAAAAAA'  '|FFFF.FF|A' '|FF.FF'   '|EEEEEEEEEEE'  '|EEEEEEEEE'   '|EEEEEEEEEEE']" #REC6(#IV1)/TF=!:  #REC2(#IV1)/TF=+: #LIS2(1)/TF=:> #REC3(#IV1)/TF=@: #REC1(#IV1) #LIS2(2) #LIS2(3)/TF=*: #LIS2(4) #LIS2(1)/MU=#FV1 #REC5(#IV1)/MU=#FV1 #LIS2(5)/MU=#FV1
		$ELSE
			$IF #LIS2(7)
				"$TABLN [	'|A|A|A|AAAAAAA' '|FFFF.FF|A' '|FF.FF'  '|EEEEEEEEEEE'  '|EEEEEEEEE'  '|EEEEEEEEEEE' '|F.FFF']" #REC2(#IV1)/TF=+: #LIS2(1)/TF=:> #REC3(#IV1)/TF=@: #REC1(#IV1) #LIS2(2) #LIS2(3)/TF=*: #LIS2(4) #LIS2(1)/MU=#FV1 #REC5(#IV1)/MU=#FV1 #LIS2(5)/MU=#FV1 #LIS2(6)
			$ELSE
				"$TABLN [ '|A|A|A|AAAAAAA' '|FFFF.FF|A' '|FF.FF'  '|EEEEEEEEEEE'  '|EEEEEEEEE'  '|EEEEEEEEEEE' '|AAA']" #REC2(#IV1)/TF=+: #LIS2(1)/TF=:> #REC3(#IV1)/TF=@: #REC1(#IV1) #LIS2(2) #LIS2(3)/TF=*: #LIS2(4) #LIS2(1)/MU=#FV1 #REC5(#IV1)/MU=#FV1 #LIS2(5)/MU=#FV1 #LIS2(8)/TF=free:miss
			$ENDIF
		$ENDIF
		$SETE #IV2 1
		$ELSE
			$REM Not first line.
			$IFNOT #IV11
				"$TABLN [    '|A|A'          '|FFFF.FF|A' '|FF.FF'   '|EEEEEEEEEEE'  ' '            '|EEEEEEEEEEE']" #LIS2(1)/TF=:> #REC3(#IV1)/TF=@: #LIS2(2) #LIS2(3)/TF=*: #LIS2(4) #LIS2(1)/MU=#FV1 #LIS2(5)/MU=#FV1
			$ELSE
				$IF #LIS2(7)
					"$TABLN [   '|A|A'         '|FFFF.FF|A' '|FF.FF'  '|EEEEEEEEEEE'     '  '       '|EEEEEEEEEEE' '|F.FFF']" #LIS2(1)/TF=:> #REC3(#IV1)/TF=@: #LIS2(2) #LIS2(3)/TF=*: #LIS2(4) #LIS2(1)/MU=#FV1 #LIS2(5)/MU=#FV1 #LIS2(6)
				$ELSE
					"$TABLN [    '|A|A'         '|FFFF.FF|A' '|FF.FF'  '|EEEEEEEEEEE'    '   '       '|EEEEEEEEEEE' '|AAA' ]" #LIS2(1)/TF=:> #REC3(#IV1)/TF=@: #LIS2(2) #LIS2(3)/TF=*: #LIS2(4) #LIS2(1)/MU=#FV1 #LIS2(5)/MU=#FV1 #LIS2(8)/TF=free:miss
				$ENDIF
			$ENDIF
		$ENDIF
		$SETA #IV4 1
		$SETE #IV3 #TBL1(#IV4)
		$REM If new page print column headers.
		$SETA #IV5 1
		$SETE #IV6 #IV5
		$SETD #IV6 56
		$IF #IV6
			$REM $NP
			$SETE #IV5 5
			$SETE #IV2 0
		$ENDIF
		$ET
	$ENDIF
	$SETA #IV1 1
	$ET
	"$TABEND"
	""
	$IF NIDFPDCDONE
		"       ! = Nuclide was corrected for parent/daughter"
	$ENDIF
	"        + = Nuclide identified during the nuclide identification"
	"        * = Energy line found in the spectrum"
	"        > = MDA value not calculated"
	"        @ = Half-life too short to be able to perform the decay correction"
	$IF #IV11
		"        Coincidence correction performed."
		"        free = No coincidence correction required."
		"        miss = Nuclide energy was not found in the coincidence library."
	$ENDIF
$ENDIF
$IFNOT NIDFMDA
	"No MDA analysis results available for reporting purposes"
$ENDIF
