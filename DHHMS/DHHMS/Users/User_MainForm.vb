Imports System.Windows.Forms
Public Class User_MainForm

    Dim dbHpr As New db_helper
    Dim logDb As New LoginDB
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub
    Public chd As Boolean = False
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnCreate.Click
        With User_Input
aa:
            .ShowDialog()
            If .DialogResult = System.Windows.Forms.DialogResult.OK Then
                Dim pin As String = logDb.encodePin(.txtpwd.Text, Format(Now.Date, "dd/MM/yyyy"))
                'save build -in user
                Dim err_msg As String
                err_msg = dbHpr.ExecStored("INS_TWSA_USER_PIN_MASTER", "err_msg",
                                        "PI_USER_ID", .txtname.Text,
                                        "PI_USER_PIN", pin,
                                        "PI_FAIL_ATTEMPTS", 0,
                                        "PI_LAST_FAIL_TRY", Now.Date,
                                        "PI_PIN_REMINDER", "Admin",
                                        "PI_LAST_LOGIN_DT", Now,
                                        "PI_LAST_LOGIN_STATUS", "N",
                                        "PI_PIN_ACTIVATED", "Y",
                                        "PI_PIN_DATE", Format(Now.Date, "dd/MM/yyyy"),
                                        "PI_IS_LOCKED", "N",
                                        "PI_IS_LOGINED", "N",
                                        "PI_USER_NAME", .txtFullname.Text,
                                        "PI_PIN_STATUS", "Y",
                                        "PI_PIN_STATUS_LUD", DBNull.Value,
                                        "PI_USER_STATUS", "A",
                                        "PI_LUCKY_NUM", "99",
                                        "PI_BIRTH_DT", Now.Date,
                                        "PI_USR_ROLE", IIf(.cbopol.Checked = True, "ADMIN", "USER"))

                dg1.Rows.Add(.txtFullname.Text, .txtname.Text, "N", IIf(.cbopol.Checked = True, "Admin", "User"))

                'clear text
                .txtFullname.Text = ""
                .txtname.Text = ""
                .txtpwd.Text = ""
                .txtpwdconf.Text = ""

                .cbopol.Checked = False

                GoTo aa
            Else
                .Close()
            End If
        End With
    End Sub

    Private Sub User_MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim str As String = "SELECT [USER_NAME],[USER_ID],[IS_LOCKED],[USR_ROLE]  FROM [dbo].[tswa_user_pin_master]"
        Dim tbl As DataTable = dbHpr.SelectData(str, "USER")
        dg1.Rows.Clear()
        For Each R As DataRow In tbl.Rows
            dg1.Rows.Add(R(0), R(1), R(2), R(3))
        Next

    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnEdit.Click

        If dg1.SelectedRows.Count = 0 Then
            MsgBox("មិនមានអ្នកប្រើប្រាស់ដើម្បីបិទទេការប្រើប្រាស់ទេ!", MsgBoxStyle.Information, "User Edit")
            Exit Sub
        End If
        If MsgBox("តើអ្នកពិតជាចង់បិទការប្រើប្រាស់របង់អ្នកប្រើប្រាស់មែនទេ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            dbHpr.ExecProc("disbl_TWSA_USER_PIN_MASTER", "PI_USER_ID", dg1.SelectedRows(0).Cells(1).Value, "PI_IS_LOCKED", "Y")

            dg1.SelectedRows(0).Cells(2).Value = "Y"

            MsgBox("អ្នកប្រើប្រាស់ត្រូវបានបិទការប្រើប្រាស់ដោយជោគជ័យ!")
        End If

    End Sub


    Private Sub tbtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnSearch.Click
        tbtnSearch.Checked = Not tbtnSearch.Checked
        SplitContainer1.Panel1Collapsed = Not SplitContainer1.Panel1Collapsed
    End Sub

    Private Sub tbtnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnChange.Click
        With User_ChangePWD
            If dg1.SelectedRows.Count = 0 Then
                MsgBox("មិនមានអ្នកប្រើប្រាស់ក្នុងការផ្លាស់ប្តូរទេ...!", MsgBoxStyle.Exclamation, "Change password...")
                Exit Sub
            End If
            If MsgBox("តើអ្នកពិតជាចង់ផ្លាស់ប្តូរលេខសម្ងាត់របស់អ្នកប្រើប្រាស់មែនទេ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                'get data
                Dim sqlStr As String = "select * from tswa_user_pin_master where user_id='" & dg1.SelectedRows(0).Cells(1).Value & "'"

                Dim tbl As DataTable = dbHpr.SelectData(sqlStr)
                If tbl.Rows.Count > 0 Then
                    MasterFRM.userOldPin = tbl.Rows(0)("USER_PIN")
                    MasterFRM.userPinDt = tbl.Rows(0)("PIN_DATE")
                    .txtFullname.Text = tbl.Rows(0)("USER_NAME")
                    .txtname.Text = dg1.SelectedRows(0).Cells(1).Value
                Else
                    MsgBox("មិនមានអ្នកប្រើប្រាស់ដើម្បីប្តូរទេ!")
                    Exit Sub
                End If

                .ShowDialog()
                If .DialogResult = System.Windows.Forms.DialogResult.OK Then
                    Dim userNewPin As String = logDb.encodePin(.txtNewPWD.Text, Format(Now.Date, "dd/MM/yyyy"))
                    dbHpr.ExecProc("upd_TWSA_USER_PIN_MASTER", "PI_USER_ID", .txtname.Text, "PI_USER_PIN", userNewPin, "PI_PIN_DATE", Format(Now.Date, "dd/MM/yyyy"))

                    MsgBox("ការប្តូរលេខសម្ងាត់បានជោកជ័យ!")
                End If
                .Close()
            End If
        End With
    End Sub

    Private Sub tbtnreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnreset.Click
        If dg1.SelectedRows.Count = 0 Then
            MsgBox("មិនមានអ្នកប្រើប្រាស់ក្នុងការផ្លាស់ប្តូរទេ!")
        End If

        If MsgBox("តើអ្នកពិតជាចង់ផ្លាស់ប្តូរលេខសម្ងាត់ថ្មីរបស់អ្នកប្រើប្រាស់មែនទេ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Dim userNewPin As String = logDb.encodePin("newpin1234", Format(Now.Date, "dd/MM/yyyy"))
            dbHpr.ExecProc("upd_TWSA_USER_PIN_MASTER", "PI_USER_ID", dg1.SelectedRows(0).Cells(1).Value, "PI_USER_PIN", userNewPin, "PI_PIN_DATE", Format(Now.Date, "dd/MM/yyyy"))

            MsgBox("ការប្តូរលេខសម្ងាត់បានជោកជ័យទៅជា៖ 'newpin1234'", MsgBoxStyle.Information, "Password Reset")
        End If

    End Sub

    Private Sub dg1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub tsbEnableUser_Click(sender As Object, e As EventArgs) Handles tsbEnableUser.Click
        If dg1.SelectedRows.Count = 0 Then
            MsgBox("មិនមានអ្នកប្រើប្រាស់ដើម្បីបើកទេការប្រើប្រាស់ទេ!", MsgBoxStyle.Information, "User Edit")
            Exit Sub
        End If
        If MsgBox("តើអ្នកពិតជាចង់បើកការប្រើប្រាស់របង់អ្នកប្រើប្រាស់មែនទេ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            dbHpr.ExecProc("disbl_TWSA_USER_PIN_MASTER", "PI_USER_ID", dg1.SelectedRows(0).Cells(1).Value, "PI_IS_LOCKED", "N")

            dg1.SelectedRows(0).Cells(2).Value = "N"

            MsgBox("អ្នកប្រើប្រាស់ត្រូវបានបើកការប្រើប្រាស់ដោយជោគជ័យ!")
        End If
    End Sub
End Class
