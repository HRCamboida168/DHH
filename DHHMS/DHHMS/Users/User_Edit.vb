Imports System.Windows.Forms

Public Class User_Edit

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'user full name
        If txtFullname.Text.Trim = "" Then
            MsgBox("Please input User Full Name..!")
            txtFullname.Focus()
            Exit Sub
        End If

        txtFullname.Focus()
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
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFullname.KeyDown, txtname.KeyDown, cbopol.KeyDown
        If e.KeyCode = Keys.Enter Then
            'user full name
            If sender.name = "txtFullname" Then
                If sender.text.trim = "" Then
                    MsgBox("Please input User Full Name..!")
                    txtFullname.Focus()
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
