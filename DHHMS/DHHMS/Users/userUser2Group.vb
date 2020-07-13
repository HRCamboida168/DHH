Imports System.Windows.Forms

Public Class userUser2Group

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMovRight.Click
        If gvLeft.SelectedRows.Count > 0 Then
            gvRight.Rows.Add(gvLeft.SelectedCells(0).Value, gvLeft.SelectedCells(1).Value)
            gvLeft.Rows.RemoveAt(gvLeft.SelectedRows(0).Index)
        End If
    End Sub

    Private Sub btnMovLeft_Click(sender As Object, e As EventArgs) Handles btnMovLeft.Click
        If gvRight.SelectedRows.Count > 0 Then
            gvLeft.Rows.Add(gvRight.SelectedCells(0).Value, gvRight.SelectedCells(1).Value)
            gvRight.Rows.RemoveAt(gvRight.SelectedRows(0).Index)
        End If
    End Sub
End Class
