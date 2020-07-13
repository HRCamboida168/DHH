Imports System.Windows.Forms

Public Class User_ChangePWD
    Dim dbhpr As New db_helper
    Dim logDb As New LoginDB
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Check Old Pwd
        If txtoldPWD.Text.Trim = "" Then
            MsgBox("សូមបញ្ចូលលេខសម្ងាត់ចាស់!", MsgBoxStyle.Exclamation, "លេខសម្ងាត់...!")
            txtoldPWD.Focus()
            Exit Sub
        End If

        Dim oldPin As String = MasterFRM.userOldPin
        Dim pin_dt As String = MasterFRM.userPinDt
        Dim pin As String = logDb.encodePin(txtoldPWD.Text, pin_dt)

            If String.Compare(pin, oldPin) <> 0 Then
                MsgBox("លេខសម្ងាត់ចាស់មិនត្រឹមត្រូវទេ!", MsgBoxStyle.Exclamation)
                txtoldPWD.SelectAll()
                txtoldPWD.Focus()
                Exit Sub
            End If

            'New password
            If txtNewPWD.Text.Trim = "" Then
                MsgBox("សូមបញ្ចូលេខសម្ងាត់ថ្មី...!", MsgBoxStyle.Exclamation)
                txtNewPWD.Focus()
                Exit Sub
            End If
            'match pwd
            If txtNewPWD.Text.CompareTo(txtpwdconf.Text) <> 0 Then
                MsgBox("លេខសម្ងាត់ថ្មីមិនដូចគ្នា...!")
                txtNewPWD.Text = ""
                txtpwdconf.Text = ""
                txtNewPWD.Focus()
                Exit Sub
            End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub cbomustchange_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim f As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        sender.font = f
        sender.ForeColor = Color.Firebrick
    End Sub
    Private Sub txtpwdconf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpwdconf.GotFocus
        AcceptButton = OK_Button
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFullname.KeyDown, txtname.KeyDown, txtNewPWD.KeyDown, txtpwdconf.KeyDown, txtoldPWD.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectNextControl(sender, True, True, True, True)
        End If
    End Sub
    Private Sub txtpwdconf_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpwdconf.Leave
        AcceptButton = Nothing
    End Sub
End Class
