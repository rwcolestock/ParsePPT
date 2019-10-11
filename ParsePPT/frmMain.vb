Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Presentation
Imports System.IO
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.Windows.Forms

Public Class frmMain
    Private objSelectPresentation As New usrSelectPresentation
    Private objReadSlides As New usrReadSlides
    Private dblSlideCount As Double = 0
    Private dblSlideWithTaxabilityTableCount As Double = 0
    Private dblOutputRowCount As Double = 0
    Private dblOutputRowsToReviewCount As Double = 0

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Dim intVerify As Integer = 0
        intVerify = MsgBox("Are you sure you want to quit?", vbYesNo, "Verify Cancel")
        If intVerify = 6 Then End

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblStepNumber.Text = "Step 1"
        lblStepText.Text = "Select the Presentation to read and then click the 'Next' button."
        panelMain.Controls.Add(objSelectPresentation)
        objSelectPresentation.Visible = True
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        If lblStepNumber.Text.Equals("Step 1") = True Then
            If objSelectPresentation.txtPresentation.Text.Trim.Equals("") = True Then
                MsgBox("You need to select a Presentation.", vbOKOnly, "Oops!")
            Else
                If Dir(objSelectPresentation.txtPresentation.Text).Equals("") = True Then
                    MsgBox("You need to select a valid Presentation.", vbOKOnly, "Oops!")
                Else
                    Using presentationDocument As PresentationDocument = PresentationDocument.Open(objSelectPresentation.txtPresentation.Text, False)
                        dblSlideCount = presentationDocument.PresentationPart.SlideParts.Count
                    End Using
                    If dblSlideCount = 0 Then
                        MsgBox("You need to select a Presentation that contains slides.", vbOKOnly, "Oops!")
                    Else

                        btnCancel.Enabled = False
                        btnNext.Enabled = False
                        Me.Cursor = Cursors.WaitCursor

                        lblStepNumber.Text = "Step 2"
                        lblStepText.Text = "Reading the slides..."
                        panelMain.Controls.Add(objReadSlides)
                        objReadSlides.Visible = True
                        objSelectPresentation.Visible = False
                        objReadSlides.panelSlideContents.Controls.Clear()

                        ' Open the output spreadsheet
                        Dim strOutputXLSX As String = objSelectPresentation.txtPresentation.Text.Replace(".pptx", ".xlsx")
                        If File.Exists(strOutputXLSX) Then
                            File.Delete(strOutputXLSX)
                        End If

                        Dim fileOutput = New System.IO.FileInfo(strOutputXLSX)
                        Using package = New ExcelPackage(fileOutput)

                            Dim aryStateIssues As New ArrayList

                            Dim worksheetParseSummary As ExcelWorksheet = package.Workbook.Worksheets.Add("Parse Summary")
                            worksheetParseSummary.Cells(1, 1).Value = "Source Spreadsheet"
                            worksheetParseSummary.Cells(2, 1).Value = "Total Number of Slides"
                            worksheetParseSummary.Cells(3, 1).Value = "Slides with Taxability Table"
                            worksheetParseSummary.Cells(4, 1).Value = "Total Number of Output Rows"
                            worksheetParseSummary.Cells(5, 1).Value = "Number of Output Rows to Review"
                            worksheetParseSummary.Cells(1, 2).Value = objSelectPresentation.txtPresentation.Text
                            worksheetParseSummary.Cells(2, 2).Value = dblSlideCount
                            worksheetParseSummary.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left

                            Dim worksheetTaxability As ExcelWorksheet = package.Workbook.Worksheets.Add("Taxability")
                            worksheetTaxability.Cells(1, 1).Value = "State"
                            worksheetTaxability.Cells(1, 2).Value = "High Level Topic"
                            worksheetTaxability.Cells(1, 3).Value = "Specific Issue"

                            dblSlideWithTaxabilityTableCount = 0
                            dblOutputRowCount = 0
                            dblOutputRowsToReviewCount = 0

                            Using presentationDocument As PresentationDocument = PresentationDocument.Open(objSelectPresentation.txtPresentation.Text, False)
                                Dim dblCount As Double = 0
                                For dblCount = 1 To dblSlideCount
                                    Dim presentationPart As PresentationPart = presentationDocument.PresentationPart
                                    Dim presentation As Presentation = presentationPart.Presentation
                                    Dim slideIds = presentation.SlideIdList.ChildElements
                                    Dim slidePartRelationshipId As String = (TryCast(slideIds(dblCount - 1), SlideId)).RelationshipId
                                    Dim slidePart As SlidePart = CType(presentationPart.GetPartById(slidePartRelationshipId), SlidePart)
                                    ' See if there is a table with State and Issues 
                                    Dim strXML As String = slidePart.Slide.InnerXml.ToString
                                    If InStr(UCase(strXML), "<A:T>STATE</A:T>") <> 0 Then
                                        If InStr(UCase(strXML), "<A:T>ISSUES</A:T>") <> 0 Then
                                            If InStr(UCase(strXML), "<A:RPR LANG=""EN-US"" DIRTY=""0"" /><A:T>") <> 0 Then
                                                dblSlideWithTaxabilityTableCount = dblSlideWithTaxabilityTableCount + 1
                                                Dim strContent As String = ""
                                                Dim strTitle As String = ""
                                                Dim dblParagraphCount As Double = 0
                                                Dim strEveryOther As String = "State"
                                                Dim strStates As String = ""
                                                For Each titleParagraph In slidePart.Slide.Descendants(Of DocumentFormat.OpenXml.Drawing.Paragraph)()
                                                    If strTitle.Equals("") = True Then strTitle = titleParagraph.InnerText
                                                Next
                                                For Each paragraph In slidePart.Slide.Descendants(Of DocumentFormat.OpenXml.Drawing.TableCell)()
                                                    Application.DoEvents()
                                                    dblParagraphCount = dblParagraphCount + 1
                                                    If dblParagraphCount > 2 Then
                                                        strContent = Trim(paragraph.InnerText)
                                                        If strEveryOther.Equals("State") Then
                                                            strStates = strContent
                                                        Else
                                                            If strContent.Trim.Equals("") = False Then
                                                                Dim aryStates() As String = strStates.Split(",")
                                                                For Each strStateAbbreviation In aryStates
                                                                    Dim objStateIssue As New usrStateIssue
                                                                    strStateAbbreviation = Trim(UCase(StateNameToAbbreviation(strStateAbbreviation)))
                                                                    objStateIssue.strState = strStateAbbreviation
                                                                    objStateIssue.strIssues = strContent
                                                                    objStateIssue.strHighLevelTopic = strTitle
                                                                    Dim objSlideContent As New usrSlideContent
                                                                    objSlideContent.txtSlideNumber.Text = dblCount.ToString
                                                                    objSlideContent.txtHighLevelTopic.Text = strTitle
                                                                    objSlideContent.txtState.Text = strStateAbbreviation
                                                                    If objStateIssue.strState.Length <> 2 Then
                                                                        objStateIssue.blnReview = True
                                                                        dblOutputRowsToReviewCount = dblOutputRowsToReviewCount + 1
                                                                        objSlideContent.BackColor = System.Drawing.Color.LightSalmon
                                                                    End If
                                                                    objReadSlides.panelSlideContents.Controls.Add(objSlideContent)
                                                                    aryStateIssues.Add(objStateIssue)
                                                                    objReadSlides.Refresh()
                                                                    Application.DoEvents()
                                                                    objSlideContent = Nothing
                                                                    objStateIssue = Nothing
                                                                Next
                                                            End If
                                                        End If
                                                        If strEveryOther.Equals("State") Then strEveryOther = "Issues" Else strEveryOther = "State"
                                                    End If
                                                Next
                                            End If
                                        End If
                                    End If
                                Next
                            End Using

                            Dim dblOutputCount As Double = 0
                            For dblOutputCount = 1 To aryStateIssues.Count
                                Dim objStateIssue As usrStateIssue = aryStateIssues(dblOutputCount - 1)
                                worksheetTaxability.Cells(dblOutputCount + 1, 1).Value = objStateIssue.strState
                                worksheetTaxability.Cells(dblOutputCount + 1, 2).Value = objStateIssue.strHighLevelTopic
                                worksheetTaxability.Cells(dblOutputCount + 1, 3).Value = objStateIssue.strIssues
                                If objStateIssue.blnReview = True Then
                                    worksheetTaxability.Cells(dblOutputCount + 1, 1).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                                    worksheetTaxability.Cells(dblOutputCount + 1, 1).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSalmon)
                                End If

                                dblOutputRowCount = dblOutputRowCount + 1
                                objStateIssue = Nothing
                            Next

                            worksheetTaxability.Cells("A1:C1").AutoFilter = True
                            For colLength As Integer = 1 To 3
                                worksheetTaxability.Column(colLength).AutoFit()
                            Next
                            worksheetTaxability.View.FreezePanes(2, 1)
                            worksheetTaxability.Select("A2")
                            worksheetParseSummary.Cells(3, 2).Value = dblSlideWithTaxabilityTableCount
                            worksheetParseSummary.Cells(4, 2).Value = dblOutputRowCount
                            worksheetParseSummary.Cells(5, 2).Value = dblOutputRowsToReviewCount
                            For colLength As Integer = 1 To 2
                                worksheetParseSummary.Column(colLength).AutoFit()
                            Next
                            If dblOutputRowsToReviewCount = 0 Then
                                worksheetParseSummary.Select("B1")
                            Else
                                worksheetParseSummary.Select("B5")
                                worksheetParseSummary.Cells(5, 2).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                                worksheetParseSummary.Cells(5, 2).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSalmon)
                            End If

                            package.Save()
                        End Using
                        fileOutput = Nothing

                        btnCancel.Enabled = True
                        Me.Cursor = Cursors.Default
                        lblStepNumber.Text = ""

                        Dim strOutputText As String = "Process Complete."
                        If dblOutputRowsToReviewCount <> 0 Then
                            strOutputText = strOutputText + "  " + CStr(dblOutputRowsToReviewCount) + " Rows to Review."
                        End If
                        lblStepText.Text = strOutputText

                        MsgBox(strOutputText, vbOKOnly, "Complete!")

                    End If
                End If
            End If

        End If

    End Sub
    Function StateNameToAbbreviation(strStateName As String) As String
        Dim strStateAbbreviation As String = ""
        Dim strTempStateName As String = strStateName
        strStateName = Trim(UCase(strStateName))
        If strStateName = "ALABAMA" Then
            strStateAbbreviation = "AL"
        ElseIf strStateName = "ALASKA" Then
            strStateAbbreviation = "AK"
        ElseIf strStateName = "ARIZONA" Then
            strStateAbbreviation = "AZ"
        ElseIf strStateName = "ARKANSAS" Then
            strStateAbbreviation = "AR"
        ElseIf strStateName = "CALIFORNIA" Then
            strStateAbbreviation = "CA"
        ElseIf strStateName = "COLORADO" Then
            strStateAbbreviation = "CO"
        ElseIf strStateName = "CONNECTICUT" Then
            strStateAbbreviation = "CT"
        ElseIf strStateName = "DELAWARE" Then
            strStateAbbreviation = "DE"
        ElseIf strStateName = "DISTRICT OF COLUMBIA" Then
            strStateAbbreviation = "DC"
        ElseIf strStateName = "FLORIDA" Then
            strStateAbbreviation = "FL"
        ElseIf strStateName = "GEORGIA" Then
            strStateAbbreviation = "GA"
        ElseIf strStateName = "HAWAII" Then
            strStateAbbreviation = "HI"
        ElseIf strStateName = "IDAHO" Then
            strStateAbbreviation = "ID"
        ElseIf strStateName = "ILLINOIS" Then
            strStateAbbreviation = "IL"
        ElseIf strStateName = "INDIANA" Then
            strStateAbbreviation = "IN"
        ElseIf strStateName = "IOWA" Then
            strStateAbbreviation = "IA"
        ElseIf strStateName = "KANSAS" Then
            strStateAbbreviation = "KS"
        ElseIf strStateName = "KENTUCKY" Then
            strStateAbbreviation = "KY"
        ElseIf strStateName = "LOUISIANA" Then
            strStateAbbreviation = "LA"
        ElseIf strStateName = "MAINE" Then
            strStateAbbreviation = "ME"
        ElseIf strStateName = "MARYLAND" Then
            strStateAbbreviation = "MD"
        ElseIf strStateName = "MASSACHUSETTS" Then
            strStateAbbreviation = "MA"
        ElseIf strStateName = "MICHIGAN" Then
            strStateAbbreviation = "MI"
        ElseIf strStateName = "MINNESOTA" Then
            strStateAbbreviation = "MN"
        ElseIf strStateName = "MISSISSIPPI" Then
            strStateAbbreviation = "MS"
        ElseIf strStateName = "MISSOURI" Then
            strStateAbbreviation = "MO"
        ElseIf strStateName = "MONTANA" Then
            strStateAbbreviation = "MT"
        ElseIf strStateName = "NEBRASKA" Then
            strStateAbbreviation = "NE"
        ElseIf strStateName = "NEVADA" Then
            strStateAbbreviation = "NV"
        ElseIf strStateName = "NEW HAMPSHIRE" Then
            strStateAbbreviation = "NH"
        ElseIf strStateName = "NEW JERSEY" Then
            strStateAbbreviation = "NJ"
        ElseIf strStateName = "NEW MEXICO" Then
            strStateAbbreviation = "NM"
        ElseIf strStateName = "NEW YORK" Then
            strStateAbbreviation = "NY"
        ElseIf strStateName = "NORTH CAROLINA" Then
            strStateAbbreviation = "NC"
        ElseIf strStateName = "NORTH DAKOTA" Then
            strStateAbbreviation = "ND"
        ElseIf strStateName = "OHIO" Then
            strStateAbbreviation = "OH"
        ElseIf strStateName = "OKLAHOMA" Then
            strStateAbbreviation = "OK"
        ElseIf strStateName = "OREGON" Then
            strStateAbbreviation = "OR"
        ElseIf strStateName = "PENNSYLVANIA" Then
            strStateAbbreviation = "PA"
        ElseIf strStateName = "RHODE ISLAND" Then
            strStateAbbreviation = "RI"
        ElseIf strStateName = "SOUTH CAROLINA" Then
            strStateAbbreviation = "SC"
        ElseIf strStateName = "SOUTH DAKOTA" Then
            strStateAbbreviation = "SD"
        ElseIf strStateName = "TENNESSEE" Then
            strStateAbbreviation = "TN"
        ElseIf strStateName = "TEXAS" Then
            strStateAbbreviation = "TX"
        ElseIf strStateName = "UTAH" Then
            strStateAbbreviation = "UT"
        ElseIf strStateName = "VERMONT" Then
            strStateAbbreviation = "VT"
        ElseIf strStateName = "VIRGINIA" Then
            strStateAbbreviation = "VA"
        ElseIf strStateName = "WASHINGTON" Then
            strStateAbbreviation = "WA"
        ElseIf strStateName = "WEST VIRGINIA" Then
            strStateAbbreviation = "WV"
        ElseIf strStateName = "WISCONSIN" Then
            strStateAbbreviation = "WI"
        ElseIf strStateName = "WYOMING" Then
            strStateAbbreviation = "WY"
        ElseIf strStateName = "CANADA" Then
            strStateAbbreviation = "CN"
        ElseIf strStateName = "INTERNATIONAL" Then
            strStateAbbreviation = "IT"
        ElseIf strStateName = "PUERTO RICO" Then
            strStateAbbreviation = "PR"
        ElseIf strStateName = "VIRGIN ISLANDS" Then
            strStateAbbreviation = "VI"
        ElseIf strStateName = "PACIFIC ISLANDS" Then
            strStateAbbreviation = "PI"
        ElseIf strStateName = "GUAM" Then
            strStateAbbreviation = "GU"
        ElseIf strStateName = "AMERICAN SAMOA" Then
            strStateAbbreviation = "AS"
        ElseIf strStateName = "PALAU" Then
            strStateAbbreviation = "PW"
        ElseIf strStateName = "ARMED FORCES AMERICAS" Then
            strStateAbbreviation = "AA"
        ElseIf strStateName = "ARMED FORCES EUROPE" Then
            strStateAbbreviation = "AE"
        ElseIf strStateName = "ARMED FORCES PACIFIC" Then
            strStateAbbreviation = "AP"
        ElseIf strStateName = "UNITED STATES FEDERAL" Then
            strStateAbbreviation = "US"
        End If
        If strStateAbbreviation.Trim.Equals("") = True Then strStateAbbreviation = strTempStateName
        Return strStateAbbreviation
    End Function
End Class