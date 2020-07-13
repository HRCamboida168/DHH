Imports System.Windows.Forms

Public Class userGroupProfile
    Dim dbHpr As New db_helper
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If txtgrpNum.Text.Trim = "" Then
            MsgBox("please intput grouup Code!!!", MsgBoxStyle.Critical, "Group profile")
            txtgrpNum.Focus()
            Exit Sub
        End If
        Dim l_exist As Boolean = dbHpr.Exists("select grp_num from tuser_group_profiles where lower(grp_num)=lower('" & txtgrpNum.Text & "')")
        If l_exist = True Then
            MsgBox("group profile is already exist!!!", MsgBoxStyle.Exclamation, "Group Profile")
            txtgrpNum.Focus()
            Exit Sub
        End If
        If txtGrpNm.Text.Trim = "" Then
            MsgBox("Please input group name!!!", MsgBoxStyle.Critical, "group profile")
            txtGrpNm.Focus()
            Exit Sub
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesc.KeyDown, txtGrpNm.KeyDown, txtgrpNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectNextControl(sender, True, True, True, True)
        End If
    End Sub
End Class
