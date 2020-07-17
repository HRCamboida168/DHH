Imports System.IO
Imports Microsoft.Reporting.WinForms

Public Class frm_sale_inv

    Dim dbHpr As New db_helper
    Private Sub frmSnackDrinkList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplitContainer2.Panel2Collapsed = True
        Try
            'disable button 
            dgInvMster.Rows.Clear()
            Dim sqlStr As String = ""
            Dim tbl As DataTable = Nothing

            sqlStr = "select v.inv_num,v.cli_num,v.cli_nm,v.phone_num,v.mobil_num,v.inv_issu_dt,v.gros_amt,v.dscnt_amt,v.vat_amt,v.net_amt,v.crcy_code,v.deposit_amt,v.pening_amt,v.inv_status from vw_invoice_clients v where year(inv_issu_dt)='" & Now.Year & "' and MONTH(inv_issu_dt)='" & Now.Month & "'"
            tbl = dbHpr.SelectData(sqlStr, "Invioce")

            For Each r As DataRow In tbl.Rows
                dgInvMster.Rows.Add(r("inv_num"),
                              r("cli_num"),
                              r("cli_nm"),
                              r("phone_num"),
                              r("mobil_num"),
                              r("inv_issu_dt"),
                              r("gros_amt"),
                              r("dscnt_amt"),
                              r("vat_amt"),
                              r("net_amt"),
                              r("deposit_amt"),
                              r("pening_amt"),
                              r("crcy_code"),
                              r("inv_status"))
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub tsbtnClose_Click(sender As Object, e As EventArgs) Handles tsbtnClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Public nodeT As TreeNode

    Public Act_typ As String
    Private Sub tbtnAdd_Click(sender As Object, e As EventArgs) Handles tbtnAdd.Click
        With frm_sale_inv_add
            Act_typ = "ADD"

            Dim inv_yyyymm As String = "B" & Format(Now.Date, "yyyyMM")

            Dim inv_num As String = dbHpr.GenerateID("select max(inv_num) from tdhh_invoice_masters v where substring(inv_num,1,7)='" & inv_yyyymm & "'", 4, inv_yyyymm)
            .txtInvNum.Text = inv_num


            Dim sqlStr As String = "select fld_valu,concat(fld_valu, ' - ', fld_valu_desc_en) val_desc from tswa_field_values f where f.fld_nm='SEX_CODE' and status='A'"
            Dim tbl As DataTable = dbHpr.SelectData(sqlStr, "client type")
            .cboSexcode.DataSource = tbl
            .cboSexcode.DisplayMember = "val_desc"
            .cboSexcode.ValueMember = "fld_valu"

            sqlStr = "select crcy_code,CONCAT(crcy_code,' - ', crcy_desc_en,' - ', crcy_amt) crcy_desc from tcurrency_masters where stat_cd='A'"
            tbl = dbHpr.SelectData(sqlStr, "Currency")
            .cboCurrency.DataSource = tbl
            .cboCurrency.DisplayMember = "crcy_desc"
            .cboCurrency.ValueMember = "crcy_code"

            .ShowDialog()
            .Close()
            .Dispose()
        End With
    End Sub

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgInvMster.CellContentClick

    End Sub
    Private Sub tbtnEdi_Click(sender As Object, e As EventArgs) Handles tbtnEdi.Click
        SDEdit()
    End Sub

    Private Sub SDEdit()
        If dgInvMster.SelectedRows.Count = 0 Then
            MsgBox("No data to Edit!", MsgBoxStyle.Information)
            Exit Sub
        End If
        If dgPmtDtls.RowCount > 0 Then
            If MsgBox("Exist payment for selected invoice, Are you sure you want to make change?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Edit Invoice") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Act_typ = "EDIT"
        If MsgBox("Are you sure you want to make change invoice?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            With frm_sale_inv_add
                Dim sqlStr As String = "select fld_valu,concat(fld_valu, ' - ', fld_valu_desc_en) val_desc from tswa_field_values f where f.fld_nm='SEX_CODE' and status='A'"
                Dim tbl As DataTable = dbHpr.SelectData(sqlStr, "client type")
                .cboSexcode.DataSource = tbl
                .cboSexcode.DisplayMember = "val_desc"
                .cboSexcode.ValueMember = "fld_valu"

                sqlStr = "select crcy_code,CONCAT(crcy_code,' - ', crcy_desc_en,' - ', crcy_amt) crcy_desc from tcurrency_masters where stat_cd='A'"
                tbl = dbHpr.SelectData(sqlStr, "Currency")
                .cboCurrency.DataSource = tbl
                .cboCurrency.DisplayMember = "crcy_desc"
                .cboCurrency.ValueMember = "crcy_code"

                'invoice master
                sqlStr = "select v.inv_num,v.cli_num,v.cli_nm,sex_code,v.phone_num,v.mobil_num,addr_l1,mail_addr,v.inv_issu_dt,v.gros_amt,v.dscnt_amt,v.vat_amt,v.net_amt,v.crcy_code,v.deposit_amt,v.pening_amt,v.inv_status from vw_invoice_clients v where v.inv_num='" & dgInvMster.SelectedRows(0).Cells(0).Value & "'"
                tbl = dbHpr.SelectData(sqlStr)
                If tbl.Rows.Count > 0 Then
                    'client
                    .txtcli_num.Text = tbl.Rows(0)("cli_num")
                    .txtClinm.Text = tbl.Rows(0)("cli_nm")
                    .cboSexcode.SelectedValue = tbl.Rows(0)("sex_code")
                    .txtphoneNum.Text = tbl.Rows(0)("phone_num")
                    .txtMobilNum.Text = tbl.Rows(0)("mobil_num")
                    .txtAddress.Text = tbl.Rows(0)("addr_l1")
                    .txtMail.Text = tbl.Rows(0)("mail_addr")
                    'invoice
                    .txtInvNum.Text = tbl.Rows(0)("inv_num")
                    .dtpInvDt.Value = tbl.Rows(0)("inv_issu_dt")
                    .cboCurrency.SelectedValue = tbl.Rows(0)("crcy_code")
                    .txtDiscntAmt.Text = tbl.Rows(0)("dscnt_amt")
                    .txtVAT.Text = tbl.Rows(0)("vat_amt")
                End If

                'itme details
                For Each r As DataGridViewRow In dgItem.Rows
                    .dgvItem.Rows.Add(r.Cells(0).Value, r.Cells(1).Value, r.Cells(2).Value, r.Cells(3).Value, r.Cells(4).Value)
                Next
                .ShowDialog()
                .Close()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub dgv1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgInvMster.CellDoubleClick
        SDEdit()
    End Sub

    Private Sub tbtnDel_Click(sender As Object, e As EventArgs) Handles tbtnDel.Click
        'If dgv1.SelectedRows.Count = 0 Then
        '    MsgBox("There Is no booking to cancel!", MsgBoxStyle.Exclamation, "Book Cancelling")
        '    Exit Sub
        'End If
        'If MsgBox("Are you sure you want to cancel booking?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Room Cancelling") = MsgBoxResult.Yes Then
        '    With frmRoomBookCancellation
        '        .ShowDialog()
        '        If .DialogResult = Windows.Forms.DialogResult.OK Then
        '            dbHpr.ExecProc("tgh_room_bookings_up_stat", "rbk_num", dgv1.SelectedCells(0).Value, "stat_cd", "C")
        '            dbHpr.ExecProc("ins_tswa_trxn_histories", "pi_trxn_dt", Now, "pi_trnx_cd", "RBCANCL", "pi_fnc_nm", Me.Name, "pi_user_id", MasterFRM.loginName, "pi_act_cd", dgv1.SelectedCells(0).Value, "pi_act_desc", .TextBox1.Text, "pi_remarks", dgv1.SelectedCells(1).Value & "- It's change from " & dgv1.SelectedCells(11).Value & "-to-C")
        '            dgv1.SelectedRows(0).DefaultCellStyle.BackColor = System.Drawing.Color.Red
        '        End If
        '        .Close()
        '    End With
        'End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtInvoice.TextChanged, TextBox1.TextChanged

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsbtnSearch.Click
        tsbtnSearch.Checked = Not tsbtnSearch.Checked
        Me.SplitContainer2.Panel2Collapsed = Not Me.SplitContainer2.Panel2Collapsed
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim sqlStr As String = "select rb.rbk_num,rbk_typ,rb.cli_nm,rb.id_num,rb.cli_phone,rb.bnk_frm_dt,rb.bnk_to_dt,rb.chk_out_dt,rb.grs_amt,rb.dscnt_amt,rb.net_amt,deposit_amt,rb.stat_cd,cd.nationality,cd.no_of_ppl from tgh_room_bookings rb,tgh_client_dtls cd where rb.rbk_num=cd.cli_num and  stat_cd='B' and rb.cli_nm like '%" & txtInvoice.Text & "%'"
        Dim tbl As DataTable = dbHpr.SelectData(sqlStr, "Booking")
        dgInvMster.Rows.Clear()
        For Each r As DataRow In tbl.Rows
            dgInvMster.Rows.Add(r(0), r(1), r(2), r(3), r(4), r(5), r(6), r(7), r(8), r(9), r(10), r(11), r(12), r(13), r(14))
        Next
    End Sub

    Private Sub dgv1_SelectionChanged(sender As Object, e As EventArgs) Handles dgInvMster.SelectionChanged
        On Error Resume Next
        Dim sqlStr As String = ""
        Dim tbl As DataTable = Nothing

        'item Details
        dgItem.Rows.Clear()
        sqlStr = "select * from tdhh_invoice_details where inv_num='" & dgInvMster.SelectedRows(0).Cells(0).Value & "'"
        tbl = dbHpr.SelectData(sqlStr, "Item")
        For Each r As DataRow In tbl.Rows
            dgItem.Rows.Add(r("itm_num"), r("remarks"), r("itm_qty"), r("unit_price"), r("tot_amt"))
        Next

        'payment details
        dgPmtDtls.Rows.Clear()
        sqlStr = "select * from tdhh_invoice_payments where inv_num='" & dgInvMster.SelectedRows(0).Cells(0).Value & "'"
        tbl = dbHpr.SelectData(sqlStr, "Item")
        For Each r As DataRow In tbl.Rows
            dgPmtDtls.Rows.Add(r("pmt_num"), r("pmt_dt"), r("strt_bal"), r("pmt_amt"), r("end_bal"))
        Next

        'PictureBox1.Image = Nothing
        'PictureBox2.Image = Nothing
        ''photo
        'dbHpr.ShowImageStorProc("get_cli_photo", PictureBox1, "rbk_num", dgv1.SelectedRows(0).Cells(0).Value, "doc_typ", "F") 'front
        'dbHpr.ShowImageStorProc("get_cli_photo", PictureBox2, "rbk_num", dgv1.SelectedRows(0).Cells(0).Value, "doc_typ", "B") 'back

    End Sub

    Public Shared print_typ As String = "POS"
    Public Shared pmt_type As String = "FULL"
    Public Shared pmt_dt As Date
    Public Shared bginBal As Double
    Public Shared payment_amt As Double
    Public Shared endBal As Double

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles tsbPrintInvoice.Click
        If dgInvMster.SelectedRows.Count = 0 Then
            MsgBox("there is no invoice to print!!!", MsgBoxStyle.Exclamation, "Print Invoice")
            Exit Sub
        End If

        'get begin balance
        Dim begin_bal As Double = 0
        Dim inv_status As String = "X"
        Dim sqlStr As String = "select i.pening_amt,inv_status from tdhh_invoice_masters i where i.inv_num='" & dgInvMster.SelectedRows(0).Cells(0).Value & "'; "
        Dim tbl As DataTable = dbHpr.SelectData(sqlStr, "Invoice Balance")
        If tbl.Rows.Count > 0 Then
            begin_bal = CDbl(tbl.Rows(0)("pening_amt"))
            inv_status = tbl.Rows(0)("inv_status").ToString
        End If

        If begin_bal <= 0 Then
            MsgBox("select invoice is already paid off!", MsgBoxStyle.Information, "Print Invoice")
            Exit Sub
        End If


        If inv_status <> "A" And inv_status <> "P" Then
            MsgBox("Invoice is not in printing status!, Print status are:'A' and 'P'.", MsgBoxStyle.Information, "Print Invoice")
            Exit Sub
        End If

        PrintPayment(begin_bal)

    End Sub

    Private Sub PrintPayment(begin_bal As Double)
        Dim is_print As Boolean = False

        With frm_sale_inv_printParm

            .txtStartBal.Text = begin_bal
            .rbFullPay.Checked = True
            .txtPayAmount.Text = .txtStartBal.Text

            .txtEndBal.Text = 0

            .ShowDialog()
            If .DialogResult = System.Windows.Forms.DialogResult.OK Then
                is_print = True
                print_typ = IIf(.rbPOS.Checked = True, "POS", "A4")
                pmt_type = IIf(.rbFullPay.Checked = True, "FUL", "SPL")
                pmt_dt = .dtpPmtDt.Value.Date
                bginBal = CDbl(.txtStartBal.Text)
                payment_amt = CDbl(.txtPayAmount.Text)
                endBal = CDbl(.txtEndBal.Text)

            End If
            .Close()
            .Dispose()
        End With

        If is_print = True Then
            Try
                'Save Payment Details
                GenPayment(dgInvMster.SelectedRows(0).Cells(0).Value, dgInvMster.SelectedRows(0).Cells(1).Value, pmt_dt, bginBal, payment_amt, endBal)

            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

            'show print perview
            With frm_sale_inv_print
                .ShowDialog()
                .Close()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub GenPayment(inv_num As String, cli_num As String, pmt_dt As Date, str_bal As Double, pay_amt As Double, end_bal As Double)
        Try
            '==>> Save Payment details
            Dim pmt_num As String = dbHpr.GenerateID("Select max(pmt_num) from tdhh_invoice_payments where inv_num='" & inv_num & "'")
            dbHpr.ExecProc("tdhh_invoice_payments_ins", "pmt_num", pmt_num, "inv_num", inv_num, "cli_num", cli_num,
                   "pmt_dt", pmt_dt, "strt_bal", str_bal, "pmt_amt", pay_amt, "end_bal", end_bal, "rec_status", IIf(end_bal = 0, "C", "P"),
                   "created_dt", Now.Date, "created_by", MasterFRM.loginName)
            '==<< Save Payment details
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub PrintPreview(bill_num As String)

        With frmBill005PrintPreview
            'view report
            'reset
            .ReportViewer1.Reset()
            'data source
            Dim sqlStr As String = "select v.* from vw_bill_hdrs v where  v.bill_num='" & bill_num & "'"
            Dim dt As DataTable = dbHpr.SelectData(sqlStr, "Bill master")
            Dim rds1 As New ReportDataSource("DataSet1", dt)
            .ReportViewer1.LocalReport.DataSources.Add(rds1)

            sqlStr = "Select d.* from vw_bill_dtls d  where  d.bill_num='" & bill_num & "' "
            dt = dbHpr.SelectData(sqlStr, "Bill details")
            Dim rds2 As New ReportDataSource("DataSet2", dt)
            .ReportViewer1.LocalReport.DataSources.Add(rds2)
            'Path
            .ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\rpt\rptBill002.rdlc"
            .ReportViewer1.ZoomMode = ZoomMode.FullPage
            'refresh
            .ReportViewer1.RefreshReport()

            .ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)

            .Width = 680
            .Height = MasterFRM.Height
            .ShowDialog()
            .Close()
            .Dispose()
        End With

    End Sub

End Class