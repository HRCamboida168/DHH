Public Class frmBill005PrintPreview

    Dim dbHpr As New db_helper
    Public bginBal As Double = 0
    Public pay_amount As Double = 0
    Public end_bal As Double = 0
    Private Sub frmBill005PrintPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_PrintingBegin(sender As Object, e As Microsoft.Reporting.WinForms.ReportPrintEventArgs) Handles ReportViewer1.PrintingBegin
        'With frmRoomCheckInOut
        '    Dim remark As String = "Bill reprint"
        '    If .dgv1.SelectedCells(12).Value = "S" Then
        '        'mark as printed
        '        dbHpr.ExecProc("tgh_bill_hdrs_upd_status", "bill_num", .dgv1.SelectedCells(0).Value, "stat_cd", "P")
        '        remark = "Init"
        '        .dgv1.SelectedCells(12).Value = "P"

        '        'refresh grid
        '        With frmRoomCheckInOut
        '            .dgv1.SelectedCells(12).Value = "P"
        '        End With
        '    End If

        '    'save history
        '    dbHpr.ExecProc("tgh_bill_print_histories_ins", "bill_num", .dgv1.SelectedCells(0).Value, "print_dt", Now, "print_by", MasterFRM.loginName, "reasn", remark)
        'End With
    End Sub
End Class