Imports System.Windows.Forms

Public Class User_Input
    Dim dbhpr As New db_helper
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'user full name
        If txtFullname.Text.Trim = "" Then
            MsgBox("សូមបញ្ចូលអ្នកប្រើប្រាស់!")
            txtFullname.Focus()
            Exit Sub
        End If
        'log name
        If txtname.Text.Trim = "" Then
            MsgBox("សូមបញ្ចូលអ្នកប្រើប្រាស់!")
            txtname.Focus()
            Exit Sub
        End If
        'Pwd
        If txtpwd.Text.Trim = "" Then
            MsgBox("សូមបញ្ចូលលេខកូដ!")
            txtpwd.Focus()
            Exit Sub
        End If
        If txtpwd.Text.CompareTo(txtpwdconf.Text) <> 0 Then
            MsgBox("លេខសម្ងាត់មិនដូចគ្នា, សូមបញ្ចូលម្តងទៀត!")
            txtpwd.Focus()
            Exit Sub
        End If


        If dbhpr.Exists("tswa_user_pin_master", "user_id", txtname.Text) Then
            MsgBox("ឈ្មោះអ្នកប្រើប្រាសមានរួចហើយ!", MsgBoxStyle.Exclamation, "អ្នកប្រើប្រាស់ស្ទួន!")
            txtname.SelectAll()
            txtname.Focus()
            Exit Sub
        Else
            txtFullname.Focus()
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cbomustchange_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbopol.GotFocus
        Dim f As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        sender.font = f
        sender.ForeColor = Color.Firebrick
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFullname.KeyDown, txtname.KeyDown, txtpwd.KeyDown, txtpwdconf.KeyDown, cbopol.KeyDown
        If e.KeyCode = Keys.Enter Then
            'user full name
            If sender.name = "txtFullname" Then
                If sender.text.trim = "" Then
                    MsgBox("Please input User Full Name..!")
                    txtFullname.Focus()
                    Exit Sub
                End If
            End If
            'log name
            If sender.name = "txtname" Then
                If sender.text.trim = "" Then
                    MsgBox("Please input User LogIn Name..!")
                    txtname.Focus()
                    Exit Sub
                End If
            End If
            'Pwd
            If sender.name = "txtpwd" Then
                If sender.text.trim = "" Then
                    MsgBox("Please input User Password..!")
                    txtpwd.Focus()
                    Exit Sub
                End If
            End If
            SelectNextControl(sender, True, True, True, True)
        End If
    End Sub
    Private Sub cbocantchange_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbopol.LostFocus
        Dim f As New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
        sender.font = f
        sender.ForeColor = Color.Black
    End Sub


End Class
