Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class frm_sale_inv_add
    Dim dbhpr As New db_helper
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtClinm_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClinm.KeyDown
        If (e.KeyValue >= 48 And e.KeyValue <= 57) Or (e.KeyValue >= 65 And e.KeyValue <= 90) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Then
            ItemList()
        ElseIf e.KeyCode = Keys.Enter Then
            'MsgBox(txtCode.Text.Length)
            If txtcli_num.Text.Trim.Length = 0 Then
                SelectNextControl(sender, True, True, True, True)
            Else
                ItemList()
            End If
            If dgvFilter.Visible = True Then
                dgvFilter.Focus()
                dgvFilter.Rows(0).Selected = True
            End If
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then
            resetClientFields()
        ElseIf e.KeyCode = Keys.Escape Then
            resetClientFields()
            txtClinm.FindForm()
        ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            If dgvFilter.Visible = True Then
                dgvFilter.Focus()
            End If
        End If
    End Sub
    Private Sub txtphoneNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVAT.KeyDown, txtphoneNum.KeyDown, txtNetAmt.KeyDown, txtMobilNum.KeyDown, txtMail.KeyDown, txtGrosamt.KeyDown, txtDiscntAmt.KeyDown, txtAddress.KeyDown, dtpInvDt.KeyDown, cboCurrency.KeyDown, cboSexcode.KeyDown, txtEndAmt.KeyDown, txtDeposit.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectNextControl(sender, True, True, True, True)
        End If
    End Sub
    Dim cli_
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtClinm.Text.Trim.Length = 0 Then
            MsgBox("Please input client name to create invoice!!", MsgBoxStyle.Critical, "Invoice")
            txtClinm.Focus()
            Exit Sub
        End If
        'create client
        If txtcli_num.Text.Length = 0 Then
            Dim cli_num_hdr As String = "C" & Format(Now, "yyyyMM")
            Dim cli_num As String = dbhpr.GenerateID("select max(cli_num) from tdhh_client_details where substring(cli_num,1,7)= '" & cli_num_hdr & "' ", 4, cli_num_hdr)
            txtcli_num.Text = cli_num
        End If
        dbhpr.ExecProc("tdhh_client_details_ins_upd", "cli_num", txtcli_num.Text, "cli_nm", txtClinm.Text, "sex_code", cboSexcode.SelectedValue, "birth_dt", DBNull.Value, "id_num", "", "id_typ", "", "addr_l1", txtAddress.Text, "phone_num", txtphoneNum.Text, "mobil_num", txtMobilNum.Text, "mail_addr", txtMail.Text, "cli_typ", "C", "rec_status", "A")

        With frmBill002AddItem
            'Dim sqlStr As String = "Select crcy_code, concat(crcy_code,': ', crcy_desc_en ) crcy_desc from tcurrency_masters where stat_cd='A'"
            'Dim tbl As DataTable = dbhpr.SelectData(sqlStr, "client type")
            '.cboType.DataSource = tbl
            '.cboType.DisplayMember = "crcy_desc"
            '.cboType.ValueMember = "crcy_code"

            .ShowDialog()
            If .DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                .Close()
                .Dispose()

            End If

        End With
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgvItem.SelectedRows.Count > 0 Then
            If MsgBox("Are you sure you want to remove item?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                dgvItem.Rows.RemoveAt(dgvItem.SelectedRows(0).Index)
            End If
        End If
    End Sub
    Sub ItemList()
        Dim str As String = "select top 10 cli_num,cli_nm,sex_code,phone_num,mobil_num,mail_addr,addr_l1 from tdhh_client_details  where  dbo.UncodeConvert(lower(cli_nm)) Like '%'+ dbo.UncodeConvert(N'" & txtClinm.Text.ToLower & "') +'%'  "
        Dim tbl As DataTable = dbhpr.SelectData(str, "ItemList")
        If tbl.Rows.Count > 0 Then
            'CLEAR COL ROWS
            dgvFilter.Rows.Clear()
            dgvFilter.Height = 20
            'SET NEW ROWS
            For Each r As DataRow In tbl.Rows
                dgvFilter.Rows.Add(r(0), r(1), r(2), r(3), r(4), r(5), r(6))
                dgvFilter.Height = dgvFilter.Height + 20
            Next
            dgvFilter.Visible = True

            'SET LOCATION
            dgvFilter.Left = txtClinm.Left
            dgvFilter.Top = txtClinm.Bottom
            dgvFilter.Width = txtNetAmt.Width * 2

        Else
            dgvFilter.Visible = False
        End If
    End Sub
    Sub Get_Val_item()
        If dgvFilter.SelectedRows.Count > 0 Then
            resetClientFields()
            txtcli_num.Text = dgvFilter.SelectedCells(0).Value
            txtClinm.Text = dgvFilter.SelectedCells(1).Value
            cboSexcode.SelectedValue = dgvFilter.SelectedCells(2).Value
            txtphoneNum.Text = dgvFilter.SelectedCells(3).Value
            txtMobilNum.Text = dgvFilter.SelectedCells(4).Value
            txtMail.Text = dgvFilter.SelectedCells(5).Value
            txtAddress.Text = dgvFilter.SelectedCells(6).Value
            dtpInvDt.Focus()
        Else
            dgvFilter.Visible = False
        End If
    End Sub
    Private Sub resetClientFields()
        txtcli_num.Text = ""
        txtphoneNum.Text = ""
        txtMobilNum.Text = ""
        txtMail.Text = ""
        txtAddress.Text = ""
    End Sub

    Private Sub txtClinm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClinm.KeyPress
        If e.KeyChar = Chr(8) Then
            ItemList()
        End If
    End Sub

    Private Sub dgvFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            Get_Val_item()
            dgvFilter.Visible = False
        ElseIf e.KeyCode = Keys.Escape Then
            dgvFilter.Visible = False
        End If
    End Sub

    Private Sub dgvFilter_LostFocus(sender As Object, e As EventArgs) Handles dgvFilter.LostFocus
        dgvFilter.Visible = False
    End Sub

    Private Sub dgvFilter_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Get_Val_item()
        dgvFilter.Visible = False
    End Sub

    Private Sub frm_sale_inv_add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvItem.Columns("qty").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvItem.Columns("unitprice").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvItem.Columns("total").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub dgvItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvItem.RowStateChanged
        CalAmt()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVAT.KeyPress, txtNetAmt.KeyPress, txtGrosamt.KeyPress, txtDiscntAmt.KeyPress, txtEndAmt.KeyPress, txtDeposit.KeyPress
        NumericInput(e, ".", False)
    End Sub

    Private Sub txtGrosamt_TextChanged(sender As Object, e As EventArgs) Handles txtGrosamt.TextChanged, txtVAT.TextChanged, txtNetAmt.TextChanged, txtEndAmt.TextChanged, txtDiscntAmt.TextChanged, txtDeposit.TextChanged
        If sender.text.trim = "" Then
            Exit Sub
        End If
        If IsNumeric(sender.text) = False Then
            MsgBox("Incorrect number format!!!", MsgBoxStyle.Exclamation, "Add Item")
            Exit Sub
        End If

        CalAmt()
    End Sub
    Private Sub CalAmt()
        On Error Resume Next
        txtGrosamt.Text = SumGrid(dgvItem, 4)
        Dim gross_amt As Double = IIf(IsNumeric(txtGrosamt.Text) = False, 0, CDbl(txtGrosamt.Text))
        Dim dscnt_amt As Double = IIf(IsNumeric(txtDiscntAmt.Text) = False, 0, CDbl(txtDiscntAmt.Text))
        Dim vat As Double = IIf(IsNumeric(txtVAT.Text) = False, 0, CDbl(txtVAT.Text))
        'Net
        txtNetAmt.Text = Math.Round((gross_amt - dscnt_amt) + (((gross_amt - dscnt_amt) * vat) / 100), 2)
        'depost = net if full payment
        Dim deposit_amt As Double = IIf(IsNumeric(txtDeposit.Text) = False, txtNetAmt.Text, CDbl(txtDeposit.Text))
        'balance
        txtEndAmt.Text = Math.Round(CDbl(txtNetAmt.Text) - deposit_amt, 2)
    End Sub

    Private Sub dgvFilter_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFilter.CellDoubleClick
        Get_Val_item()
        dgvFilter.Visible = False
    End Sub

    Private Sub SaveInvoice(inv_status As String)
        'remove old
        dbhpr.ExecProc("tdhh_invoice_details_del", "inv_num", txtInvNum.Text)
        'start new record
        Dim Objcn As DBSingle
        Dim cn As SqlConnection
        Objcn = DBSingle.GetInstance
        cn = Objcn.GetConnection

        Dim Trans1 As SqlClient.SqlTransaction = cn.BeginTransaction
        Dim cmd As New SqlClient.SqlCommand("", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Transaction = Trans1
        Try
            '-->> Save Master
            'Dim inv_num_dhr As String = "B" & Format(Now, "yyyyMM")
            'Dim inv_num As String = dbhpr.GenerateID("select max(inv_num) from tdhh_invoice_masters where substring(inv_num,1,7)='" & inv_num_dhr & "'", 4, inv_num_dhr)
            cmd.CommandText = "tdhh_invoice_masters_ins"
            CreatePar(cmd, "inv_num", txtInvNum.Text, "cli_num", txtClinm.Text,
                      "inv_issu_dt", dtpInvDt.Value.Date,
                      "gros_amt", txtGrosamt.Text, "dscnt_amt", txtDiscntAmt.Text, "vat_amt", txtVAT.Text,
                      "net_amt", txtNetAmt.Text, "remarks", "",
                      "inv_status", inv_status,
                      "crcy_code", cboCurrency.SelectedValue,
                      "deposit_amt", txtDeposit.Text, "pening_amt", CDbl(txtNetAmt.Text) - CDbl(txtDeposit.Text),
                      "rec_status", "A",
                      "created_dt", Now.Date, "created_by", MasterFRM.loginName)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            '--<< save master
            '==> Save detail
            cmd.CommandText = "tdhh_invoice_details_ins"
            For i As Int16 = 0 To dgvItem.RowCount
                CreatePar(cmd, "inv_num", txtInvNum.Text,
                          "itm_num", dgvItem.Rows(i).Cells(0).Value,
                          "itm_qty", dgvItem.Rows(i).Cells(2).Value,
                          "unit_price", dgvItem.Rows(i).Cells(3).Value,
                          "tot_amt", dgvItem.Rows(i).Cells(4).Value,
                          "remarks", dgvItem.Rows(i).Cells(1).Value)
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
            Next
            '==<< Save detail
            Trans1.Commit()
        Catch ex As Exception
            Trans1.Rollback()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub GenPayment(inv_num As String, cli_num As String, str_bal As Double, pay_amt As Double, end_bal As Double)
        Try
            '==>> Save Payment details
            Dim pmt_num As String = dbhpr.GenerateID("Select max(pmt_num) from tdhh_invoice_payments where inv_num='" & inv_num & "'")
            dbhpr.ExecProc("tdhh_invoice_payments_ins", "pmt_num", txtInvNum.Text, "inv_num", txtInvNum.Text, "cli_num", txtClinm.Text,
                   "pmt_dt", Now.Date, "pmt_amt", txtDeposit.Text, "end_bal", txtEndAmt.Text, "rec_status", IIf(CDbl(txtEndAmt.Text) = 0, "P", "B"),
                   "created_dt", Now.Date, "created_by", MasterFRM.loginName)
            '==<< Save Payment details
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub InvoiceValidat(ByRef err_msg As String)
        If txtClinm.Text.Trim.Length = 0 Then
            MsgBox("Please intput client!", MsgBoxStyle.Critical, "Invoice")
            err_msg = "01" 'client is require
            Exit Sub
        End If
        If dgvItem.RowCount = 0 Then
            MsgBox("No Item to print invoice!", MsgBoxStyle.Critical, "Invoice")
            err_msg = "02" 'not item to print 
            Exit Sub
        End If
        If CDbl(txtNetAmt.Text) <= 0 Then
            MsgBox("There is no amount to print invoice!", MsgBoxStyle.Critical, "Invoice")
            err_msg = "04" 'Net amount can't <=0
            Exit Sub
        End If
        If CDbl(txtDeposit.Text) > CDbl(txtNetAmt.Text) Then
            MsgBox("Deposit can't greater then Net amount!!!", MsgBoxStyle.Critical, "Invoice")
            err_msg = "05"
            Exit Sub
        End If
        err_msg = "00" ' no error
    End Sub
    Private Sub btnSavePrint_Click(sender As Object, e As EventArgs) Handles btnSavePrint.Click

    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Dim errSms As String = ""
        InvoiceValidat(errSms)
        If errSms <> "00" Then
            Exit Sub
        End If
        Dim inv_status As String = "P"

        SaveInvoice(inv_status)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
