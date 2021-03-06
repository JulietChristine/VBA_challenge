Sub WookbookApply()
    Dim WS As Worksheet
    Application.ScreenUpdating = False
    For Each WS In Worksheets
        WS.Select
        Call AllStocks
    Next
    Application.ScreenUpdating = True
End Sub
Sub AllStocks()
  On Error Resume Next

  Range("J1").Value = "Ticker"
  Range("K1").Value = "Ann Change"
  Range("L1").Value = "Pct Change"
  Range("M1").Value = "Total Vol"

  Dim Ticker As String
  Dim Stock_Volume As Double
  Dim YearChg As Double
  Dim PctChg As Double
  Stock_Volume = 0
  YearChg = 0
  PctChg = 0
  Dim Table_Row As Integer
  Table_Row = 2
  For i = 2 To 71226
    If Cells(i + 1, 1).Value <> Cells(i, 1) Then
        Ticker = Cells(i, 1).Value
        YearChg = Cells(i, 6) - Cells(i - 261, 3)
        PctChg = (Cells(i, 6) - Cells(i - 261, 3)) / Cells(i - 261, 3)
        Stock_Volume = Stock_Volume + Cells(i, 7)
        Range("J" & Table_Row).Value = Ticker
        Range("K" & Table_Row).Value = YearChg
              If Range("K" & Table_Row) < 0 Then
                Range("K" & Table_Row).Interior.ColorIndex = 3
              Else
                Range("K" & Table_Row).Interior.ColorIndex = 4
              End If
        Range("L" & Table_Row).Value = PctChg
        Range("L" & Table_Row).NumberFormat = "0.00%"
        Range("M" & Table_Row).Value = Stock_Volume
        Table_Row = Table_Row + 1
        Stock_Volume = 0
    Else
        Stock_Volume = Stock_Volume + Cells(i, 7).Value
    End If
  Next i
End Sub