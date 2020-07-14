Public Class frm_sale_inv

    Dim dbHpr As New db_helper
    Private Sub frmSnackDrinkList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplitContainer2.Panel2Collapsed = True
        Try
            'disable button 
            dgv1.Rows.Clear()
            Dim sqlStr As String = ""
            Dim tbl As DataTable = Nothing

            sqlStr = "select v.inv_num,v.cli_num,v.cli_nm,v.phone_num,v.mobil_num,v.inv_issu_dt,v.gros_amt,v.dscnt_amt,v.vat_amt,v.net_amt,v.crcy_code,v.inv_status from vw_invoice_clients v where v.inv_status='P'"
            tbl = dbHpr.SelectData(sqlStr, "Booking")

            For Each r As DataRow In tbl.Rows
                dgv1.Rows.Add(r(0), r(1), r(2), r(3), r(4), r(5), r(6), r(7), r(8), r(9), r(10), r(11), r(12), r(13), r(14))
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

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick

    End Sub
    Private Sub tbtnEdi_Click(sender As Object, e As EventArgs) Handles tbtnEdi.Click
        SDEdit()
    End Sub

    Private Sub SDEdit()
        'If dgv1.SelectedRows.Count = 0 Then
        '    MsgBox("No data to Edit!", MsgBoxStyle.Information)
        '    Exit Sub
        'End If
        'Act_typ = "EDIT"
        'If MsgBox("Are you sure you Like to Edit room booking?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    With frmRoomBookingAdd
        '        Dim sqlStr As String = "select fld_valu,concat(fld_valu, '- ', fld_valu_desc_en) val_desc from tswa_field_values f where f.fld_nm='PRIC_SCHD_FOR' and status='A'"
        '        Dim tbl As DataTable = dbHpr.SelectData(sqlStr, "client type")
        '        .cboBookingTyp.DataSource = tbl
        '        .cboBookingTyp.ValueMember = "fld_valu"
        '        .cboBookingTyp.DisplayMember = "val_desc"

        '        .txtBook_code.Text = dgv1.SelectedCells(0).Value
        '        .cboBookingTyp.SelectedValue = dgv1.SelectedCells(1).Value
        '        .txtClientName.Text = dgv1.SelectedCells(2).Value
        '        .txtIDPasspordNum.Text = dgv1.SelectedCells(3).Value
        '        .txtPhone.Text = dgv1.SelectedCells(4).Value
        '        .dtpFromDt.Value = dgv1.SelectedCells(5).Value
        '        .dtpToDt.Value = dgv1.SelectedCells(6).Value
        '        .txtDiposit.Text = dgv1.SelectedCells(11).Value
        '        .txtnational.Text = dgv1.SelectedCells(13).Value
        '        .txtNoPPL.Text = dgv1.SelectedCells(14).Value

        '        'picture
        '        .PictureBox1.Image = PictureBox1.Image
        '        .PictureBox2.Image = PictureBox2.Image
        '        'get booked rooms
        '        sqlStr = "select bd.*,r.room_nm,r.room_typ,f.fld_valu_desc_en from tgh_room_booking_dtls bd,tgh_rooms r,tswa_field_values f where bd.room_num=r.room_num and r.room_typ=f.fld_valu and f.fld_nm='ROOM_TYP' and bd.rbk_num='" & dgv1.SelectedCells(0).Value & "';"
        '        tbl = dbHpr.SelectData(sqlStr, "Booking Room")
        '        For Each r As DataRow In tbl.Rows
        '            .dgvRoom.Rows.Add(r(1), r(6), r(8), r(2), r(3), r(4), r(5))
        '        Next
        '        'not allow to change if record in list room
        '        .dtpToDt.Enabled = False
        '        .cboBookingTyp.Enabled = False
        '        .dtpToDt.Enabled = False

        '        .ShowDialog()
        '        .Close()
        '        .Dispose()
        '    End With
        'End If
    End Sub

    Private Sub dgv1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick
        SDEdit()
    End Sub

    Private Sub tbtnDel_Click(sender As Object, e As EventArgs) Handles tbtnDel.Click
        'If dgv1.SelectedRows.Count = 0 Then
        '    MsgBox("There is no booking to cancel!", MsgBoxStyle.Exclamation, "Book Cancelling")
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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtCliNm.TextChanged

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsbtnSearch.Click
        tsbtnSearch.Checked = Not tsbtnSearch.Checked
        Me.SplitContainer2.Panel2Collapsed = Not Me.SplitContainer2.Panel2Collapsed
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim sqlStr As String = "select rb.rbk_num,rbk_typ,rb.cli_nm,rb.id_num,rb.cli_phone,rb.bnk_frm_dt,rb.bnk_to_dt,rb.chk_out_dt,rb.grs_amt,rb.dscnt_amt,rb.net_amt,deposit_amt,rb.stat_cd,cd.nationality,cd.no_of_ppl from tgh_room_bookings rb,tgh_client_dtls cd where rb.rbk_num=cd.cli_num and  stat_cd='B' and rb.cli_nm like '%" & txtCliNm.Text & "%' and rb.id_num like '%" & txtIDPss.Text & "%' and rb.cli_phone like '%" & txtPhone.Text & "%'"
        Dim tbl As DataTable = dbHpr.SelectData(sqlStr, "Booking")
        dgv1.Rows.Clear()
        For Each r As DataRow In tbl.Rows
            dgv1.Rows.Add(r(0), r(1), r(2), r(3), r(4), r(5), r(6), r(7), r(8), r(9), r(10), r(11), r(12), r(13), r(14))
        Next
    End Sub

    Private Sub dgv1_SelectionChanged(sender As Object, e As EventArgs) Handles dgv1.SelectionChanged
        'On Error Resume Next
        'PictureBox1.Image = Nothing
        'PictureBox2.Image = Nothing
        ''photo
        'dbHpr.ShowImageStorProc("get_cli_photo", PictureBox1, "rbk_num", dgv1.SelectedRows(0).Cells(0).Value, "doc_typ", "F") 'front
        'dbHpr.ShowImageStorProc("get_cli_photo", PictureBox2, "rbk_num", dgv1.SelectedRows(0).Cells(0).Value, "doc_typ", "B") 'back

    End Sub
End Class